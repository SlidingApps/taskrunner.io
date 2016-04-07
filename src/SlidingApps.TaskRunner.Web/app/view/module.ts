/// <reference path="../typings.d.ts" />

import { Module as AccountModule } from './account/module';

const Module: angular.IModule =
    angular.module('taskrunner-view', [
        AccountModule.name
    ]);

export { Module };
