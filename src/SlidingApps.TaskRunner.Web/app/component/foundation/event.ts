/// <reference path="../../typings.d.ts" />

export interface IEvent { }

export interface IPropertyChangedEvent extends IEvent {
    property: string;
    value: string;
}
