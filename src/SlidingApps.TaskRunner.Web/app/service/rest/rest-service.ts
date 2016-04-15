/// <reference path="../../typings.d.ts" />

import { Injectable, Inject } from 'ng-forward';

@Injectable()
@Inject('$http', '$q')
export class RestService {

    constructor($http: angular.IHttpService, $q: angular.IQService) {
        this.$http = $http;
        this.$q = $q;
        this.defaultConfiguration = new RestServiceConfiguration();
    }

    public static get DELIMITER(): string { return '/'; };

    public $http: angular.IHttpService;
    public $q: angular.IQService;
    public configuration: RestServiceConfiguration;
    public defaultConfiguration: RestServiceConfiguration;

    /** Sets the host options, ex. URL. */
    public host(options: string|IHostOptions): RestServiceConnector {
        this.configuration = angular.copy(this.defaultConfiguration);
        let _options: IHostOptions = typeof options === 'string' ? { url: options } : options;
        let configuration: RestServiceConfiguration = angular.extend({}, this.configuration);
        configuration.host.url = _options.url;

        let connector: RestServiceConnector = new RestServiceConnector(this.$http, this.$q, configuration);

        return connector;
    }

    /** Sets the API options, ex. path. */
    public api(options: string|IApiOptions): RestServiceConnector {
        this.configuration = angular.copy(this.defaultConfiguration);
        let _options: IApiOptions = typeof options === 'string' ? { path: options } : options;
        let configuration: RestServiceConfiguration = angular.extend({}, this.configuration);
        configuration.api.path = _options.path;
        configuration.api.values = _options.values;

        let connector: RestServiceConnector = new RestServiceConnector(this.$http, this.$q, configuration);

        return connector;
    }

    /** Gets a collection of the specified resource. */
    public all<TRepresentation>(options: string|IResourceOptions): RestServiceEndpoint {
        this.configuration = angular.copy(this.defaultConfiguration);
        let connector: RestServiceConnector = new RestServiceConnector(this.$http, this.$q, this.configuration);
        return connector.all<TRepresentation>(options);
    }

    /** Gets a resource identified by the given identifier. */
    public one<TRepresentation>(name: string, id?: string): RestServiceEndpoint {
        this.configuration = angular.copy(this.defaultConfiguration);
        let connector: RestServiceConnector = new RestServiceConnector(this.$http, this.$q, this.configuration);
        return connector.one<TRepresentation>(name, id);
    }

    public full<TRepresentation>(url): RestServiceEndpoint {
        this.configuration = angular.copy(this.defaultConfiguration);
        let connector: RestServiceConnector = new RestServiceConnector(this.$http, this.$q, this.configuration);
        return connector.full<TRepresentation>(url);
    }


}

export class RestServiceConnector {

    constructor($http: angular.IHttpService, $q: angular.IQService, configuration: RestServiceConfiguration) {
        this.$http = $http;
        this.$q = $q;

        this.configuration = configuration;
    }

    private $q: angular.IQService;
    private $http: angular.IHttpService;

    public configuration: RestServiceConfiguration;

    public host(options: string|IHostOptions): RestServiceConnector {
        let _options: IHostOptions = typeof options === 'string' ? { url: options } : options;
        let configuration: RestServiceConfiguration = angular.extend({}, this.configuration);
        configuration.host.url = _options.url;

        return this;
    }

    public api(options: string|IApiOptions): RestServiceConnector {
        let _options: IApiOptions = typeof options === 'string' ? { path: options } : options;
        let configuration: RestServiceConfiguration = angular.extend({}, this.configuration);
        configuration.api.path = _options.path;
        configuration.api.values = _options.values;

        return this;
    }

    public all<TRepresentation>(options: string|IResourceOptions): RestServiceEndpoint {
        let endpointUrl: string = RestServiceUtils.BuildEndpointUrl(this.configuration);
        let endpoint: RestServiceEndpoint = new RestServiceEndpoint(this.$http, this.$q, new EndpointConfiguration(endpointUrl));
        endpoint.all(options);

        return endpoint;
    }

    public one<TRepresentation>(name: string, id?: string): RestServiceEndpoint {
        let endpointUrl: string = RestServiceUtils.BuildEndpointUrl(this.configuration);
        let endpoint: RestServiceEndpoint = new RestServiceEndpoint(this.$http, this.$q, new EndpointConfiguration(endpointUrl));
        endpoint.one(name, id);

        return endpoint;
    }

    public full<TRepresentation>(url): RestServiceEndpoint {
        let endpointUrl: string = url;
        let endpoint: RestServiceEndpoint = new RestServiceEndpoint(this.$http, this.$q, new EndpointConfiguration(endpointUrl));
        return endpoint;
    }
}

export class RestServiceEndpoint {

    constructor($http: angular.IHttpService, $q: angular.IQService, configuration: EndpointConfiguration) {
        this.$http = $http;
        this.$q = $q;
        this.configuration = configuration;
    }

    private $q: angular.IQService;
    private $http: angular.IHttpService;

    private requestConfiguration: angular.IRequestShortcutConfig = {
        headers: {
            'Accept': 'application/hal+json',
            'Content-Type': 'application/json; charset=utf-8'
        }
    }
    private configuration: EndpointConfiguration;
    private resources: Array<ResourceConfiguration> = [];
    private queryString: string = '';


    public query(query: any): RestServiceEndpoint {
        this.queryString = RestServiceUtils.BuildQueryString(query);

        return this;
    }

    public all<TRepresentation>(options: string|IResourceOptions): RestServiceEndpoint {
        let _options: IResourceOptions = typeof options === 'string' ? { name: options.toString() } : options;
        let configuration: ResourceConfiguration = new ResourceConfiguration(_options.name);

        this.resources.push(configuration);

        return this;
    }

    public one<TRepresentation>(name: string, identifier?: string): RestServiceEndpoint {
        let _options: IResourceOptions = { name: name, id: identifier };
        let configuration: ResourceConfiguration = new ResourceConfiguration(_options.name, _options.id);

        this.resources.push(configuration);

        return this;
    }

    public several<TRepresentation>(name: string, identifiers: Array<string>): RestServiceEndpointSet {
        let url: string = this.configuration.url;
        this.resources.forEach((resource: ResourceConfiguration) => {
            url = url + RestService.DELIMITER + resource.name + (resource.id ? '/' + resource.id : '');
        });

        let endpoints: Array<RestServiceEndpoint> = [];
        for (let i = 0; i < identifiers.length; i++) {
            let endpoint: RestServiceEndpoint = new RestServiceEndpoint(this.$http, this.$q, new EndpointConfiguration(url));
            endpoint.one(name, identifiers[i]);

            endpoints.push(endpoint);
        }

        let endpointSet: RestServiceEndpointSet = new RestServiceEndpointSet(this.$q, endpoints);

        return endpointSet;
    }

    public get<TRepresentation>(cache: boolean = false): angular.IPromise<TRepresentation> {
        let deferred: angular.IDeferred<TRepresentation> = this.$q.defer();

        let url: string = this.configuration.url;
        this.resources.forEach((resource: ResourceConfiguration) => {
            url = url + RestService.DELIMITER + resource.name + (resource.id ? '/' + resource.id : '');
        });

        url = url + this.queryString;

        this.$http.get(url, angular.extend({}, this.requestConfiguration, { cache: cache }))
            .success((data: TRepresentation) => {
                deferred.resolve(data);
            })
            .error((error: any) => {
                deferred.reject(error);
            });

        return deferred.promise;
    }

    public post<TRepresentation>(instance: TRepresentation): angular.IPromise<any> {
        let deferred: angular.IDeferred<TRepresentation> = this.$q.defer();

        let url: string = this.configuration.url;
        this.resources.forEach((resource: ResourceConfiguration) => {
            url = url + RestService.DELIMITER + resource.name + (resource.id ? '/' + resource.id : '');
        });

        url = url + this.queryString;

        this.$http.post(url, instance, this.requestConfiguration)
            .success((data: any) => {
                deferred.resolve(data);
            })
            .error((error: any) => {
                deferred.reject(error);
            });

        return deferred.promise;
    }

    public put<TRepresentation>(instance?: TRepresentation): angular.IPromise<TRepresentation> {
        let deferred: angular.IDeferred<TRepresentation> = this.$q.defer();

        let url: string = this.configuration.url;
        this.resources.forEach((resource: ResourceConfiguration) => {
            url = url + RestService.DELIMITER + resource.name + (resource.id ? '/' + resource.id : '');
        });

        url = url + this.queryString;

        this.$http.put(url, instance, this.requestConfiguration)
            .success((data: any) => {
                deferred.resolve(data);
            })
            .error((error: any) => {
                deferred.reject(error);
            });

        return deferred.promise;
    }


    public delete<TRepresentation>(): angular.IPromise<void> {
        let deferred: angular.IDeferred<void> = this.$q.defer<void>();

        let url: string = this.configuration.url;
        this.resources.forEach((resource: ResourceConfiguration) => {
            url = url + RestService.DELIMITER + resource.name + (resource.id ? '/' + resource.id : '');
        });

        url = url + this.queryString;

        this.$http.delete(url, this.requestConfiguration)
            .success(() => {
                deferred.resolve();
            })
            .error((error: any) => {
                deferred.reject(error);
            });

        return deferred.promise;
    }
}

export class RestServiceEndpointSet {

    constructor($q: angular.IQService, endpoints: Array<RestServiceEndpoint>) {
        this.$q = $q;

        this.endpoints = endpoints;
    }

    private $q: angular.IQService;
    private endpoints: Array<RestServiceEndpoint> = [];
    private _query: any = {};

    public query(query: any): RestServiceEndpointSet {
        this._query = query;

        return this;
    }

    public get<TRepresentation>(): angular.IPromise<Array<TRepresentation>> {
        let promises: Array<angular.IPromise<TRepresentation>> = [];

        // let config: angular.IRequestShortcutConfig = { headers: {} };
        // config.headers = this.addCustomHttpHeaders();

        for (let i = 0; i < this.endpoints.length; i++) {
            let promise: angular.IPromise<TRepresentation> = this.endpoints[i].query(this._query).get();
            promises.push(promise);
        }

        return this.$q.all(promises);
    }
}

// -------------------------------------------------------------------------------------------------------------
// HELPER, OPTIONS & CONFIGURATIONS
// -------------------------------------------------------------------------------------------------------------

class RestServiceUtils {

    public static BuildEndpointUrl(configuration: RestServiceConfiguration): string {
        if (configuration.host.url[configuration.host.url.length - 1] === '/') {
            configuration.host.url = configuration.host.url.substr(0, configuration.host.url.length - 1);
        }

        if (configuration.api.path[0] === '/') {
            configuration.api.path = configuration.api.path.substr(1);
        }

        if (configuration.api.path[configuration.api.path.length - 1] === '/') {
            configuration.api.path = configuration.api.path.substr(0, configuration.api.path.length - 1);
        }

        let endpoint: string = configuration.host.url + RestService.DELIMITER + configuration.api.path;

        return endpoint;
    }

    public static BuildQueryString(query: any): string {
        let queryString: string = '';

        if (query) {
            query =
                Object.keys(query)
                    .map((key: string): IKeyValuePair<any> => {
                        return {
                            key: key,
                            value: query[key]
                        }
                    })
                    .filter((pair: IKeyValuePair<any>) => {
                        return pair.value !== null && pair.value !== undefined;
                    })
                    .map((pair: IKeyValuePair<any>) => {
                        if (pair.value instanceof Date) {
                            pair.value = pair.value.toISOString()
                        }

                        if (pair.value instanceof Array) {
                            if (pair.value.length === 0) return pair.key.toLowerCase() + '=';
                            return pair.value.map(x => pair.key.toLowerCase() + '=' + encodeURIComponent(x)).join('&');
                        }

                        return pair.key.toLowerCase() + '=' + encodeURIComponent(pair.value);
                    });

            if (query.length > 0) {
                queryString = query.reduce((previous: string, current: string): string => {
                    return previous + '&' + current;
                });
            }
        }

        return queryString !== '' ? '?' + queryString : queryString;
    }
}

interface IKeyValuePair<TValue> {
    key: string;
    value: TValue;
}

export interface IEndpointOptions {
    url: string;
}

export interface IEndpointConfiguration extends IEndpointOptions {
    url: string;
}

export class EndpointConfiguration implements IEndpointConfiguration {

    constructor(url: string) {
        this.url = url;
    }

    public url: string;
}

export interface IResourceOptions {
    name: string;
    id?: string;
}

export interface IResourceConfiguration extends IResourceOptions {
    name: string;
    id: string;
}

export class ResourceConfiguration implements IResourceConfiguration {

    constructor(name: string, id?: string) {
        this.name = name;
        this.id = id;
    }

    public name: string;
    public id: string = null;
}

export interface IHostOptions {
    url: string;
}

export interface IHostConfiguration extends IHostOptions {
    url: string;
}

export interface IApiOptions {
    path: string;
    values?: any
}

export interface IApiConfiguration extends IApiOptions {
    path: string;
    values: any;
}

export interface IRestServiceConfiguration {
    host: IHostConfiguration;
    api: IApiConfiguration;
}

export class HostConfiguration implements IHostConfiguration {
    url: string = '/';
}

export class ApiConfiguration implements IApiConfiguration {
    path: string = 'api';
    values: any = null;
}

export class RestServiceConfiguration implements IRestServiceConfiguration {

    constructor() {
        this.host = new HostConfiguration();
        this.api = new ApiConfiguration();
    }

    host: IHostConfiguration;
    api: IApiConfiguration;
}
