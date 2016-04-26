/// <reference path="../../../../typings.d.ts" />

// COMMON
import { Component, Inject, Input } from 'ng-forward';

// ANGULAR MODULES
import 'angular-ui-router';

// PARTIAL SPECIFICS
import { Model } from '../model';
import { EventHub } from '../event-hub';
import { AuthorizationService } from '../../../../service/authorization/authorization-service';

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
@Inject('$scope', '$state', AuthorizationService, EventHub)
export class Form {
    constructor(private $scope: ILocalScope, private $state: angular.ui.IStateService, private authorization: AuthorizationService, private hub: EventHub) { }

    @Input() public model: Model;

    private formWatch: any;

    public submit(form: angular.IFormController): void {
        this.authorization
            .signIn(this.model.username, this.model.password)
            .then(() => this.$state.go('home'));
    }

    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
        this.formWatch = this.$scope.$watch(() => this.$scope.form, (current) => this.hub.form$.next(current));
    }

    private ngOnDestroy(): void {
        if (this.formWatch) { this.formWatch(); }
    }
    /* tslint:enable:no-unused-variable */
}
