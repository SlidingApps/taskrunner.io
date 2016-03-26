/// <reference path="../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { BehaviorSubject } from 'rxjs';
import { Component, Injectable, Inject } from 'ng-forward';

// TEMPLATE
import template from './content.html';

@Injectable()
export class ContentHub {
    public change$: BehaviorSubject<string> = new BehaviorSubject<string>(undefined);
}

@Component({
  selector: 'content',
  template: template
})
@Inject('$scope', '$http', ContentHub)
export class Content {

    constructor(private $scope: angular.IScope, private $http: angular.IHttpService, private content: ContentHub) {
        console.log('content', this);
    }

    private ngOnInit(): void {
        console.log('ngOnInit', this);
        this.content.change$.next('content');
    }

    private ngOnDestroy(): void {
        console.log('ngOnDestroy', this);
        this.content.change$.complete();
    }
}
