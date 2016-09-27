/// <reference path="../../typings.d.ts" />

export interface IError {
    code: string;
    message: string;
}

export class ErrorInfo {
    constructor(public code: ErrorCode, public message: string) { }
}

export interface IErrorCodes {
    [code: string]: Error;
}

export enum ErrorCode {
    D8D500AE = <any>'D8D500AE'
}

export class ApplicationErrors {
    private static Codes: IErrorCodes = {
        'D8D500AE': new ErrorInfo(ErrorCode.D8D500AE, 'Unconfirmed account')
    }

    public static GetErrorInfo(serialized: string): ErrorInfo {
        const error: IError = <IError>angular.fromJson(serialized);

        return angular.fromJson(angular.toJson(ApplicationErrors.Codes[error.code]));
    }
}
