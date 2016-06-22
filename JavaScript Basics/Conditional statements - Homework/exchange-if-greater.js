function solve(args) {
    'use strict';

    var firstNumber = +args[0],
        secondNumber = +args[1];

    if (firstNumber < secondNumber) {
        return firstNumber + ' ' + secondNumber;
    }

    return secondNumber + ' ' + firstNumber;
}

console.log(solve([1, 1]));
console.log(solve([2, 1]));
console.log(solve([2, 3]));
