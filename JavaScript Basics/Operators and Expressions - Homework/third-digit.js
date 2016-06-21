function solve(args) {
    'use strict';

    var number = +args[0],
        thirdDigit = ((number / 100) % 10) | 0,
        SEARCH_DIGIT = 7;

    console.log(thirdDigit == SEARCH_DIGIT ? 'true' : 'false ' + thirdDigit);
}

solve([7477]);
solve([7777]);
