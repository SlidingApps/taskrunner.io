/// <reference path="../typings.d.ts" />

import { Component, StateConfig } from 'ng-forward';

// MODULES
import 'angular-ui-router';

// COMPONENTS
import { Page } from '../view/layout/page';

// VIEWS
import { HomeController } from '../view/public/home.controller';
import { AccountController } from '../view/account/account-controller.ts';


@Component({
    selector: 'application',
    providers: ['ui.router'],
    directives: [Page],
    template: `
    <!-- APPLICATION: BEGIN -->
    <page></page>
    <!-- APPLICATION: END -->
    `
})
@StateConfig([
    { name: 'home', url: '/', component: HomeController },
    { name: 'account', url: '/account', component: AccountController }
])
export class Application { }
