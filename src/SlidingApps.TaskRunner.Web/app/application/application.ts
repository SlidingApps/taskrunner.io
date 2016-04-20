/// <reference path="../typings.d.ts" />

import { Component, StateConfig, Inject } from 'ng-forward';

// MODULES
import 'angular-ui-router';
import { Logger } from '../component/foundation/logger';

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
@Inject('$log')
export class Application { 
    constructor(private $log: angular.ILogService) {
        Logger.LOG = this.$log;
    }
    
    public static LOGGER: angular.ILogService;
}

