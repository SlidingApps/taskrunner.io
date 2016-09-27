/// <reference path="../../../typings.d.ts" />
import { ErrorInfo } from '../../../component/foundation/application-error';

export class Model {
    private _isReady: boolean = false;
    public get isReady(): boolean { return this._isReady; }
    public set isReady(value: boolean) { this._isReady = value; }

    public _error: ErrorInfo;
    public get error(): ErrorInfo { return this._error; }
    public set error(value: ErrorInfo) { this._error = value; }

    private _username: string;
    public get username(): string { return this._username; }
    public set username(value: string) { this._username = value; }

    private _password: string;
    public get password(): string { return this._password; }
    public set password(value: string) { this._password = value; }

    private _passwordConfirmation: string;
    public get passwordConfirmation(): string { return this._passwordConfirmation; }
    public set passwordConfirmation(value: string) { this._passwordConfirmation = value; }
}
