/// <reference path="../../../typings.d.ts" />

// COMMON
import { Component, Inject } from 'ng-forward';

// FOUNDATION
import { AuthorizationService } from '../../../service/authorization/authorization-service';

@Component({
    selector: 'tenant-confirm',
    template: '<div></div>'
})
@Inject(AuthorizationService)
export class View {
    constructor(private authorization: AuthorizationService) { }

    /* tslint:disable:no-unused-variable */
    private ngOnInit(): void {
        console.log('confirm', this);
        // this.authorization.signOut();
    }
    /* tslint:enable:no-unused-variable */
}
