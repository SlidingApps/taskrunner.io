/// <reference path="../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { Component, Inject } from 'ng-forward';

// TEMPLATE
import template from './reset-password.html';

// ANGULAR MODULES
import 'angular-ui-router';


@Component({
    selector: 'reset-password',
    template: template,
    providers: ['ui.router']
})
@Inject('$scope', '$state', '$timeout')
export class ResetPasswordController {
    
    constructor(private $scope: angular.IScope, private $state: angular.ui.IStateService, private $timeout: angular.ITimeoutService) { 
        // console.log('get-started', this);
    }
    
    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
        this.$timeout(() => angular.element('#new-password').focus(), 300);
    }
    
}
