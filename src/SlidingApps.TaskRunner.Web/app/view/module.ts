/// <reference path="../typings.d.ts" />

import { Module as AccountModule } from './account/module';

const Module: angular.IModule =
    angular.module('application.view', [
        AccountModule.name
    ]);

export { Module };
