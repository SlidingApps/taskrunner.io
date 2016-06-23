/// <reference path="../../../typings.d.ts" />

// COMMON
import * as angular from 'angular';
import { BehaviorSubject, Observable } from 'rxjs';
import { Injectable } from 'ng-forward';

@Injectable()
export class EventHub {
    public form$: BehaviorSubject<angular.IFormController> = new BehaviorSubject<angular.IFormController>(undefined);

    public dirty$: Observable<any> =
        Observable
            .combineLatest(this.form$, Observable.interval(5000))
            .map(([x]: [BehaviorSubject<angular.IFormController>]) => x)
            .filter(x => !!x)
            .map(x => { return {form: x, dirty: x.$dirty}; })
            .distinctUntilChanged()
            .share();

    public password$: BehaviorSubject<string> = new BehaviorSubject<string>(undefined);
    public passwordConfirmation$: BehaviorSubject<string> = new BehaviorSubject<string>(undefined);

    public passwordEquality$: Observable<boolean> =
        Observable
            .combineLatest(this.password$, this.passwordConfirmation$)
            .map(([password, passwordConfirmation]: [string, string]) => {
                if (password === undefined || passwordConfirmation === undefined) { return false; }

                return password === passwordConfirmation;
            })
            .share();

    public formValid$: Observable<boolean> =
        Observable
            .combineLatest(this.passwordEquality$)
            .map(([passwordEquality]: [boolean]) => {
                return passwordEquality;
            })
            .share();
}
