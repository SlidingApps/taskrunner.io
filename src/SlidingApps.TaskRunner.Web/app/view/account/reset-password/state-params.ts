/// <reference path="../../../typings.d.ts" />

// ANGULAR MODULES
import 'angular-ui-router';

export interface IStateParams extends angular.ui.IStateParamsService {
    username: string;
    link: string;
}
