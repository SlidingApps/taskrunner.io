/// <reference path="../../../typings.d.ts" />

// COMMON
import { IRepresentation, IRepresentationCollection } from '../../../component/foundation/representation';
import { Entity } from '../../../component/foundation/entity';

// MODEL
export interface IAccountValidityAttributes {
    id?: string;
    emailAddress?: string;
    username?: string;
    isValid: boolean;
}

export interface IAccountValidity extends IRepresentation, IAccountValidityAttributes {
}

export interface IAccountValidityAttributesCollection extends IRepresentationCollection<IEmbeddedResources> {
}

export interface IEmbeddedResources {
    tenantAvailabilities: Array<IAccountValidity>;
}

export class AccountValidity extends Entity<IAccountValidity> {
    constructor(representation?: IAccountValidity) {
        super(representation);
    }

    public get id(): string { return this.$representation.id; }
    public set id(value: string) { this.$representation.id = value; }

    public get emailAddress(): string { return this.$representation.emailAddress; }
    public set emailAddress(value: string) { this.$representation.emailAddress = value; }

    public get username(): string { return this.$representation.username; }
    public set username(value: string) { this.$representation.username = value; }

    public get isValid(): boolean { return this.$representation.isValid; }
    public set isValid(value: boolean) { this.$representation.isValid = value; }
}
