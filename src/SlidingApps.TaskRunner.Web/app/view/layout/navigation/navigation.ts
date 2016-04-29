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
            
            <div class="pageContent" data-ng-if="ctrl.isSignedIn">
                <div class="container-fluid">
                    <ul class="topNavigation">
                        <li>
                            <div class="btn-group simpleList simpleListLighten messages">
                                <button type="button" class="btn dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <i class="zmdi zmdi-email zmdi-hc-fw icon"></i>
                                    <span class="badge">6</span>
                                </button>
                                
                                <ul class="dropdown-menu pull-right">
                                    <li>
                                        <a href="#" title="#" class="clearfix">
                                            <img src="tmp/44x44-3.jpg" alt="#" width="44" height="44" class="pull-left">
                                            <span class="pull-left">
                                                <strong class="text-gray">John Doe</strong><br>
                                                <span class="text-gray">Proin vel sapien at risus...</span>
                                            </span>
                                            <span class="pull-right">22 sec. ago</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" title="#" class="clearfix">
                                            <img src="tmp/44x44-1.jpg" alt="#" width="44" height="44" class="pull-left">
                                            <span class="pull-left">
                                                <strong class="text-gray">Jane Doe</strong><br>
                                                <span class="text-gray">Aliquam non accumsan...</span>
                                            </span>
                                            <span class="pull-right">19 min. ago</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" title="#" class="clearfix">
                                            <img src="tmp/44x44-4.jpg" alt="#" width="44" height="44" class="pull-left">
                                            <span class="pull-left">
                                                <strong class="text-gray">Nick Doe</strong><br>
                                                <span class="text-gray">Praesent non hendrerit...</span>
                                            </span>
                                            <span class="pull-right">1 hour ago</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" title="#" class="clearfix">
                                            <img src="tmp/44x44-5.jpg" alt="#" width="44" height="44" class="pull-left">
                                            <span class="pull-left">
                                                <strong class="text-gray">Andrew Doe</strong><br>
                                                <span class="text-gray">Aliquam ligula ante magna...</span>
                                            </span>
                                            <span class="pull-right">21.09.2015</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" title="#" class="clearfix text-center">
                                            <i class="zmdi zmdi-plus-square icon"></i> <strong class="text-gray">See all</strong>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <div class="btn-group simpleList list-sm">
                                <button type="button" class="btn dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <i class="zmdi zmdi-bookmark zmdi-hc-fw icon"></i>
                                    <span class="badge">98</span>
                                </button>
    
                                <ul class="dropdown-menu pull-right">
                                    <li>
                                        <a href="#" title="#" class="clearfix">
                                            <span class="pull-left"><i class="zmdi zmdi-accounts-add zmdi-hc-fw icon"></i> Followers</span>
                                            <span class="pull-right info">109,073</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" title="#" class="clearfix">
                                            <span class="pull-left"><i class="zmdi zmdi-accounts-list-alt zmdi-hc-fw icon"></i> Subscribers</span>
                                            <span class="pull-right info">26,114</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" title="#" class="clearfix">
                                            <span class="pull-left"><i class="zmdi zmdi-assignment-o zmdi-hc-fw icon"></i> Products sold</span>
                                            <span class="pull-right info">1,557,669</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" title="#" class="clearfix">
                                            <span class="pull-left"><i class="zmdi zmdi-bookmark zmdi-hc-fw icon"></i> Awards</span>
                                            <span class="pull-right info">14</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" title="#" class="clearfix">
                                            <span class="pull-left"><i class="zmdi zmdi-cloud-done zmdi-hc-fw icon"></i> Projects</span>
                                            <span class="pull-right info">229</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#" title="#" class="clearfix text-center">
                                            <i class="zmdi zmdi-plus-square icon"></i> See all
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <div class="btn-group simpleList list-sm">
                                <button type="button" class="btn btn-normal" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="width: auto; margin: 0 0 0 8px;">
                                    <div data-ng-bind="ctrl.account.emailAddress" style="vertical-align: center; padding: 0 8px 0 8px;"></div>
                                </button>
    
                                <ul class="dropdown-menu pull-right">
                                    <li>
                                        <a href="#" class="clearfix" (click)="ctrl.onGotoSignOut()" onclick="return false;">
                                            <span class="pull-left"><i class="zmdi zmdi-accounts-add zmdi-hc-fw icon"></i> Sign Out</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
    
            <div class="pageContent" data-ng-if="!ctrl.isSignedIn">
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
@Inject('$scope', '$state', '$timeout', AuthorizationService)
export class Navigation {

    constructor(private $scope: angular.IScope, private $state: angular.ui.IStateService, private $timeout: angular.ITimeoutService, private authorization: AuthorizationService) { }

    public isSignedIn: boolean = false;
    public account: { id: string, emailAddress: string, username: string };

    private subscription: Subscription;

    public onGotoGetStarted(): void {
        this.$state.go('account.getStarted');
    }

    public onGotoSignIn(): void {
        this.$state.go('account.signin');
    }

    public onGotoSignOut(): void {
        this.$state.go('account.signout');
    }

    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
        this.subscription =
            this.authorization.authenticationState$
                .subscribe(x => {
                    this.$timeout(() => {
                        // redirect only if have not set account, which means it is the first time the view is loaded
                        let redirect: boolean = this.account !== undefined;

                        this.isSignedIn = x.isSignedIn;
                        this.account = x.account;

                        if (redirect) { this.$state.go('home'); }
                    });
                });
    }

    private ngOnDestroy(): void {
        if (this.subscription && !this.subscription.isUnsubscribed) { this.subscription.unsubscribe(); }
    }
    /* tslint:enable:no-unused-variable */

}
