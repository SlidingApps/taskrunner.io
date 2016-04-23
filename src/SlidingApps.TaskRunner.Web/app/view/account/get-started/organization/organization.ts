/// <reference path="../../../../typings.d.ts" />

// COMMON
import { Component, Input, Inject } from 'ng-forward';

// PARTIAL SPECIFICS
import { Model } from '../model';

@Component({
    selector: 'account-get-started-organization',
    template: `
    <!-- ACCOUNT.GET-STARTED.ORGANIZATION: BEGIN -->
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4">
            <div class="form-group" style="margin-bottom: 20px;">
                <input  id="organization" 
                        name="organization" 
                        type="text" 
                        class="form-control simple-form-control" 
                        placeholder="organization" 
                        autocomplete="off"
                        autofocus
                        required
                        tr-organization-constraints
                        organization-is-unique-async-validator
                        data-ng-model="ctrl.model.organization"
                        data-ng-model-options="{ updateOn: 'default blur', debounce: { default: 300, blur: 0 } }"
                        data-ng-minlength="2"/>
                <i class="fa fa-users"></i>
            </div>
        </div>
        <div class="col-lg-4">
            <span ng-show="ctrl.form.organization.$error.minlength" style="color: orangered; font-weight: bold;">Organization name is too short</span>
            <span ng-show="ctrl.form.organization.$error.organizationIsUniqueAsync" style="color: orangered; font-weight: bold;">This name is not available</span>
        </div>
    </div>
    <!-- ACCOUNT.GET-STARTED.ORGANIZATION: END -->
    `
})
@Inject('$timeout')
export class Organization {
    constructor(private $timeout: angular.ITimeoutService) {}

    @Input() public model: Model;
    @Input() public form: angular.IFormController;

    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
        this.$timeout(() => angular.element('#organization').focus(), 300);
    }

    private ngOnDestroy(): void {
        
    }
    /* tslint:enable:no-unused-variable */
}
