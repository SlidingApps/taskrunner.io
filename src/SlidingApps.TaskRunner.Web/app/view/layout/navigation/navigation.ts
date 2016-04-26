/// <reference path="../../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { Component, Inject } from 'ng-forward';
import { Subscription } from 'rxjs';

// PARTIAL SPECIFIC
import { AuthorizationService } from '../../../service/authorization/authorization-service';

@Component({
    selector: 'navigation',
    template: `
        <!-- LAYOUT.NAVIGATION: BEGIN -->
        <header id="header" style="position: fixed; top:0; left: 0; width: 100%;">
            <h1 class="logo">
                <a href="#" class="js-nav-toggler">
                    <i class="icon icon-close"></i>
                </a>
                <a href="#" ><span>taskrunner</span>.io</a>
            </h1>
    
            <div class="pageContent">
                <div class="container-fluid">
                    <div class="col-sm-1 col-sm-offset-10">
                        <button class="btn btn-primary" style="margin-top: 10px;" (click)="ctrl.onGotoGetStarted()">Get started</button>
                    </div>
                    <div class="col-sm-1">
                        <button class="btn btn-normal" style="margin-top: 10px;" (click)="ctrl.onGotoSignIn()">Sign In</button>
                    </div>
                </div>
            </div>
        </header>
        <!-- LAYOUT.NAVIGATION: END -->
    `
})
@Inject('$scope', '$state', AuthorizationService)
export class Navigation {

    constructor(private $scope: angular.IScope, private $state: angular.ui.IStateService,  private authorization: AuthorizationService) { }

    private subscription: Subscription;

    public onGotoGetStarted(): void {
        this.$state.go('account.getStarted');
    }

    public onGotoSignIn(): void {
        this.$state.go('account.signin');
    }

    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
        this.subscription = this.authorization.authenticationState$.subscribe(x => console.log('state', x));
    }

    private ngOnDestroy(): void {
        if (this.subscription && !this.subscription.isUnsubscribed) { this.subscription.unsubscribe(); }
    }
    /* tslint:enable:no-unused-variable */

}
