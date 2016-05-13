/// <reference path="../../../typings.d.ts" />

// COMMON
import { RestServiceConnector } from '../../rest/rest-service';

// MODEL
import { TenantCodeAvailability, ITenantCodeAvailability } from './tenant-code-availability';


export interface ITenantResource {
    getTenantCodeAvailability(code: string): angular.IPromise<TenantCodeAvailability>;
}

export class TenantResource implements ITenantResource {

    constructor(private $q: ng.IQService, private service: RestServiceConnector) { }

    private static RESOURCE: string = 'tenants';

    public getTenantCodeAvailability(code: string): angular.IPromise<TenantCodeAvailability> {
        let deferred: angular.IDeferred<TenantCodeAvailability> = this.$q.defer<TenantCodeAvailability>();

        this.service
            .all(`${TenantResource.RESOURCE}/${code}/availability`)
            .get()
            .then((representation: ITenantCodeAvailability) => {
                deferred.resolve(new TenantCodeAvailability(representation));
            })
            .catch(reason => deferred.reject(reason));

        return deferred.promise;
    }
}
