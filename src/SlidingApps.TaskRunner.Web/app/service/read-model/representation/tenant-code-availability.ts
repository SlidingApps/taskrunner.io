/// <reference path="../../../typings.d.ts" />

import { IRepresentation, IRepresentationCollection } from '../../rest/representation';

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
