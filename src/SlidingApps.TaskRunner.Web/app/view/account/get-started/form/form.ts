/// <reference path="../../../../typings.d.ts" />

// COMMON
import { Component, Inject, Input } from 'ng-forward';

// ANGULAR MODULES
import 'angular-ui-router';

// PARTIAL SPECIFICS
import { Model } from '../model';
import { ICreateTenantPayload  } from '../../../../service/write-model/tenant/create-tenant';
import { EventHub } from '../event-hub';
import { WriteModelService  } from '../../../../service/write-model/write-model-service';

interface ILocalScope extends angular.IScope {
    form: angular.IFormController;
}

@Component({
    selector: 'account-get-started-form',
    providers: ['ui.router'],
    template: `
    <!-- ACCOUNT.GET-STARTED.FORM: BEGIN -->
    <div class="page-login">
        <div class="loginContentWrap" style="padding: 0;">
            <div class="container-fluid">
                <form name="form" data-ng-submit="ctrl.submit(form)">
                    <data-ng-transclude></data-ng-transclude>
                </form>
                <ul class="more">
                    <li>Allready have an account? Sign in <a data-ui-sref="account.signin">here</a>.</li>
                </ul>
            </div>
        </div>
    </div>
    <!-- ACCOUNT.GET-STARTED.FORM: END -->
    `
})
@Inject('$scope', EventHub, WriteModelService)
export class Form {
    constructor(private $scope: ILocalScope, private hub: EventHub, private writeModel: WriteModelService) { }

    @Input() public model: Model;

    private formWatch: any;

    public submit(form: angular.IFormController): void {
        let payload: ICreateTenantPayload = this.model.$toCreateTenant();
        this.writeModel.tenant.postCreateTenant(payload)
            .then(response => console.log('response', response))
            .catch(reason => console.log('reason', reason));
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
