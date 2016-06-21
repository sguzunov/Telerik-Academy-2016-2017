function solve(args) {
    'use strict';

    var x = +args[0],
        y = +args[1],
        isInRectangle,
        isInCircle,
        CIRCLE_X = 1,
        CIRCLE_Y = 1,
        CIRCLE_RADIUS = 1.5,
        RECTANGLE_TOP = 1,
        RECTANGLE_LEFT = -1,
        RECTANGLE_WIDTH = 6,
        RECTANGLE_HEIGHT = 2,
        result = '';

    isInCircle = Math.sqrt((Math.abs(x * x)) + (Math.abs(y * y)) + 1 === CIRCLE_RADIUS);
    isInRectangle = x >= RECTANGLE_LEFT && x <= RECTANGLE_LEFT + RECTANGLE_WIDTH && y >= RECTANGLE_TOP && y <= RECTANGLE_TOP + RECTANGLE_HEIGHT;

    if (isInCircle) {
        result += 'inside circle';
    } else {
        result += 'outside circle';
    }

    result += ' ';
    if (isInRectangle) {
        result += 'inside rectangle';
    } else {
        result += 'outside rectangle';
    }

    return result;
}

console.log(solve([0, 1]));
