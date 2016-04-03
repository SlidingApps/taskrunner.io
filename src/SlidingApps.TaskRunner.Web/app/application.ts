/// <reference path="./typings.d.ts" />

import { Component, StateConfig } from 'ng-forward';

// MODULES
import 'angular-ui-router';

// COMPONENTS
import { Navigation } from './view/layout/navigation';
import { Content } from './view/layout/content';

// VIEWS
import { HomeController } from './view/public/home.controller';
import { AccountController } from './view/account/account.controller.ts';


@Component({
    selector: 'application',
    providers: ['ui.router'],
    directives: [ Navigation, Content],
    template: `
    <!-- APPLICATION: BEGIN -->
    <navigation></navigation>
    <content></content>
    <!-- APPLICATION: END -->
    `
})
@StateConfig([
    { name: 'home', url: '/', component: HomeController },
    { name: 'account', url: '/account', component: AccountController }
])
export class Application { }
