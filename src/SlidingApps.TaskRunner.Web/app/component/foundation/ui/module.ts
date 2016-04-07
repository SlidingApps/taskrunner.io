/// <reference path="../../../typings.d.ts" />

import { Module as InputModule } from './input/module';

const Module: angular.IModule =
    angular.module('taskrunner-foundation-ui', [
        InputModule.name
    ]);

export { Module };
