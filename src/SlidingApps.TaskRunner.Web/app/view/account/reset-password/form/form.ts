/// <reference path="../../../../typings.d.ts" />

// COMMON
import { Subscription } from 'rxjs';
import { Component, Inject, Input } from 'ng-forward';

// ANGULAR MODULES
import 'angular-ui-router';

// PARTIAL SPECIFICS
import { Model } from '../model';
import { EventHub } from '../event-hub';

interface ILocalScope extends angular.IScope {
    form: angular.IFormController;
}

@Component({
    selector: 'account-reset-password-form',
    providers: ['ui.router'],
    template: `
    <!-- FORM -->
    <div class="page-login">
        <div class="loginContentWrap" style="padding: 0;">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4">
                        <div class="text-center">
                            <p>Welcome back, Peter. You can can enter a new password for your account.</p>
                        </div>
                    </div>
                </div>
                <form name="form" data-ng-submit="ctrl.submit(form)">
                    <data-ng-transclude></data-ng-transclude>
                    <!-- SUBMIT -->
                    <div class="row">
                        <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4">
                            <div class="form-group">
                                <button type="submit" class="btn btn-orange submit" data-ng-disabled="ctrl.isBusy || ctrl.isInvalid || form.$invalid">Save the new password</button>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
    `
})
@Inject('$scope', EventHub)
export class Form {
    constructor(private $scope: ILocalScope, private hub: EventHub) { }

    @Input() public model: Model;
    public isInvalid: boolean = false;
    private validator: Subscription;

    public submit(form: angular.IFormController): void {
        console.log('form', angular.toJson(form), this.model);
    }

    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
        this.$scope.$watch(() => this.$scope.form, (current) => this.hub.form$.next(current));
        this.validator = this.hub.formValid$.subscribe(valid => this.isInvalid = !valid);
    }

    private ngOnDestroy(): void {
        if (this.validator) { this.validator.unsubscribe(); }
    }
    /* tslint:enable:no-unused-variable */
}
