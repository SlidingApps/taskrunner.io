/// <reference path="../../typings.d.ts" />

// COMMON
import { Component, StateConfig } from 'ng-forward';

// COMPONENTS
import { View as ConfirmTenant } from './confirm-tenant/view';

// ANGULAR MODULES
import 'angular-ui-router';


@Component({
    selector: 'tenant',
    providers: ['ui.router'],
    template: `<div data-ui-view></div>`
})
@StateConfig([
    {
        name: 'tenant.confirm',
        url: '/{id}/confirm',
        component: ConfirmTenant,
        template: '<tenant-confirm />'
    }
])
export class TenantController { }
