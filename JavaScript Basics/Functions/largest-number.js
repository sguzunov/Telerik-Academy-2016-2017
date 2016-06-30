function solve(args) {
    'use strict';

    var numbers = args[0].split(' ').map(function(x) {
            return +x;
        }),
        largest;

    function getMax(firstNumber, secondNumber) {
        return firstNumber > secondNumber ? firstNumber : secondNumber;
    }

    largest = getMax(numbers[0], numbers[1]);
    largest = getMax(largest, numbers[2]);

    return largest;
}

solve(['1 2 3']);
