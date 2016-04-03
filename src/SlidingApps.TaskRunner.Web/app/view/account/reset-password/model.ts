/// <reference path="../../../typings.d.ts" />

export class Model {
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
