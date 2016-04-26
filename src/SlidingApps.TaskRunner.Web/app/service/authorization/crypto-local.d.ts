declare var cryptoLocal: any;
declare module 'crypto' {
    export = cryptoLocal;
}
