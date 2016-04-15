/// <reference path="../../../typings.d.ts" />

// COMMON
import { Subscription } from 'rxjs';
import { Component, Inject } from 'ng-forward';

// FOUNDATION
import { Module as ComponentModule } from '../../../component/module';

// DIRECTIVES
import { Form } from './form/form';
import { Username } from './username/username';

// VIEW SPECIFICS
import { Model } from './model';
import { EventHub } from './event-hub';


@Component({
    selector: 'account-forgot-password',
    providers: [ComponentModule.name],
    directives: [ Form, Username],
    template: `
    <!-- ACCOUNT FORGOT PASSWORD -->
    <account-forgot-password-form [(model)]="ctrl.model">
        <account-forgot-password-username [form]="ctrl.form" [(model)]="ctrl.model"></account-forgot-password-username>
    </account-forgot-password-form>
    `
})
@Inject(EventHub)
export class View {
    constructor(private hub: EventHub) { }

    public model: Model = new Model();
    public form: angular.IFormController;

    private subscription: Subscription;

    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
        this.subscription = this.hub.form$.filter(x => !!x).distinctUntilChanged().subscribe(x => this.form = x);
    }

    private ngOnDestroy(): void {
        if (this.subscription && !this.subscription.isUnsubscribed) { this.subscription.unsubscribe(); }
    }
    /* tslint:enable:no-unused-variable */
}
