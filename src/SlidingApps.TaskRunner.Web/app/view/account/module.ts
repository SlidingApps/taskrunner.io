/// <reference path="../../typings.d.ts" />

import { Module as GetStartedModule } from './get-started/module';

const Module: angular.IModule =
    angular.module('application.view.account', [
        GetStartedModule.name
    ]);

export { Module };
