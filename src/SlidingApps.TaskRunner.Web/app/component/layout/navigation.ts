/// <reference path="../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { Component, Inject, Input, Output, EventEmitter } from 'ng-forward';

// TEMPLATE
import template from './navigation.html';


@Component({ 
  selector: 'public-navigation', 
  template,
})
@Inject('$scope', '$state', '$stateParams')
export class Navigation {
    
    constructor(private $scope: ng.IRootScopeService, private $state: angular.ui.IStateService) { }
    
    public onGetStarted(): void {
        this.$state.go('account.getStarted');
    }

    public onSignIn(): void {
        this.$state.go('account.signin');
    }
    
    private ngOnInit(): void { 
        
    }
    
}