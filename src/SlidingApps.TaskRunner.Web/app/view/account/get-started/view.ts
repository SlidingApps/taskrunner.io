/// <reference path="../../../typings.d.ts" />

// COMMON
import { Subscription } from 'rxjs';
import { Component, Inject } from 'ng-forward';

// FOUNDATION
import { Module as FoundationModule } from '../../../component/module';

// DIRECTIVES
import { Form } from './form/form';
import { Organization } from './organization/organization';
import { Username } from './username/username';
import { Password } from './password/password';
import { PasswordConfirmation } from './password-confirmation/password-confirmation';
import { Button } from './button/button';

// VIEW SPECIFICS
import { Model } from './model';
import { EventHub } from './event-hub';


@Component({
    selector: 'account-get-started',
    providers: [FoundationModule.name],
    directives: [ Form, Organization, Username, Password, PasswordConfirmation, Button ],
    template: `
    <!-- ACCOUNT GET STARTED: BEGIN -->
    <account-get-started-form [(model)]="ctrl.model">
        <account-get-started-organization [form]="ctrl.form" [(model)]="ctrl.model"></account-get-started-organization>
        <account-get-started-username [form]="ctrl.form" [(model)]="ctrl.model"></account-get-started-username>
        <account-get-started-password [form]="ctrl.form" [(model)]="ctrl.model"></account-get-started-password>
        <account-get-started-password-confirmation [form]="ctrl.form" [(model)]="ctrl.model"></account-get-started-password-confirmation>
        <account-get-started-button [form]="ctrl.form" [(model)]="ctrl.model"></account-get-started-button>
    </account-get-started-form>
    <!-- ACCOUNT GET STARTED: END -->
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
