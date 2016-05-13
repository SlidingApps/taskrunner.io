/// <reference path="../../../typings.d.ts" />

// FOUNDATION
import { Model as FoundationModel } from '../../../component/foundation/model';

// MODEL
import { IPasswordLinkPayload } from '../../../service/write-model/account/password-link';

export class Model extends FoundationModel {
    
    constructor() {
        super();
    }
    
    private _username: string;
    public get username(): string { return this._username; }
    public set username(value: string) { 
        this._username = value;
        this.$onPropertyChanged('username', value);
    }

    public $toPasswordLink(): IPasswordLinkPayload {
        return this.$toPayload<IPasswordLinkPayload>(() => {
            return {
                name: this.username
            };
        });
    }
}
