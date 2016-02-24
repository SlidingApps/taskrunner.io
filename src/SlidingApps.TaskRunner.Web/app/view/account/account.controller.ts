/// <reference path="../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { Component, Inject, StateConfig } from 'ng-forward';

// TEMPLATE
import template from './account.html';

// COMPONENTS
import { GetStartedController } from './get-started.controller';
import { SignInController } from './sign-in.controller';
import { ForgotPasswordController } from './forgot-password.controller';
import { ResetPasswordController } from './reset-password.controller';

// ANGULAR MODULES
import 'angular-ui-router';


@Component({
    selector: 'account',
    template: template,
    providers: ['ui.router']
})
@StateConfig([
    { 
        name: 'account.signin', 
        url: '/signin', 
        component: SignInController, 
        template: '<signin />'
    }, { 
        name: 'account.getStarted', 
        url: '/getstarted', 
        component: GetStartedController, 
        template: '<get-started />'
    }, { 
        name: 'account.forgotPassword', 
        url: '/forgotpassword', 
        component: ForgotPasswordController, 
        template: '<forgot-password />'
    }, { 
        name: 'account.resetPassword', 
        url: '/resetpassword', 
        component: ResetPasswordController, 
        template: '<reset-password />'
    }
])
@Inject('$scope', '$state')
export class AccountController {
    
    constructor(private $scope: angular.IScope, private $state: angular.ui.IStateService) { 
        // console.log('account', this);
    }
    
}
