/// <reference path="../../../typings.d.ts" />

import 'angular';

import { DirectiveFactory as SelectOnFocus } from './select-on-focus';

const Module: angular.IModule = angular.module('application.component.ui.input', [])
    .directive('input', SelectOnFocus);

export { Module };
