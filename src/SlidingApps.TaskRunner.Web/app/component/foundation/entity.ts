/// <reference path="../../typings.d.ts" />

import { Model } from './model';
import { IRepresentation } from './representation';

export interface IEntity<TRepresentation extends IRepresentation> {
    $representation: TRepresentation;
}

export class Entity<TRepresentation extends IRepresentation> extends Model implements IEntity<TRepresentation> {

    constructor(representation: TRepresentation) {
        super();
        this.$representation = representation ? representation : <TRepresentation>{};
    }

    public $representation: TRepresentation;
}
