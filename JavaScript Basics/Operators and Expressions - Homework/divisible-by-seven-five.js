function solve(args) {
    'use strict';

    var number = args[0] * 1;
    var isDivisibleBySevenAndFive = number % 7 === 0 && number % 5 === 0;
    console.log(isDivisibleBySevenAndFive ? 'true ' + number : 'false ' + number);
}
