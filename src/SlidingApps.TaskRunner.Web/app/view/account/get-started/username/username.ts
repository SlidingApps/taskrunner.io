/// <reference path="../../../../typings.d.ts" />

// COMMON
import { Component, Input } from 'ng-forward';

// PARTIAL SPECIFICS
import { Model } from '../model';

@Component({
    selector: 'account-get-started-username',
    template: `
    <!-- USERNAME: BEGIN -->
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4">
            <div class="form-group">
                <input id="email"
                        name="email"
                        type="email"
                        class="form-control simple-form-control"
                        placeholder="email"
                        autocomplete="off"
                        required
                        data-ng-model="ctrl.model.username"
                        data-ng-model-options="{ updateOn: 'default blur', debounce: { default: 1000, blur: 0 } }"
                        data-ng-minlength="6" />
                <i class="fa fa-envelope"></i>
            </div>
        </div>
        <div class="col-lg-4">
            <span ng-show="ctrl.form.email.$error.minlength" style="color: orangered; font-weight: bold;">Username is too short</span>
        </div>
    </div>
    <!-- USERNAME: END -->
    `
})
export class Username {
    @Input() public model: Model;
    @Input() public form: angular.IFormController;
}
