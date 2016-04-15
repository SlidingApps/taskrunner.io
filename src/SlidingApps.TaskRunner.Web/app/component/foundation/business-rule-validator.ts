/// <reference path="../../typings.d.ts" />

import { IEvent, IEventArgs } from './event';

export interface IBusinessRule<TInstance> {
    name: string;
    match: (instance: TInstance) => boolean;
}

export interface IBusinessRulesValidator<TInstance> {
    rules: Array<IBusinessRule<TInstance>>;
    validate(instance: TInstance): Array<{ name: string }>;
}

export class BusinessRulesValidator<TInstance> implements IBusinessRulesValidator<TInstance> {
    protected _rules: Array<IBusinessRule<TInstance>>;
    
    public validate(instance: TInstance): Array<{ name: string }> {
        let failures: Array<IBusinessRule<TInstance>> = _.filter(this.rules, rule => rule.match(instance) === false);        
        return _.map(failures, failure => { return { name: failure.name }; });
    }
    
    public get rules(): Array<IBusinessRule<TInstance>> { return this._rules; }
}

export interface IValidatedInstanceChangedEvent<TInstance> extends IEvent<TInstance, IValidatedInstanceChangedEventArgs> { }
export interface IValidatedInstanceChangedEventArgs extends IEventArgs {
    failures: Array<{ name: string }>;
}

