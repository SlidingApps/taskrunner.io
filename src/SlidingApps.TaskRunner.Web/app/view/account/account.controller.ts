/// <reference path="../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { Component, Inject, StateConfig } from 'ng-forward';

// TEMPLATE
import template from './account.html';

// COMPONENTS
import { GetStartedController } from './get-started.controller';
import { SignInController } from './sign-in.controller';

// ANGULAR MODULES
import 'angular-ui-router';


@Component({
    selector: 'account',
    template,
    providers: ['ui.router'],
})
@StateConfig([
    { 
        name: 'account.signin', 
        url: '/signin', 
        component: SignInController, 
        template: '<signin />'
    },
    { 
        name: 'account.getStarted', 
        url: '/getstarted', 
        component: GetStartedController, 
        template: '<get-started />'
    }
])
@Inject('$scope', '$state')
export class AccountController {
    
    constructor(private $scope: ng.IRootScopeService, private $state: angular.ui.IStateService) { 
        console.log('account', this);
    }
    
}