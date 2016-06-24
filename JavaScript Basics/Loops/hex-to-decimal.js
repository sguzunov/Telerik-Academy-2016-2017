function solve(args) {
    'use strict';

    var hexNumber = args[0],
        decimalNumber = 0,
        power = 1,
        i,
        charCode,
        char,
        zeroCharCode = '0'.charCodeAt(0),
        nineCharCode = '9'.charCodeAt(0),
        aCharCode = 'A'.charCodeAt(0);

    for (i = hexNumber.length - 1; i >= 0; i -= 1) {
        char = hexNumber[i];
        charCode = char.charCodeAt(0);
        if (charCode >= zeroCharCode && charCode <= nineCharCode) {
            decimalNumber += (charCode - zeroCharCode) * power;
        } else {
            decimalNumber += ((charCode - aCharCode) + 10) * power;
        }

        power *= 16;
    }

    return decimalNumber;
}

console.log(solve(['FE']));