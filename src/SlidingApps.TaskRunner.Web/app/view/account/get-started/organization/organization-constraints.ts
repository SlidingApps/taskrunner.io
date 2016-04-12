/// <reference path="../../../../typings.d.ts" />

import 'angular';

export class Directive implements angular.IDirective {
    constructor(private $http: angular.IHttpService, private $q: angular.IQService) { }

    public priority: number = 100;
    public require: Array<string> = ['ngModel'];
    public restrict: string = 'A';

    public compile(): void {
        return this.link.bind(this);
    }

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

        ctrl.$asyncValidators['organization-is-unique-async'] = (modelValue: string, viewValue: string) => {
            let value: string = modelValue || viewValue;

            console.log('$asyncValidators', this, value);

            // Lookup user by username
            return this.$http.get('http://www.google.be').then(
                response => {
                    console.log('http', response);
                    // username exists, this means validation fails
                    return this.$q.reject('exists');
                },
                reason => {
                    // username does not exist, therefore this validation passes
                    return true;
                });
        };
    }
}

export const DirectiveFactory: [() => angular.IDirective] = ['$http', '$q', ($http, $q) => new Directive($http, $q)];
