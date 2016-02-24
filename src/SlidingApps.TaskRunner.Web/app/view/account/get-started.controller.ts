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
    template: template,
    providers: ['ui.router']
})
@Inject('$scope', '$state', '$timeout')
export class GetStartedController {
    
    constructor(private $scope: angular.IScope, private $state: angular.ui.IStateService, private $timeout: angular.ITimeoutService) { 
        // console.log('get-started', this);
    }
    
    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
        this.$timeout(() => angular.element('#organization').focus(), 300);
    }
    
}
