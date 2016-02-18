/// <reference path="../../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { Component, Inject } from 'ng-forward';

// TEMPLATE
import template from './content.html';

@Component({ 
  selector: 'content', 
  template,
})
@Inject('$scope', '$http')
export class Content {
    
    constructor(private $scope: ng.IRootScopeService, private $http: angular.IHttpService) { }
    
}