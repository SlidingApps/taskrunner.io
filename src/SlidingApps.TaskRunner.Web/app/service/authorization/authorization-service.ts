/// <reference path="../../typings.d.ts" />

import { Injectable, Inject } from 'ng-forward';

@Injectable()
@Inject('$http', '$q', 'READMODEL_HOST', 'READMODEL_API')
export class AuthorizationService {

    constructor(private $http: angular.IHttpService, private $q: angular.IQService, private hostUrl: any, private apiPath: any) {

    }

    public verifyCredentials(userName: string, password: string): void {
        let credentials: string =  window.btoa(userName + ':' + password);
        console.log('authentication', credentials);

        this.$http.get(`${this.hostUrl}/auth`, {
            headers: {
                'Authorization': 'Basic ' + credentials,
                'Accept': 'application/hal+json',
                'Content-Type': 'application/json; charset=utf-8'
            }
        });
    }
}
