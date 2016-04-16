/// <reference path="../../typings.d.ts" />

import { RestServiceProvider } from './rest-service';

const Module: angular.IModule =
    angular.module('application.service.rest', [])
        .provider('restService',  RestServiceProvider);

export { Module };
