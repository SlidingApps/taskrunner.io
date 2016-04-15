/// <reference path="../../typings.d.ts" />

export interface ILookupValueItem<TIdentifier> {
    id: TIdentifier;
    label: string;
}

export class LookupValueSet<TIdentifier> {
    public items: Array<ILookupValueItem<TIdentifier>> = [];
}
