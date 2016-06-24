function solve(args) {
    'use strict';
    var number = +args[0],
        numbers = [],
        i;

    for (i = 1; i < number + 1; i += 1) {
        numbers.push(i);
    }

    return numbers.join(' ');
}

console.log(solve(5));