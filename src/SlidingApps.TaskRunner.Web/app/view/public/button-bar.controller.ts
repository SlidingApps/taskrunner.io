/// <reference path="../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { Component, Inject } from 'ng-forward';

// TEMPLATE
import template from './button-bar.html';

// ANGULAR MODULES
import 'angular-ui-router';


@Component({
    selector: 'button-bar',
    template,
    providers: ['ui.router'],
})
@Inject('$scope', '$state')
export class ButtonBarController {
    
    constructor(private $scope: ng.IRootScopeService, private $state: angular.ui.IStateService) { 
        console.log('button-bar', this);
    }
    
}