/// <reference path="../../../typings.d.ts" />

export class Model {
    private _username: string;
    public get username(): string { return this._username; }
    public set username(value: string) { this._username = value; }
}
