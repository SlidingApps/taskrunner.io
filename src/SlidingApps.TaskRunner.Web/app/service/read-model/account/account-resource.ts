/// <reference path="../../../typings.d.ts" />

// COMMON
import { RestServiceConnector } from '../../rest/rest-service';

// MODEL
import { DecryptedLink, IDecryptedLink } from './decrypted-link';


export interface IAccountResource {
    decryptLink(username: string, link: string): angular.IPromise<DecryptedLink>;
}

export class AccountResource implements IAccountResource {

    constructor(private $q: ng.IQService, private service: RestServiceConnector) { }

    private static RESOURCE: string = 'accounts';

    public decryptLink(username: string, link: string): angular.IPromise<DecryptedLink> {
        let deferred: angular.IDeferred<DecryptedLink> = this.$q.defer<DecryptedLink>();

        this.service
            .all(`${AccountResource.RESOURCE}/${username}/decryptions/${link}`)
            .get()
            .then((representation: IDecryptedLink) => {
                deferred.resolve(new DecryptedLink(representation));
            })
            .catch(reason => deferred.reject(reason));

        return deferred.promise;
    }
}
