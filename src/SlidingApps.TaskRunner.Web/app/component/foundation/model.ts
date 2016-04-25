/// <reference path="../../typings.d.ts" />

// COMMON
import { BehaviorSubject } from 'rxjs';
import { IPropertyChangedEvent} from './event';

// FOUNDATION
import { Logger } from './logger';

export interface IModel {
    $propertyChanged: BehaviorSubject<IPropertyChangedEvent>;
}

export interface IPayload { }

export class Model implements IModel {

    private _$propertyChanged: BehaviorSubject<IPropertyChangedEvent>;
    public get $propertyChanged() {
        if (!this._$propertyChanged) {
            Logger.LOG.debug(this.constructor.name, '$propertyChanged instantiated', this);
            this._$propertyChanged = new BehaviorSubject<IPropertyChangedEvent>(undefined); 
        }
        return this._$propertyChanged;
    }

    protected $toPayload<TPayload extends IPayload>(converter: (model: Model) => TPayload): TPayload {
        Logger.LOG.info(this.constructor.name, '$toPayload invoked', this);
        let payload: TPayload = converter(this);
        Logger.LOG.debug(this.constructor.name, '$toPayload done', payload);

        return payload;
    }

    protected $onPropertyChanged(property: string, value: any) {
        Logger.LOG.debug(this.constructor.name, property, value);
        this.$propertyChanged.next({ sender: this, args: { property, value}});
    }

    public $destroy() {
        Logger.LOG.info(this.constructor.name, '$destroy invoked', this);
        if (this._$propertyChanged) { this._$propertyChanged.complete(); }
        Logger.LOG.debug(this.constructor.name, '$destroy done', this);
    }
}
