/// <reference path="../../typings.d.ts" />

import { Model } from './model';
import { IRepresentation } from './representation';

export interface IEntity<TRepresentation extends IRepresentation> {
    $representation: TRepresentation;
}

export class Entity<TRepresentation> extends Model implements IEntity<TRepresentation> {

    constructor(representation: TRepresentation) {
        super();
        this.$representation = representation;
    }

    protected $representation: TRepresentation;

    public static Create<TInstance extends IEntity<TRepresentation>>(ctor: { new(representation: TRepresentation): TInstance; }, representation: TRepresentation): TInstance {
        let instance: TInstance = new ctor(representation);

        return instance;
    }
}
