/// <reference path="../../../typings.d.ts" />

// COMMON
import { Subscription } from 'rxjs';
import { Component, Inject } from 'ng-forward';

// ANGULAR MODULES
import 'angular-ui-router';

// FOUNDATION
import { Module as FoundationModule } from '../../../component/module';
import { ApplicationErrors, ErrorCode } from '../../../component/foundation/application-error';

// DIRECTIVES
import { View } from '../view';
import { Form } from './form/form';
import { Username } from './username/username';
import { Password } from './password/password';
import { PasswordConfirmation } from './password-confirmation/password-confirmation';
import { Error } from './error/error';

// VIEW SPECIFICS
import { IStateParams } from './state-params';
import { Model } from './model';
import { EventHub } from './event-hub';
import { ReadModelService } from '../../../service/read-model/read-model-service';
import { DecryptedLink } from '../../../service/authorization/account/decrypted-link';


@Component({
    selector: 'account-reset-password',
    providers: [FoundationModule.name],
    directives: [ View, Form, Username, Password, PasswordConfirmation, Error ],
    template: `
    <!-- ACCOUNT GET STARTED -->
    <account-view>
        <account-reset-password-form [(model)]="ctrl.model" data-ng-if="ctrl.model.isReady && !ctrl.model.error">
                <account-reset-password-username [form]="ctrl.form" [(model)]="ctrl.model"></account-reset-password-username>
                <account-reset-password-password [form]="ctrl.form" [(model)]="ctrl.model"></account-reset-password-password>
                <account-reset-password-password-confirmation [form]="ctrl.form" [(model)]="ctrl.model"></account-reset-password-password-confirmation>
        </account-reset-password-form>
        <account-reset-password-error [(model)]="ctrl.model" data-ng-if="ctrl.model.isReady && !!ctrl.model.error"></account-reset-password-error>
    </account-view>
    `
})
@Inject(EventHub, '$stateParams', ReadModelService)
export class View {
    constructor(private hub: EventHub, private parameters: IStateParams, private readModel: ReadModelService) { }

    public model: Model = new Model();
    public form: angular.IFormController;

    private subscription: Subscription;

    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
        this.subscription = this.hub.form$.filter(x => !!x).distinctUntilChanged().subscribe(x => this.form = x);
        this.readModel.account
            .decryptLink(this.parameters.username, this.parameters.link)
            .then((response: DecryptedLink) => {
                this.model.username = response.username;
            })
            .catch(reason => {
                this.model.error = ApplicationErrors.GetErrorInfo(reason.message);
                switch (this.model.error.code) {
                    case ErrorCode.D8D500AE:
                        break;

                    default:
                        break;
                }
            })
            .finally(() => this.model.isReady = true);
    }

    private ngOnDestroy(): void {
        if (this.subscription && !this.subscription.isUnsubscribed) { this.subscription.unsubscribe(); }
    }
    /* tslint:enable:no-unused-variable */
}
