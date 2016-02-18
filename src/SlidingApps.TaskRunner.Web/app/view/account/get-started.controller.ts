/// <reference path="../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { Component, Inject } from 'ng-forward';

// TEMPLATE
import template from './get-started.html';

// ANGULAR MODULES
import 'angular-ui-router';


@Component({
    selector: 'get-started',
    template,
    providers: ['ui.router'],
})
@Inject('$scope', '$state', '$timeout')
export class GetStartedController {
    
    constructor(private $scope: ng.IRootScopeService, private $state: angular.ui.IStateService, private $timeout: ng.ITimeoutService) { 
        console.log('get-started', this);
    }
    
    private ngOnInit(): void {
        this.$timeout(() => angular.element('#email').focus(), 300);
    }
    
}