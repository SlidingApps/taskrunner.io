/// <reference path="../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { Component, Inject } from 'ng-forward';

// TEMPLATE
import template from './home.html';

// ANGULAR MODULES
import 'angular-ui-router';


@Component({
    selector: 'home',
    template,
    providers: ['ui.router'],
})
@Inject('$scope', '$state')
export class HomeController {
    
    constructor(private $scope: ng.IRootScopeService, private $state: angular.ui.IStateService) { 
        console.log('home', this);
    }
    
}