/// <reference path="../../../../typings.d.ts" />

// COMMON
import { Component, Inject, Input } from 'ng-forward';

// ANGULAR MODULES
import 'angular-ui-router';

// PARTIAL SPECIFICS
import { Model } from '../model';
import { EventHub } from '../event-hub';
import { ReadModelService } from '../../../../service/read-model/read-model-service';

interface ILocalScope extends angular.IScope {
    form: angular.IFormController;
}

@Component({
    selector: 'account-sign-in-form',
    providers: ['ui.router'],
    template: `
    <!-- ACCOUNT.SIGN-IN.FORM: BEGIN -->
    <div>NEW SIGN IN</div>
    <div class="page-login">
        <div class="loginContentWrap" style="padding: 0;">
            <div class="container-fluid">
                <form name="form" data-ng-submit="ctrl.submit(form)">
                    <data-ng-transclude></data-ng-transclude>
                    <!-- SUBMIT -->
                    <div class="row">
                        <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4">
                            <div class="form-group">
                                <button type="submit" class="btn btn-orange submit" data-ng-disabled="ctrl.isBusy || ctrl.isInvalid || form.$invalid">Sign in</button>
                                <button type="submit" class="btn btn-orange submit" (click)="ctrl.test()">Test</button>
                            </div>
                        </div>
                    </div>
                </form>
                <ul class="more">
                    <li><a data-ui-sref="account.getStarted">Get started</a></li>
                    <li><a data-ui-sref="account.forgotPassword">Forgotten password</a></li>
                </ul>
            </div>
        </div>
    </div>
    <!-- ACCOUNT.SIGN-IN.FORM: END -->
    `
})
@Inject('$scope', ReadModelService, EventHub)
export class Form {
    constructor(private $scope: ILocalScope, private service: ReadModelService, private hub: EventHub) { }

    @Input() public model: Model;

    public submit(form: angular.IFormController): void {
        console.log('form', angular.toJson(form), this.model);
    }

    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
        this.$scope.$watch(() => this.$scope.form, (current) => {
            if (this.hub.form$ && !this.hub.form$.isUnsubscribed) {
                this.hub.form$.next(current);
            }
        });
    }
    /* tslint:enable:no-unused-variable */

    private test() {
        console.log('test', this);
        this.service.getTenantCodeAvailability('demo')
            .then(response => {
                console.log('response', response);
            });
    }
}
