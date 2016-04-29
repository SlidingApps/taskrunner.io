/// <reference path="../../../../typings.d.ts" />

// COMMON
import { Component, Input, Inject } from 'ng-forward';

// PARTIAL SPECIFICS
import { Model } from '../model';

@Component({
    selector: 'account-forgot-password-username',
    template: `
    <!-- ACCOUNT.FORGOT-PASSWORD.USERNAME: BEGIN -->
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4">
            <div class="form-group">
                <input id="email"
                        name="email"
                        type="text"
                        class="form-control simple-form-control"
                        placeholder="email or username"
                        autocomplete="off"
                        required
                        data-ng-model="ctrl.model.username" 
                        data-ng-minlength="6" />
                <i class="fa fa-envelope"></i>
            </div>
        </div>
    </div>
    <!-- ACCOUNT.FORGOT-PASSWORD.USERNAME: END -->
    `
})
@Inject('$timeout')
export class Username {
    constructor(private $timeout: angular.ITimeoutService) {}

    @Input() public model: Model;
    @Input() public form: angular.IFormController;

    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
        this.$timeout(() => angular.element('#email').focus(), 300);
    }
    /* tslint:enable:no-unused-variable */
}
