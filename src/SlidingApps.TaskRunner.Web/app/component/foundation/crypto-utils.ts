
import { BigInteger } from './big-integer';

export class Convert {
    public static FromByteArrayToString(array: any[]): string {
        let result: string = '';
        for (let i: number = 0; i < array.length; i++) {
            result += String.fromCharCode(parseInt(array[i], 10));
        }

        return result;
    }
}

export class Base58 {

    public static 	alphabet: string = '123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz';
    public static	validRegex: RegExp = /^[1-9A-HJ-NP-Za-km-z]+$/;
    public static	base: any = BigInteger.valueOf(58);

    public static encode (input: number[]) {
        let bi: any = BigInteger.fromByteArrayUnsigned(input);
        let chars: any = [];
        while (bi.compareTo(Base58.base) >= 0) {
            let mod: any = bi.mod(Base58.base);
            chars.unshift(Base58.alphabet[mod.intValue()]);
            bi = bi.subtract(mod).divide(Base58.base);
        }
        chars.unshift(Base58.alphabet[bi.intValue()]);

        // Convert leading zeros too.
        for (let i: number = 0; i < input.length; i++) {
            if (input[i] === 0x00) {
                chars.unshift(Base58.alphabet[0]);
            } else {
                break;
            }
        }

        return chars.join('');
    }

    /**
     * Convert a base58-encoded string to a byte array.
     *
     * Written by Mike Hearn for BitcoinJ.
     *   Copyright (c) 2011 Google Inc.
     *
     * Ported to JavaScript by Stefan Thomas.
     */
    public static decode (input: string): number[] {
        let bi: any = BigInteger.valueOf(0);
        let leadingZerosNum: any = 0;
        for (let i: number = input.length - 1; i >= 0; i--) {
            let alphaIndex: any = Base58.alphabet.indexOf(input[i]);
            if (alphaIndex < 0) {
                throw 'Invalid character';
            }
            bi = bi.add(BigInteger.valueOf(alphaIndex)
                .multiply(Base58.base.pow(input.length - 1 - i)));

            // This counts leading zero bytes
            if (input[i] === '1') {
                leadingZerosNum++;
            } else {
                leadingZerosNum = 0;
            }
        }
        let bytes: any = bi.toByteArrayUnsigned();

        // Add leading zeros
        while (leadingZerosNum-- > 0) {
            bytes.unshift(0);
        }

        return bytes;
    }
}
