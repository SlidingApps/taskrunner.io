/// <reference path="../../../../typings.d.ts" />

// COMMON
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
    selector: 'account-forgot-password-form',
    providers: ['ui.router'],
    template: `
    <!-- ACCOUNT.FORGOT-PASSWORD.FORM: BEGIN -->
    <div class="page-login">
        <div class="loginContentWrap" style="padding: 0;">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4">
                        <div class="text-center">
                            <p>Enter your email address or username and we'll send you a link to reset your password.</p>
                        </div>
                    </div>
                </div>
                <form name="form" data-ng-submit="ctrl.submit(form)">
                    <data-ng-transclude></data-ng-transclude>
                </form>
                <ul class="more">
                    <li><a data-ui-sref="account.getStarted">Get started</a></li>
                    <li>Allready have an account? Sign in <a data-ui-sref="account.signin">here</a>.</li>
                </ul>
            </div>
        </div>
    </div>
    <!-- ACCOUNT.FORGOT-PASSWORD.FORM: END -->
    `
})
@Inject('$scope', EventHub)
export class Form {
    constructor(private $scope: ILocalScope, private hub: EventHub) { }

    @Input() public model: Model;

    public submit(form: angular.IFormController): void {
        console.log('form', angular.toJson(form), this.model);
    }

    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
        this.$scope.$watch(() => this.$scope.form, (current) => this.hub.form$.next(current));
    }
    /* tslint:enable:no-unused-variable */
}
