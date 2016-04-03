/// <reference path="../../../../typings.d.ts" />

// COMMON
import { Component, Input } from 'ng-forward';

// PARTIAL SPECIFICS
import { Model } from '../model';

@Component({
    selector: 'account-sign-in-password',
    template: `
    <!-- PASSWORD -->
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4">
            <div class="form-group">
                <input  id="password" 
                        name="password"
                        type="password" 
                        class="form-control simple-form-control" 
                        placeholder="password" 
                        required
                        data-ng-model="ctrl.model.password" />
                <i class="fa fa-lock"></i>
            </div>
        </div>
    </div>
    `
})
export class Password {
    @Input() public model: Model;
    @Input() public form: angular.IFormController;
}
