/// <reference path="../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import 'angular-local-storage';
import { BehaviorSubject } from 'rxjs';
import { Injectable, Inject } from 'ng-forward';
import * as crypto from 'crypto';

// FOUNDATION
import { Logger } from '../../component/foundation/logger';

// MODEL
import { IAccountValidity, AccountValidity } from './account/account-validity';
import { IAuthenticationStateChangedEvent, AuthenticationStateChangedEvent } from './authentication-state';

@Injectable()
@Inject('$http', '$q', '$window', 'AUTH_HOST', 'AUTH_API', 'localStorageService')
export class AuthorizationService {

    constructor(private $http: angular.IHttpService, private $q: angular.IQService, private $window: angular.IWindowService, private hostUrl: any, private apiPath: any, private storage: angular.local.storage.ILocalStorageService) {
        let account: string = this.$window.localStorage.getItem('taskrunner.authentication.account');
        
        if (account) {
            let _account: IAccountValidity = angular.fromJson(account);
            this.account = new AccountValidity(_account);

            this.secret = this.$window.localStorage.getItem('taskrunner.authentication.secret');
            
            this.authenticationState$.next(new AuthenticationStateChangedEvent(true, this.account));
        } else {
            this.authenticationState$.next(new AuthenticationStateChangedEvent(false));
        }
    }

    private account: AccountValidity;
    private secret: string;
    
    public authenticationState$: BehaviorSubject<IAuthenticationStateChangedEvent> = new BehaviorSubject<IAuthenticationStateChangedEvent>(undefined);

    public verifyCredentials(userName: string, password: string): angular.IPromise<AccountValidity> {
        let deferred: angular.IDeferred<AccountValidity> = this.$q.defer<AccountValidity>();

        let credentials: string =  window.btoa(userName + ':' + password);
        this.$http.get(`${this.hostUrl}/${this.apiPath}`, {
            headers: {
                'Authorization': 'Basic ' + credentials,
                'Accept': 'application/hal+json',
                'Content-Type': 'application/json; charset=utf-8'
            }
        })
            .then(response => {
                this.account = new AccountValidity(<IAccountValidity>(response.data));
                this.authenticationState$.next(new AuthenticationStateChangedEvent(true, this.account));

                this.$window.localStorage.setItem('taskrunner.authentication.account', angular.toJson(response.data));
                this.$window.sessionStorage.setItem('taskrunner.authentication.account', angular.toJson(response.data));

                let secret: string = crypto.createHash('sha256').update(password).digest('hex');
                this.$window.localStorage.setItem('taskrunner.authentication.secret', secret);
                this.$window.sessionStorage.setItem('taskrunner.authentication.secret', secret);

                deferred.resolve(this.account);
            })
            .catch(reason => {
                Logger.LOG.error(reason.data);
                deferred.reject(reason.data);
            });

        return deferred.promise;
    }
}
