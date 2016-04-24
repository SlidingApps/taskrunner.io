/// <reference path="../../../typings.d.ts" />

// COMMON
import { Subscription } from 'rxjs';
import { Component, Inject } from 'ng-forward';

// FOUNDATION
import { Module as FoundationModule } from '../../../component/module';

// DIRECTIVES
import { Form } from './form/form';
import { Username } from './username/username';
import { Password } from './password/password';
import { Button } from './button/button';

// VIEW SPECIFICS
import { Model } from './model';
import { EventHub } from './event-hub';


@Component({
    selector: 'account-sign-in',
    providers: [FoundationModule.name],
    directives: [ Form, Username, Password, Button],
    template: `
    <!-- ACCOUNT SIGN IN -->
    <account-sign-in-form [(model)]="ctrl.model">
        <account-sign-in-username [form]="ctrl.form" [(model)]="ctrl.model"></account-sign-in-username>
        <account-sign-in-password [form]="ctrl.form" [(model)]="ctrl.model"></account-sign-in-password>
        <account-sign-in-button [form]="ctrl.form" [(model)]="ctrl.model"></account-sign-in-button>
    </account-sign-in-form>
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
        this.model.$destroy();
    }
    /* tslint:enable:no-unused-variable */
}
