/// <reference path="../../typings.d.ts" />

// COMMON
import { Component, StateConfig } from 'ng-forward';

// COMPONENTS
import { View as GetStarted } from './get-started/view';
import { View as SignIn } from './sign-in/view';
import { View as SignOut } from './sign-out/view';
import { View as ForgotPassword } from './forgot-password/view';
import { View as ResetPassword } from './reset-password/view';

// ANGULAR MODULES
import 'angular-ui-router';


@Component({
    selector: 'account',
    providers: ['ui.router'],
    template: `<div data-ui-view></div>`
})
@StateConfig([
    {
        name: 'account.signin',
        url: '/signin',
        component: SignIn,
        template: '<account-sign-in />'
    }, {
        name: 'account.signout',
        url: '/signout',
        component: SignOut,
        template: '<account-sign-out />'
    }, {
        name: 'account.getStarted',
        url: '/getstarted',
        component: GetStarted,
        template: '<account-get-started />'
    }, {
        name: 'account.forgotPassword',
        url: '/forgotpassword',
        component: ForgotPassword,
        template: '<account-forgot-password />'
    }, {
        name: 'account.resetPassword',
        url: '/{username}/resetpassword/{link}',
        component: ResetPassword,
        template: '<account-reset-password />'
    }
])
export class AccountController { }
