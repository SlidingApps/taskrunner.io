/// <reference path="../../typings.d.ts" />

import 'angular';

import { Module as UIModule } from './ui/module';

const Module: angular.IModule = 
    angular.module('taskrunner-foundation', [
        UIModule.name
    ]);

export { Module };
