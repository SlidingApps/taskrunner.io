/// <reference path="./typings.d.ts" />

// COMMON
import 'angular';
import 'reflect-metadata';
import { bootstrap } from 'ng-forward';

// APPLICATION
import { Application } from './application.controller';

// ANGULAR MODULES
import 'angular-ui-router';
import 'angular-loading-bar';
import ConstantModule from './constant';

// STYLING
import './vendor/bootstrap/style/bootstrap.min.css';
import './vendor/sharpen/css/app.min.css';
import './vendor/sharpen/fonts/material-design-iconic-font/css/material-design-iconic-font.min.css'


let ApplicationConfig = angular.module('application.config', [ConstantModule.name])
    .config(['$locationProvider', '$urlRouterProvider', ($locationProvider, $urlRouterProvider) => {
        $locationProvider.html5Mode(false).hashPrefix();
        $urlRouterProvider.otherwise('/');
    }])
    .config(['cfpLoadingBarProvider', (cfpLoadingBarProvider) => {
        cfpLoadingBarProvider.includeSpinner = false;
    }])
    ;
    
// BOOTSTRAP APPLICATION
bootstrap(Application, ['ui.router', 'angular-loading-bar', ConstantModule.name, ApplicationConfig.name]);