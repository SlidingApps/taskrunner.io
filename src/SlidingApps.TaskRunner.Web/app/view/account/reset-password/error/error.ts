/// <reference path="../../../../typings.d.ts" />

// COMMON
import { Component, Inject } from 'ng-forward';

// ANGULAR MODULES
import 'angular-ui-router';

// PARTIAL SPECIFICS
import { IStateParams } from '../state-params';
import { WriteModelService } from '../../../../service/write-model/write-model-service';

interface ILocalScope extends angular.IScope {
}

@Component({
    selector: 'account-reset-password-error',
    providers: ['ui.router'],
    template: `
    <!-- ACCOUNT.RESET-PASSWORD.ERROR: BEGIN -->
    <div class="row">
        <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4">
            <div class="text-center">
                <p>
                    <span>
                        <h3>You have to confirm your new account before you can change your password.</h3>
                    </span>
                </p>
            </div>
        </div>
    </div>
    <form name="form" data-ng-submit="ctrl.submit(form)">
        <data-ng-transclude></data-ng-transclude>
        <!-- SUBMIT -->
        <div class="row">
            <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4">
                <div class="form-group">
                    <button type="submit" class="btn btn-orange submit">Send the confirmation link</button>
                </div>
            </div>
        </div>
    </form>
    <!-- ACCOUNT.RESET-PASSWORD.ERROR: END -->
    `
})
@Inject('$scope', '$stateParams', WriteModelService)
export class Error {
    constructor(private $scope: ILocalScope, private parameters: IStateParams, private writeModel: WriteModelService) { }

    public submit(form: angular.IFormController): void {
        this.writeModel.account.postConfirmationLink(this.parameters.username);
    }

    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
    }

    private ngOnDestroy(): void {
    }
    /* tslint:enable:no-unused-variable */
}
