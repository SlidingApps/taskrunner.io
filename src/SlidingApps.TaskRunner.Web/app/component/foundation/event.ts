/// <reference path="../../typings.d.ts" />

export interface IEvent<TEventSender, TEventArgs extends IEventArgs> {
    sender: TEventSender;
    args?: TEventArgs;
}
export interface IEventArgs { }

export interface IPropertyChangedEvent<TInstance> extends IEvent<TInstance, IPropertyChangedEventArgs> { }
export interface IPropertyChangedEventArgs extends IEventArgs {
    property: string;
    value: string;
}
