/// <reference path="../../../../typings.d.ts" />

import 'angular';

export class Directive implements angular.IDirective {
    public priority: number = 100;
    public require: Array<string> = ['ngModel'];
    public restrict: string = 'A';

    public link(
        scope: angular.IScope,
        element: angular.IAugmentedJQuery,
        attrs: angular.IAttributes,
        [ctrl]: [angular.INgModelController]
    ): void {
        ctrl.$formatters.push(value => {
            let _value: string = '';

            if (value) {
                _value = value.replace( /[^a-z]/g, '').trim();
            }

            return _value;
        });

        ctrl.$parsers.push(value => {
            let _value: string = '';

            if (value) {
                _value = value.replace( /[^a-z]/g, '').trim();

                if (_value !== value) {
                    ctrl.$setViewValue(_value);
                    ctrl.$render();
                }
            }

            return _value;
        });

        ctrl.$validators['organization-is-unique'] = (modelValue: string, viewValue: string) => {
            if (!modelValue || !viewValue) { return true; }

            return true;
        };
    }
}

export const DirectiveFactory: () => angular.IDirective = () => new Directive();
