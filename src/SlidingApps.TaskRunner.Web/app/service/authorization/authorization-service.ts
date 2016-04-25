/// <reference path="../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import 'angular-local-storage';
import { BehaviorSubject } from 'rxjs';
import { Injectable, Inject } from 'ng-forward';
// import * as crypto from 'crypto';

// FOUNDATION
import { Logger } from '../../component/foundation/logger';
import { IEvent, IEventArgs } from '../../component/foundation/event';

// MODEL
import { AccountValidity } from './account/account-validity';

export interface IAuthenticationStateChangedEvent<TInstance> extends IEvent<TInstance, IAuthenticationStateChangedEventArgs> { }
export interface IAuthenticationStateChangedEventArgs extends IEventArgs {
    property: string;
    value: string;
}

@Injectable()
@Inject('$http', '$q', 'AUTH_HOST', 'AUTH_API', 'localStorageService')
export class AuthorizationService {

    constructor(private $http: angular.IHttpService, private $q: angular.IQService, private hostUrl: any, private apiPath: any, private storage: angular.local.storage.ILocalStorageService) {
        console.log(this);
        this.account = new AccountValidity();
        this.account.isValid = false;

        this.authenticationState$ = new BehaviorSubject<AccountValidity>(this.account);
        this.authenticationState$.next(this.account);
    }

    private account: AccountValidity;
    public authenticationState$: BehaviorSubject<AccountValidity>;

    public verifyCredentials(userName: string, password: string): angular.IPromise<AccountValidity> {
        let deferred: angular.IDeferred<AccountValidity> = this.$q.defer<AccountValidity>();

        let credentials: string =  window.btoa(userName + ':' + password);
        // let hash: string = crypto.createHash('sha1').update(password).digest('hex');

        this.$http.get(`${this.hostUrl}/${this.apiPath}`, {
            headers: {
                'Authorization': 'Basic ' + credentials,
                'Accept': 'application/hal+json',
                'Content-Type': 'application/json; charset=utf-8'
            }
        })
            .then(response => {
                let account: AccountValidity = new AccountValidity(response.data);
                this.authenticationState$.next(account);

                window.localStorage.setItem('username', angular.toJson(response.data));
                this.storage.set('account.validity', response);

                deferred.resolve(account);
            })
            .catch(reason => {
                Logger.LOG.error(reason.data);
                deferred.reject(reason.data);
            });

        return deferred.promise;
    }
}
