/// <reference path="../../../typings.d.ts" />

import { Module as OrganizationModule } from './organization/module';


const Module: angular.IModule =
    angular.module('application.view.account.get-started', [
        OrganizationModule.name
    ]);

export { Module };
