/// <reference path="../../../../typings.d.ts" />

import 'angular';

import { Module as ServiceModule } from '../../../../service/module';
import { DirectiveFactory as NgModelDirective } from './organization-constraints';

const Module: angular.IModule =
    angular.module('application.view.account.get-started.organization', [
        ServiceModule.name
    ])
        .directive('trOrganizationConstraints', NgModelDirective);

export { Module };
