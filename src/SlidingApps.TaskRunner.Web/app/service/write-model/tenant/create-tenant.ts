/// <reference path="../../../typings.d.ts" />

// MODEL
import { IPayload } from '../../../component/foundation/model';

export interface ICreateTenantPayload extends IPayload {
    code: string;
    name: string;
    description: string;
    validFrom?: string;
    validUntil?: string;
    userName: string;
    userPassword: string;
}
