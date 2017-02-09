/// <reference path="../../../typings.d.ts" />

// COMMON
import { RestServiceConnector } from '../../rest/rest-service';

// MODEL
import { DecryptedLink, IDecryptedLink } from './decrypted-link';


export interface IPersonResource {
    decryptLink(username: string, link: string): angular.IPromise<DecryptedLink>;
}

export class PersonResource implements IPersonResource {

    constructor(private $q: ng.IQService, private service: RestServiceConnector) { }

    private static RESOURCE: string = 'persons';

    public decryptLink(username: string, link: string): angular.IPromise<DecryptedLink> {
        let deferred: angular.IDeferred<DecryptedLink> = this.$q.defer<DecryptedLink>();

        this.service
            .all(`${PersonResource.RESOURCE}/${username}/decryptions/${link}`)
            .get()
            .then((representation: IDecryptedLink) => {
                deferred.resolve(new DecryptedLink(representation));
            })
            .catch(reason => deferred.reject(reason));

        return deferred.promise;
    }
}
