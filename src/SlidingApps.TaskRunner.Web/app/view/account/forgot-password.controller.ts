/// <reference path="../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { Component, Inject } from 'ng-forward';

// TEMPLATE
import template from './forgot-password.html';

// ANGULAR MODULES
import 'angular-ui-router';


@Component({
    selector: 'forgot-password',
    template: template,
    providers: ['ui.router']
})
@Inject('$scope', '$state', '$timeout')
export class ForgotPasswordController {
    
    constructor(private $scope: angular.IScope, private $state: angular.ui.IStateService, private $timeout: angular.ITimeoutService) { 
        console.log('forgot-password', this);
    }
    
    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
        this.$timeout(() => angular.element('#email').focus(), 300);
    }
    
}