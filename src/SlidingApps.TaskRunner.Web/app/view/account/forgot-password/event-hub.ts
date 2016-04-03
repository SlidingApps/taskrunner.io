/// <reference path="../../../typings.d.ts" />

// COMMON
import { BehaviorSubject } from 'rxjs';
import { Injectable } from 'ng-forward';

@Injectable()
export class EventHub {
    public form$: BehaviorSubject<angular.IFormController> = new BehaviorSubject<angular.IFormController>(undefined);
}
