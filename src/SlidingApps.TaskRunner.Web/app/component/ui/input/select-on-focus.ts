/// <reference path="../../../typings.d.ts" />

export class Directive implements angular.IDirective {
    public priority: number = 100;
    public require: Array<string> = ['?ngModel'];
    public restrict: string = 'E';

    public link(
        scope: angular.IScope,
        element: angular.IAugmentedJQuery,
        attrs: angular.IAttributes,
        [ctrl]: [angular.INgModelController]
    ): void {
        if (!ctrl) { return; }

        element.bind('click', (): void => {
            element.select();
        });
    }
}

export const DirectiveFactory: () => angular.IDirective = () => new Directive();
