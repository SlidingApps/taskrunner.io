/// <reference path="../../typings.d.ts" />
/// <reference path="./crypto-local.d.ts" />

// COMMON
import * as angular from 'angular';
import * as crypto from 'crypto';
import 'angular-local-storage';
import { BehaviorSubject, Observer, Observable } from 'rxjs';
import { Injectable, Inject } from 'ng-forward';

// FOUNDATION
import { Logger } from '../../component/foundation/logger';

// MODEL
import { IAccountValidity, AccountValidity } from './account/account-validity';
import { IAuthenticationStateChangedEvent, AuthenticationStateChangedEvent } from './authentication-state';

@Injectable()
@Inject('$http', '$q', '$window', 'AUTH_HOST', 'AUTH_API', 'localStorageService')
export class AuthorizationService {

    constructor(private $http: angular.IHttpService, private $q: angular.IQService, private $window: angular.IWindowService, private hostUrl: any, private apiPath: any, private storage: angular.local.storage.ILocalStorageService) {
        let accountStored: string = this.$window.localStorage.getItem(AuthorizationService.AUTHENTICATION_ACCOUNT);

        if (accountStored) {
            this.secret = this.$window.localStorage.getItem(AuthorizationService.AUTHENTICATION_SECRET);

            let _account: IAccountValidity = angular.fromJson(accountStored);
            this.account = new AccountValidity(_account);
            this.authenticationState$.next(new AuthenticationStateChangedEvent(true, this.account));
        } else {
            this.authenticationState$.next(new AuthenticationStateChangedEvent(false));
        }

        this.$window.addEventListener('storage', event => this.onStorageChanged(event));
    }

    public static get AUTHENTICATION_ACCOUNT(): string { return 'taskrunner.authentication.account'; }

    public static get AUTHENTICATION_SECRET(): string { return 'taskrunner.authentication.secret'; }

    private account: AccountValidity;
    private secret: string;

    public authenticationState$: BehaviorSubject<IAuthenticationStateChangedEvent> = new BehaviorSubject<IAuthenticationStateChangedEvent>(undefined);
    public test: any = Observable.fromEvent(window, 'storage', event => { console.log('storage', event); return event; });

    public signIn(userName: string, password: string): angular.IPromise<AccountValidity> {
        let deferred: angular.IDeferred<AccountValidity> = this.$q.defer<AccountValidity>();

        let credentials: string =  this.$window.btoa(userName + ':' + password);
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

                this.$window.localStorage.setItem(AuthorizationService.AUTHENTICATION_ACCOUNT, angular.toJson(response.data));
                this.$window.sessionStorage.setItem(AuthorizationService.AUTHENTICATION_ACCOUNT, angular.toJson(response.data));

                let secret: string = crypto.createHash('sha256').update(password).digest('hex');
                this.$window.localStorage.setItem(AuthorizationService.AUTHENTICATION_SECRET, secret);
                this.$window.sessionStorage.setItem(AuthorizationService.AUTHENTICATION_SECRET, secret);

                deferred.resolve(this.account);
            })
            .catch(reason => {
                Logger.LOG.error(reason.data);
                deferred.reject(reason.data);
            });

        return deferred.promise;
    }

    public signOut() {
        this.clearStorage();
        this.authenticationState$.next(new AuthenticationStateChangedEvent(false));
    }

    private onStorageChanged(event: StorageEvent): void {
        if ((event.key === AuthorizationService.AUTHENTICATION_ACCOUNT || event.key === AuthorizationService.AUTHENTICATION_SECRET) && !event.newValue) {
            this.signOut();
        }
    }

    private clearStorage() {
        this.$window.localStorage.removeItem(AuthorizationService.AUTHENTICATION_ACCOUNT);
        this.$window.sessionStorage.removeItem(AuthorizationService.AUTHENTICATION_ACCOUNT);

        this.$window.localStorage.removeItem(AuthorizationService.AUTHENTICATION_SECRET);
        this.$window.sessionStorage.removeItem(AuthorizationService.AUTHENTICATION_SECRET);
    }
}
