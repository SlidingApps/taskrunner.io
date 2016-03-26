/// <reference path="../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { Subscription } from 'rxjs';
import { ContentHub } from '../../component/layout/content';
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
@Inject('$scope', '$element', '$state', ContentHub)
export class HomeController {

    constructor(private $scope: angular.IScope, private $element: angular.IAugmentedJQuery, private $state: angular.ui.IStateService, private contentHub: ContentHub) {
        console.log('home', this);
    }

    private subscription: Subscription;

    private ngOnInit(): void {
        console.log('ngOnInit', this);
        this.subscription = this.contentHub.change$.filter(x => !!x).distinctUntilChanged().subscribe(x => console.log('change', x));
        this.contentHub.change$.next('home');
    }

    private ngOnDestroy(): void {
        console.log('ngOnDestroy', this);
        this.subscription.unsubscribe();
    }

}
