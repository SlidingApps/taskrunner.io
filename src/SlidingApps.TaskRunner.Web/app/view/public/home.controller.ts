/// <reference path="../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { Component, Inject } from 'ng-forward';
import * as _ from 'lodash';

// TEMPLATE
import template from './home.html';

// ANGULAR MODULES
import 'angular-ui-router';


@Component({
    selector: 'home',
    template: template,
    providers: ['ui.router']
})
@Inject('$scope', '$state')
export class HomeController {
    
    constructor(private $scope: angular.IScope, private $state: angular.ui.IStateService) {
        // console.log('home', this);
        
        let quickcardInfoSet: Array<{label: string, value: string}> = [{label: 'test', value: 'TEST'}, { label: 'hello', value: 'world'}, { label: 'hello', value: 'heaven'}];
        let info: any = _.partition(quickcardInfoSet, { 'label': 'test' });
        
        console.log('info', info);
    }
    
}
