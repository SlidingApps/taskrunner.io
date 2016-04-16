/// <reference path="../../typings.d.ts" />

import { Module as RestModule } from '../rest/module';
import { ReadModelServiceProvider } from './read-model-service';

const Module: angular.IModule =
    angular.module('application.service.read-model', [
        RestModule.name
    ])
        .provider('readModelService',  ReadModelServiceProvider);

export { Module };
