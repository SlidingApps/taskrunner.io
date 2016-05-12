/// <reference path="../../../typings.d.ts" />

// COMMON
import 'angular';

// MODEL
import { RestServiceConnector } from '../../rest/rest-service';
import { TenantResource } from '../tenant/tenant-resource';
import { IPasswordLinkPayload } from './password-link';

export interface IAccountResource {
    postPasswordLink(tenantId: string, userName: string, payload: IPasswordLinkPayload): angular.IPromise<void>;
}

export class AccountResource implements IAccountResource {
    constructor(private $q: angular.IQService, private service: RestServiceConnector) { }

    public static RESOURCE: string = 'accounts';

    public postPasswordLink(tenantId: string, userName: string, payload: IPasswordLinkPayload): angular.IPromise<void> {
        let deferred: angular.IDeferred<void> = this.$q.defer<void>();

        this.service
            .all(`${TenantResource.RESOURCE}/${tenantId}/${AccountResource.RESOURCE}/${userName}`)
            .post(payload)
            .then(response => {

                deferred.resolve();
            })
            .catch(reason => deferred.reject(reason));

        return deferred.promise;
    }
}
