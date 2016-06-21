function solve(args) {
    'use strict';

    var number = args[0] * 1;
    var isEven = number % 2;
    console.log(!isEven ? 'even ' + number : 'odd ' + number);
}
