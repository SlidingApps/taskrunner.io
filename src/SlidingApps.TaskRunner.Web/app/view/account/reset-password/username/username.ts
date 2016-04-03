/// <reference path="../../../../typings.d.ts" />

// COMMON
import { Component, Input } from 'ng-forward';

// PARTIAL SPECIFICS
import { Model } from '../model';

@Component({
    selector: 'account-reset-password-username',
    template: `
    <!-- USERNAME -->
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4">
            <div class="form-group">
                <input id="email"
                        name="email"
                        type="email"
                        class="form-control simple-form-control"
                        placeholder="email"
                        readonly
                        data-ng-model="ctrl.model.username" />
                <i class="fa fa-envelope"></i>
            </div>
        </div>
    </div>
    `
})
export class Username {
    @Input() public model: Model;
    @Input() public form: angular.IFormController;
}
