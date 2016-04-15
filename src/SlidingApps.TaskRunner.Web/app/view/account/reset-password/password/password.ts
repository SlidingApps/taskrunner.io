/// <reference path="../../../../typings.d.ts" />

// COMMON
import { Component, Input, Inject } from 'ng-forward';

// PARTIAL SPECIFICS
import { Model } from '../model';
import { EventHub } from '../event-hub';

@Component({
    selector: 'account-reset-password-password',
    template: `
    <!-- ACCOUNT.RESET-PASSWORD.PASSWORD: BEGIN -->
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4">
            <div class="form-group">
                <input  id="password" 
                        name="password"
                        type="password" 
                        class="form-control simple-form-control" 
                        placeholder="your new password" 
                        required
                        data-ng-minlength="4"
                        data-ng-model="ctrl.model.password"
                        data-ng-model-options="{ updateOn: 'default blur', debounce: { default: 1000, blur: 0 } }"
                        data-ng-change="ctrl.changed()"/>
                <i class="fa fa-lock"></i>
            </div>
        </div>
        <div class="col-lg-4">
            <span ng-show="ctrl.form.password.$error.minlength" style="color: orangered; font-weight: bold;">Password is too short</span>
        </div>
    </div>
    <!-- ACCOUNT.RESET-PASSWORD.PASSWORD: END -->
    `
})
@Inject('$timeout', EventHub)
export class Password {
    constructor(private $timeout: angular.ITimeoutService, private hub: EventHub) { }

    @Input() public model: Model;
    @Input() public form: angular.IFormController;

    public changed(): void {
        this.hub.password$.next(this.model.password);
    }

    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
        this.$timeout(() => angular.element('#password').focus(), 300);
    }
    /* tslint:enable:no-unused-variable */
}
