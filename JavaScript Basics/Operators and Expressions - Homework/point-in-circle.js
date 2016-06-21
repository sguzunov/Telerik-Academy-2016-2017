function solve(args) {
    'use strict';

    var x = +args[0],
        y = +args[1],
        distance,
        RADIUS = 2;

    distance = Math.sqrt(Math.abs(x * x) + Math.abs(y * y));
    if (distance <= RADIUS) {
        return 'yes ' + distance.toFixed(2);
    } else {
        return 'no ' + distance.toFixed(2);
    }
}

var res = solve([-1, 2]);
console.log(res);
