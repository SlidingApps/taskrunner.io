/// <reference path="../../typings.d.ts" />

// COMMON
import { Subscription } from 'rxjs';
import { Injectable, Inject } from 'ng-forward';
import * as crypto from 'crypto';

@Injectable()
@Inject('$http', '$q', 'AUTH_HOST', 'AUTH_API')
export class AuthorizationService {

    constructor(private $http: angular.IHttpService, private $q: angular.IQService, private hostUrl: any, private apiPath: any) { }

    public verifyCredentials(userName: string, password: string): void {
        let credentials: string =  window.btoa(userName + ':' + password);
        let hash: string = crypto.createHash('sha1').update(password).digest('hex');

        console.log('authentication', credentials, hash);

        this.$http.get(`${this.hostUrl}/${this.apiPath}`, {
            headers: {
                'Authorization': 'Basic ' + credentials,
                'Accept': 'application/hal+json',
                'Content-Type': 'application/json; charset=utf-8'
            }
        });
    }
}
