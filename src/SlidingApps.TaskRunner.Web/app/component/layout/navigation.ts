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
    
    private ngOnInit(): void {
        
    }
    
}