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
import { PasswordConfirmation } from './password-confirmation/password-confirmation';

// VIEW SPECIFICS
import { Model } from './model';
import { EventHub } from './event-hub';


@Component({
    selector: 'account-reset-password',
    providers: [FoundationModule.name],
    directives: [ Form, Username, Password, PasswordConfirmation ],
    template: `
    <!-- ACCOUNT GET STARTED -->
    <account-reset-password-form [(model)]="ctrl.model">
        <account-reset-password-username [form]="ctrl.form" [(model)]="ctrl.model"></account-reset-password-username>
        <account-reset-password-password [form]="ctrl.form" [(model)]="ctrl.model"></account-reset-password-password>
        <account-reset-password-password-confirmation [form]="ctrl.form" [(model)]="ctrl.model"></account-reset-password-password-confirmation>
    </account-reset-password-form>
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
