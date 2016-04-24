/// <reference path="./typings.d.ts" />

// COMMON
import 'angular';
import 'reflect-metadata';
import { bootstrap } from 'ng-forward';

// APPLICATION
import { Application } from './application/application.ts';

// ANGULAR MODULES
import 'angular-ui-router';
import 'angular-loading-bar';
import { Module as ConstantModule } from './constant';
import { Module as ViewModule } from './view/module';

// STYLING
import './vendor/bootstrap/style/bootstrap.min.css';
import './vendor/application/less/application.less';
import './vendor/sharpen/fonts/material-design-iconic-font/css/material-design-iconic-font.min.css';


const ApplicationConfigModule: angular.IModule =
    angular.module('application.config', [ConstantModule.name])
        .config(['$compileProvider', ($compileProvider: angular.ICompileProvider) => {
            $compileProvider.debugInfoEnabled(false);
        }])
        .config(['$logProvider', ($logProvider: angular.ILogProvider) => {
            $logProvider.debugEnabled(true);
        }])
        .config(['$locationProvider', '$urlRouterProvider', ($locationProvider: angular.ILocationProvider, $urlRouterProvider: angular.ui.IUrlRouterProvider) => {
            $locationProvider.html5Mode(false).hashPrefix();
            $urlRouterProvider.otherwise('/');
        }])
        .config(['cfpLoadingBarProvider', (loadingBarProvider: angular.loadingBar.ILoadingBarProvider) => {
            loadingBarProvider.latencyThreshold = 500;
            loadingBarProvider.includeSpinner = false;
        }])
        .config(['$provide', '$logProvider', ($provide, $logProvider) => {
            $provide.decorator('$log', ['$delegate', $delegate => {
                let debug: any = $delegate.debug;
                $delegate.debug = () => {
                    if ($logProvider.debugEnabled()) {
                        let args: any = [].slice.call(arguments);
                        let now: string = new Date().toISOString().substr(11, 12);

                        args.unshift('DEBUG');
                        args.unshift(now);
                        debug.apply(undefined, args);
                    }
                };

                let info: any = $delegate.info;
                $delegate.info = () => {
                    if ($logProvider.debugEnabled()) {
                        let args: any = [].slice.call(arguments);
                        let now: string = new Date().toISOString().substr(11, 12);

                        args.unshift('INFO ');
                        args.unshift(now);
                        info.apply(undefined, args);
                    }
                };

                return $delegate;
            }]);
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
