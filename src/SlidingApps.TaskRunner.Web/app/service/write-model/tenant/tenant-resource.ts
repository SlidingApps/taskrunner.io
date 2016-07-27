/// <reference path="../../../typings.d.ts" />

// COMMON
import 'angular';

// MODEL
import { RestServiceConnector } from '../../rest/rest-service';
import { ICreateTenantPayload } from './create-tenant';

export interface ITenantResource {
    postCreateTenant(payload: ICreateTenantPayload): angular.IPromise<void>;
}

export class TenantResource implements ITenantResource {
    constructor(private $q: angular.IQService, private service: RestServiceConnector) { }

    public static RESOURCE: string = 'tenants';

    public postCreateTenant(payload: ICreateTenantPayload): angular.IPromise<void> {
        let deferred: angular.IDeferred<void> = this.$q.defer<void>();

        this.service
            .all(`${TenantResource.RESOURCE}`)
            .post(payload)
            .then(response => {

                deferred.resolve();
            })
            .catch(reason => deferred.reject(reason));

        return deferred.promise;
    }

    public confirmTenant(tenantCode: string, link: string): angular.IPromise<void> {
        let deferred: angular.IDeferred<void> = this.$q.defer<void>();

        this.service
            .all(`${TenantResource.RESOURCE}/${tenantCode}/confirm/${link}`)
            .get()
            .then(response => {
                deferred.resolve();
            })
            .catch(reason => deferred.reject(reason));

        return deferred.promise;
    }
}
