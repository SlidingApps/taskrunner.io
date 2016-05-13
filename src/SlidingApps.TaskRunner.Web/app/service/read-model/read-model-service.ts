/// <reference path="../../typings.d.ts" />

// COMMON
import { Injectable, Inject } from 'ng-forward';
import { RestService } from '../rest/rest-service';

// MODEL
import { ITenantResource, TenantResource } from './tenant/tenant-resource';

export class ReadModelServiceProvider implements angular.IServiceProvider {
    public $get: Array<any> = [
        '$q',
        'restService',
        'READMODEL_HOST',
        'READMODEL_API',
        ($q, restService, host, api) => new ReadModelService($q, restService, host, api)
    ];
}


@Injectable()
@Inject('$q', RestService, 'READMODEL_HOST', 'READMODEL_API')
export class ReadModelService {

    constructor(private $q: ng.IQService, private restService: RestService, private hostUrl: any, private apiPath: any) {
        this.tenant = new TenantResource(this.$q, this.service);
    }

    private get service() {
        return this.restService.host(this.hostUrl).api(this.apiPath);
    }

    public tenant: ITenantResource;
}
