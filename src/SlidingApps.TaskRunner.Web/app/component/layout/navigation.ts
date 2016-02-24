/// <reference path="../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { Component, Inject } from 'ng-forward';

// TEMPLATE
import template from './navigation.html';


@Component({ 
  selector: 'public-navigation', 
  template: template
})
@Inject('$scope', '$state', '$stateParams')
export class Navigation {
    
    constructor(private $scope: angular.IScope, private $state: angular.ui.IStateService) { }
    
    public onGotoGetStarted(): void {
        this.$state.go('account.getStarted');
    }

    public onGotoSignIn(): void {
        this.$state.go('account.signin');
    }
    
}
