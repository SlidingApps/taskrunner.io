/// <reference path="../../../typings.d.ts" />

// COMMON
import { IRepresentation, IRepresentationCollection } from '../../../component/foundation/representation';
import { Entity } from '../../../component/foundation/entity';

// MODEL
export interface ITenantCodeAvailabilityAttributes {
    code: string;
    isAvailable: boolean;
}

export interface ITenantCodeAvailability extends IRepresentation, ITenantCodeAvailabilityAttributes {
}

export interface ITenantCodeAvailabilityCollection extends IRepresentationCollection<IEmbeddedResources> {
}

export interface IEmbeddedResources {
    tenantAvailabilities: Array<ITenantCodeAvailability>;
}

export class TenantCodeAvailability extends Entity<ITenantCodeAvailability> {
    constructor(representation?: ITenantCodeAvailability) {
        super(representation);
    }

    public get code(): string { return this.$representation.code; }
    public set code(value: string) { this.$representation.code = value; }

    public get isAvailable(): boolean { return this.$representation.isAvailable; }
    public set isAvailable(value: boolean) { this.$representation.isAvailable = value; }
}
