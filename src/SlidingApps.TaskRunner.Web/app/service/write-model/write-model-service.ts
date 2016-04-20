/// <reference path="../../typings.d.ts" />

// COMMON
import { Injectable, Inject } from 'ng-forward';
import { RestService } from '../rest/rest-service';

// MODEL
import { ICreateTenantPayload } from './tenant/create-tenant';

export class WriteModelServiceProvider implements angular.IServiceProvider {
    public $get: Array<any> = [
        '$q',
        'restService',
        'WRITEMODEL_HOST',
        'WRITEMODEL_API',
        ($q, restService, host, api) => new WriteModelService($q, restService, host, api)
    ];
}


@Injectable()
@Inject('$q', RestService, 'WRITEMODEL_HOST', 'WRITEMODEL_API')
export class WriteModelService {

    constructor(private $q: ng.IQService, private service: RestService, private hostUrl: any, private apiPath: any) {
        this.service.defaultConfiguration.host.url = hostUrl;
        this.service.defaultConfiguration.api.path = apiPath;
    }

    private static TENANT_RESOURCE: string = 'tenants';

    public postCreateTenant(payload: ICreateTenantPayload): angular.IPromise<void> {
        let deferred: angular.IDeferred<void> = this.$q.defer<void>();

        this.service.all(`${WriteModelService.TENANT_RESOURCE}`)
            .post(payload)
            .then(response => {
                
                deferred.resolve();
            })
            .catch(reason => deferred.reject(reason));

        return deferred.promise;
    }
}
