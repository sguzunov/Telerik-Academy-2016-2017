function solve(args) {
    'use strict';

    var inputSpited = args[0].split('\n').map(function(x) {
            return +x;
        }),
        maxSequence = 1,
        currentSequence = 1,
        n = inputSpited[0],
        maxChar = inputSpited[1],
        i;

    for (i = 2; i < n; i += 1) {
        if (inputSpited[i] === maxChar) {
            currentSequence += 1;
        } else {
            maxChar = inputSpited[i];
            currentSequence = 1;
        }

        if (currentSequence > maxSequence) {
            maxSequence = currentSequence;
        }
    }

    return maxSequence;
}

solve(['10', '2', '1', '1', '2', '3', '3', '2', '2', '2', '1']);
