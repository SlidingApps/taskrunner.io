/// <reference path="../../typings.d.ts" />

// COMMON
import { Injectable, Inject } from 'ng-forward';
import { RestService } from '../rest/rest-service';

// MODEL
import {TenantCodeAvailability, ITenantCodeAvailability} from './tenant/tenant-code-availability';

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

    constructor(private $q: ng.IQService, private restService: RestService, private hostUrl: any, private apiPath: any) { }

    private static TENANT_RESOURCE: string = 'tenants';

    private get service() {
        return this.restService.host(this.hostUrl).api(this.apiPath);
    }

    public getTenantCodeAvailability(code: string): angular.IPromise<TenantCodeAvailability> {
        let deferred: angular.IDeferred<TenantCodeAvailability> = this.$q.defer<TenantCodeAvailability>();

        this.service
            .all(`${ReadModelService.TENANT_RESOURCE}/${code}/availability`)
            .get()
            .then((representation: ITenantCodeAvailability) => {
                deferred.resolve(new TenantCodeAvailability(representation));
            })
            .catch(reason => deferred.reject(reason));

        return deferred.promise;
    }
}
