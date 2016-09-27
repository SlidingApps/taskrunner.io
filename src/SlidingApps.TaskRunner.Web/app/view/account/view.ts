/// <reference path="../../typings.d.ts" />

// COMMON
import { Component } from 'ng-forward';

// ANGULAR MODULES
import 'angular-ui-router';

// FOUNDATION
import { Module as FoundationModule } from '../../component/module';

@Component({
    selector: 'account-view',
    providers: [FoundationModule.name],
    directives: [ ],
    template: `
    <!-- ACCOUNT: BEGIN -->
    <div class="page-login">
        <div class="loginContentWrap" style="padding: 0;">
            <div class="container-fluid">
                <data-ng-transclude></data-ng-transclude>
            </div>
        </div>
    </div>
    <!-- ACCOUNT: END -->
    `
})
export class View {
}
