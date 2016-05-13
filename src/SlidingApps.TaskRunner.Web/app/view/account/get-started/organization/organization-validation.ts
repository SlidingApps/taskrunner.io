/// <reference path="../../../../typings.d.ts" />

import 'angular';

import { ReadModelService } from '../../../../service/read-model/read-model-service';
import { TenantCodeAvailability } from '../../../../service/read-model/tenant/tenant-code-availability';

export class Directive implements angular.IDirective {
    constructor(private $q: angular.IQService, private service: ReadModelService) { }

    private static ORGANIZATION_IS_UNIQUE_ASYNC_VALIDATOR: string = 'organizationIsUniqueAsync';

    public priority: number = 100;
    public require: Array<string> = ['ngModel'];
    public restrict: string = 'A';

    public compile(): angular.IDirectiveCompileFn {
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
                _value = value.replace( /[^a-z0-9]/g, '').trim();
            }

            return _value;
        });

        ctrl.$parsers.push(value => {
            let _value: string = '';

            if (value) {
                _value = value.replace( /[^a-z0-9]/g, '').trim();

                if (_value !== value) {
                    ctrl.$setViewValue(_value);
                    ctrl.$render();
                }
            }

            return _value;
        });

        ctrl.$asyncValidators[Directive.ORGANIZATION_IS_UNIQUE_ASYNC_VALIDATOR] = (modelValue: string, viewValue: string) => {
            let deferred: angular.IDeferred<void> = this.$q.defer<void>();
            let value: string = modelValue || viewValue;

            this.service.tenant.getTenantCodeAvailability(value)
                .then((response: TenantCodeAvailability) => {
                    if (response.isAvailable) {
                        deferred.resolve();
                    } else {
                        deferred.reject();
                    }
                })
                .catch(() => deferred.reject());

            return deferred.promise;
        };
    }
}

export const DirectiveFactory: Array<any> = ['$q', 'readModelService', ($q, readModelService) => new Directive($q, readModelService)];
