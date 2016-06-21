function solve(args) {
    'use strict';

    var a = +args[0],
        b = +args[1],
        h = +args[2],
        area;
    area = ((a + b) * h) / 2;
    return area.toFixed(7);
}
