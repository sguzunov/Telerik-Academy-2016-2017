function solve(args) {
    'use strict';

    var number = +args[0],
        thirdBit = (number >> 3) & 1;

        console.log(thirdBit);
}
