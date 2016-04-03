/// <reference path="../../../../typings.d.ts" />

// COMMON
import { Subscription } from 'rxjs';
import { Component, Input, Inject } from 'ng-forward';

// PARTIAL SPECIFICS
import { Model } from '../model';
import { EventHub } from '../event-hub';

@Component({
    selector: 'account-reset-password-password-confirmation',
    template: `
    <!-- PASSWORD CONFIRMATION -->
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4">
            <div class="form-group">
                <input  id="password-confimation" 
                        name="passwordConfirmation"
                        type="password" 
                        class="form-control simple-form-control" 
                        placeholder="confirm your new password" 
                        required
                        data-ng-minlength="4"
                        data-ng-model="ctrl.model.passwordConfirmation"
                        data-ng-model-options="{ updateOn: 'default blur', debounce: { default: 1000, blur: 0 } }"
                        data-ng-change="ctrl.changed()"
                        tr-password-equality />
                <i class="fa fa-lock"></i>
            </div>
        </div>
        <div class="col-lg-4">
            <span ng-show="!ctrl.validConfirmation && ctrl.model.passwordConfirmation" style="color: orangered; font-weight: bold;">Confirmation is not valid</span>
            <span ng-show="ctrl.form.password.$error.test">The value is not a valid integer!</span>
        </div>
    </div>
    `
})
@Inject(EventHub)
export class PasswordConfirmation {
    constructor(private hub: EventHub) { }

    @Input() public model: Model;
    @Input() public form: angular.IFormController;

    public validConfirmation: boolean = false;

    private validator: Subscription;

    public changed(): void {
        this.hub.passwordConfirmation$.next(this.model.passwordConfirmation);
    }

    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
        this.validator = this.hub.passwordEquality$.subscribe(valid => this.validConfirmation = valid);
    }

    private ngOnDestroy(): void {
        if (this.validator) { this.validator.unsubscribe(); }
    }
    /* tslint:enable:no-unused-variable */
}
