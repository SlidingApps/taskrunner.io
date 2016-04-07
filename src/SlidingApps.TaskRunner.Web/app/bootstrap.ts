/// <reference path="./typings.d.ts" />

// COMMON
import 'angular';
import 'reflect-metadata';
import { bootstrap } from 'ng-forward';

// APPLICATION
import { Application } from './application.ts';

// ANGULAR MODULES
import 'angular-ui-router';
import 'angular-loading-bar';
import ConstantModule from './constant';
import { Module as ViewModule } from './view/module';

// STYLING
import './vendor/bootstrap/style/bootstrap.min.css';
import './vendor/application/less/application.less';
import './vendor/sharpen/fonts/material-design-iconic-font/css/material-design-iconic-font.min.css';


const ApplicationConfigModule: any = angular.module('application.config', [ConstantModule.name])
    .config(['$locationProvider', '$urlRouterProvider', ($locationProvider: angular.ILocationProvider, $urlRouterProvider: angular.ui.IUrlRouterProvider) => {
        $locationProvider.html5Mode(false).hashPrefix();
        $urlRouterProvider.otherwise('/');
    }])
    .config(['cfpLoadingBarProvider', (loadingBarProvider: angular.loadingBar.ILoadingBarProvider) => {
        loadingBarProvider.includeSpinner = false;
    }])
    ;
    
// BOOTSTRAP APPLICATION
bootstrap(Application, [
    'ui.router', 
    'angular-loading-bar',
    ConstantModule.name, 
    ApplicationConfigModule.name, 
    ViewModule.name
]);
