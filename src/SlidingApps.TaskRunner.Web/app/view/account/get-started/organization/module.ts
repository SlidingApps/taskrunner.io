/// <reference path="../../../../typings.d.ts" />

import 'angular';

import { DirectiveFactory as NgModelDirective } from './organization-constraints';

const Module: angular.IModule =
    angular.module('taskrunner-view-account-get-started-organization', [])
        .directive('trOrganizationConstraints', NgModelDirective);

export { Module };
