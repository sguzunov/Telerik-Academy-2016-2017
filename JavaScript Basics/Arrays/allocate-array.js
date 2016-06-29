function solve(args) {
    'use strict';

    var count = +args[0],
        numbers = new Array(count),
        i;

    for (i = 0; i < numbers.length; i += 1) {
        numbers[i] = i * 5;
    }

    for (i = 0; i < numbers.length; i += 1) {
        console.log(numbers[i]);
    }
}

solve(['5']);