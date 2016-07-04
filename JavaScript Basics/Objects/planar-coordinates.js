function solve(args) {
    'use strict';

    function getLine(coordiates) {
        return {
            'x1': coordiates[0],
            'y1': coordiates[1],
            'x2': coordiates[2],
            'y2': coordiates[3]
        };
    }

    args = args.map(function(x) {
        return +x;
    });

    var firstLine = getLine(args.slice(0, 4)),
        secondLine = getLine(args.slice(4, 8)),
        thirdLine = getLine(args.slice(8, 12)),
        firstLineLength,
        secondLineLength,
        thirdLineLength,
        canFormTriangle;

    firstLineLength = Math.sqrt((Math.abs(firstLine.x1 - firstLine.x2) * Math.abs(firstLine.x1 - firstLine.x2) +
        Math.abs(firstLine.y1 - firstLine.y2) * Math.abs(firstLine.y1 - firstLine.y2))).toFixed(2);
    secondLineLength = Math.sqrt((Math.abs(secondLine.x1 - secondLine.x2) * Math.abs(secondLine.x1 - secondLine.x2) +
        Math.abs(secondLine.y1 - secondLine.y2) * Math.abs(secondLine.y1 - secondLine.y2))).toFixed(2);
    thirdLineLength = Math.sqrt((Math.abs(thirdLine.x1 - thirdLine.x2) * Math.abs(thirdLine.x1 - thirdLine.x2) +
        Math.abs(thirdLine.y1 - thirdLine.y2) * Math.abs(thirdLine.y1 - thirdLine.y2))).toFixed(2);

    canFormTriangle = ((firstLineLength + secondLineLength) >= thirdLineLength) &&
        ((secondLineLength + thirdLineLength) >= firstLineLength) &&
        ((firstLineLength + thirdLineLength) >= secondLineLength);

    console.log(firstLineLength);
    console.log(secondLineLength);
    console.log(thirdLineLength);
    console.log(canFormTriangle ? 'Triangle can be built' : 'Triangle can not be built');
}

// function solve(args) {
//     'use strict';

//     function getLine(coordiates) {
//         return {
//             'x1': coordiates[0],
//             'y1': coordiates[1],
//             'x2': coordiates[2],
//             'y2': coordiates[3]
//         };
//     }

//     args = args.map(Number);

//     var firstLine = getLine(args.slice(0, 4)),
//         secondLine = getLine(args.slice(4, 8)),
//         thirdLine = getLine(args.slice(8, 12)),
//         firstLineLength,
//         secondLineLength,
//         thirdLineLength,
//         canFormTriangle;

//     firstLineLength = Math.sqrt((firstLine.x1 - firstLine.x2) * (firstLine.x1 - firstLine.x2) +
//         (firstLine.y1 - firstLine.y2) * (firstLine.y1 - firstLine.y2)).toFixed(2);
//     secondLineLength = Math.sqrt((secondLine.x1 - secondLine.x2) * (secondLine.x1 - secondLine.x2) +
//         (secondLine.y1 - secondLine.y2) * (secondLine.y1 - secondLine.y2)).toFixed(2);
//     thirdLineLength = Math.sqrt((thirdLine.x1 - thirdLine.x2) * (thirdLine.x1 - thirdLine.x2) +
//         (thirdLine.y1 - thirdLine.y2) * (thirdLine.y1 - thirdLine.y2)).toFixed(2);

//     canFormTriangle = ((firstLineLength + secondLineLength) > thirdLineLength) &&
//         ((secondLineLength + thirdLineLength) > firstLineLength) &&
//         ((firstLineLength + thirdLineLength) > secondLineLength);

//     console.log(firstLineLength);
//     console.log(secondLineLength);
//     console.log(thirdLineLength);
//     console.log(canFormTriangle ? 'Triangle can be built' : 'Triangle can not be built');
// }

solve([
    '5', '6', '7', '8',
    '1', '2', '3', '4',
    '9', '10', '11', '12'
]);

console.log('\r\n');
solve([
    '7', '7', '2', '2',
    '5', '6', '2', '2',
    '95', '-14.5', '0', '-0.123'
]);