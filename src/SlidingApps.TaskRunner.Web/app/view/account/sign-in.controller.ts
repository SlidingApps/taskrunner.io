/// <reference path="../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { Component, Inject } from 'ng-forward';

// TEMPLATE
import template from './sign-in.html';

// ANGULAR MODULES
import 'angular-ui-router';


@Component({
    selector: 'signin',
    template,
    providers: ['ui.router'],
})
@Inject('$scope', '$state')
export class SignInController {
    
    constructor(private $scope: ng.IRootScopeService, private $state: angular.ui.IStateService) { 
        console.log('signin', this);
    }
    
}