/// <reference path="../typings.d.ts" />

import { Module as ReadModelModule } from './read-model/module';

const Module: angular.IModule =
    angular.module('application.service', [
        ReadModelModule.name
    ]);

export { Module };
