/// <reference path="../../typings.d.ts" />

export interface IRepresentation {
    _links: ILinkSet;
    _embedded: any;
}

export interface IRepresentationCollection<TRepresentationCollection> extends IRepresentation {
    _embedded: TRepresentationCollection;
}

export interface ILinkSet {
    self: ILink;
}

export interface ILink {
    href: string;
    method: string;
    templated: boolean;
}
