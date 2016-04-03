/// <reference path="../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { Subscription } from 'rxjs';
import { Component, Inject } from 'ng-forward';

// TEMPLATE
import template from './home.html';

// ANGULAR MODULES
import 'angular-ui-router';

@Component({
    selector: 'home',
    template: template,
    providers: ['ui.router']
})
@Inject('$scope', '$element', '$state')
export class HomeController {

    constructor(private $scope: angular.IScope, private $element: angular.IAugmentedJQuery, private $state: angular.ui.IStateService) {
        console.log('home', this);
    }

    private ngOnInit(): void {
        console.log('ngOnInit', this);
    }

    private ngOnDestroy(): void {
        console.log('ngOnDestroy', this);
    }

}
