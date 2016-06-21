function solve(args) {
    'use strict';

    var number = +args[0],
        maxDivider = Math.sqrt(number),
        i;

    if (number <= 1) {
        return false;
    } else {
        for (i = 2; i <= maxDivider; i += 1) {
            if (number % i === 0) {
                return false;
            }
        }

        return true;
    }
}
