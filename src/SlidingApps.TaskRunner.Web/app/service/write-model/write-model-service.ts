/// <reference path="../../typings.d.ts" />

// COMMON
import { Injectable, Inject } from 'ng-forward';
import { RestService, RestServiceConnector } from '../rest/rest-service';

// MODEL
import { ITenantResource, TenantResource } from './tenant/tenant-resource';
import { IAccountResource, AccountResource } from './account/account-resource';

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

    constructor(private $q: ng.IQService, private restService: RestService, private hostUrl: any, private apiPath: any) {
        this.tenant = new TenantResource(this.$q, this.service);
        this.account = new AccountResource(this.$q, this.service);
    }

    private get service(): RestServiceConnector {
        return this.restService.host(this.hostUrl).api(this.apiPath);
    }
    
    public tenant: ITenantResource;
    public account: IAccountResource;
}
