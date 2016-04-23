/// <reference path="../../../typings.d.ts" />

// FOUNDATION
import { Model as FoundationModel } from '../../../component/foundation/model';

export class Model extends FoundationModel {
    private _username: string;
    public get username(): string { return this._username; }
    public set username(value: string) { 
        this._username = value;
        this.$onPropertyChanged('username', value);
    }

    private _password: string;
    public get password(): string { return this._password; }
    public set password(value: string) { 
        this._password = value;
        this.$onPropertyChanged('password', value);
    }
}
