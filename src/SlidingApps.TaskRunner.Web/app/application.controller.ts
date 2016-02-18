/// <reference path="./typings.d.ts" />

import * as angular from 'angular';
import { Component, Inject, StateConfig } from 'ng-forward';

// MODULES
import 'angular-ui-router';

// COMPONENTS
import { Navigation } from './component/layout/navigation';
import { Content } from './component/layout/content';

// TEMPLATES
import template from './application.html';

// VIEWS
import { HomeController } from './view/public/home.controller';
import { ButtonBarController } from './view/public/button-bar.controller';
import { AccountController } from './view/account/account.controller';


@Component({ 
    selector: 'application',
    providers: ['ui.router'],
    directives:[ Navigation, Content],
    template 
})
@StateConfig([
    { name: 'home', url: '/', component: HomeController },
    { name: 'account', url: '/account', component: AccountController }
])
@Inject('$scope', '$state')
export class Application { 
    
    constructor(private $scope, private $state: angular.ui.IStateService) { 
        console.log('application', this);
    }
}