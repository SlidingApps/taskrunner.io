/// <reference path="../../../../typings.d.ts" />

// COMMON
import { Subscription } from 'rxjs';
import { Component, Input, Inject } from 'ng-forward';

// PARTIAL SPECIFICS
import { EventHub } from '../event-hub';
import { Model } from '../model';

@Component({
    selector: 'account-sign-in-button',
    template: `
    <!-- ACCOUNT.GET-STARTED.BUTTON: BEGIN -->
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4">
            <div class="form-group">
                <button type="submit" class="btn btn-orange submit" data-ng-disabled="ctrl.isBusy || ctrl.form.$invalid">Sign in</button>
            </div>
        </div>
    </div>
    <!-- ACCOUNT.GET-STARTED.BUTTON: END -->
    `
})
@Inject(EventHub)
export class Button {
    constructor(private hub: EventHub) { }

    @Input() public model: Model;
    @Input() public form: angular.IFormController;
}
