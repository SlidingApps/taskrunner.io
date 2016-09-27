/// <reference path="../../typings.d.ts" />

export interface IExceptionCodes {
    [code: string]: Exception;
}

class Exception {
    constructor(public code: string, public message: string) {

    }
}

export class ApplicationException {
    public static Codes: IExceptionCodes = {
        'D8D500AE': new Exception('D8D500AE', '')
    };
}
