/// <reference path="../../../../typings.d.ts" />

import 'angular';

import { DirectiveFactory as SelectOnFocus } from './select-on-focus';

const Module: angular.IModule = angular.module('taskrunner-foundation-ui-input', [])
    .directive('input', SelectOnFocus);

export { Module };
