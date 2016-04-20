/// <reference path="../../../typings.d.ts" />

// FOUNDATION
import { Model as FoundationModel } from '../../../component/foundation/model';

// MODEL
import { ICreateTenantPayload  } from '../../../service/write-model/tenant/create-tenant';

export class Model extends FoundationModel {
    constructor() {
        super();
    }

    private _organization: string;
    public get organization(): string { return this._organization; }
    public set organization(value: string) {
        this._organization =  value ? value.replace( /[^a-z0-9]/g, '') : value;
        this.$onPropertyChanged('organization', this._organization);
    }

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

    private _passwordConfirmation: string;
    public get passwordConfirmation(): string { return this._passwordConfirmation; }
    public set passwordConfirmation(value: string) {
        this._passwordConfirmation = value;
        this.$onPropertyChanged('passwordConfirmation', value);
    }
    
    public $toCreateTenant(): ICreateTenantPayload {
        return this.$toPayload<ICreateTenantPayload>(() => { 
            return {
                code: this.organization,
                name: this.organization,
                description: this.organization,
                userName: this.username,
                userPassword: this.password
            }; 
        });
    }
}
