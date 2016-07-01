function solve(args) {
    'use strict';

    var inputSplited = args[0].split('\n').map(function(x) {
            return +x;
        }),
        maxSequence = 0,
        currentSequence = 1,
        prevChar = inputSplited[1],
        i,
        n = inputSplited[0];

    for (i = 2; i < n; i += 1) {
        if (inputSplited[i] > prevChar) {
            currentSequence += 1;
        } else {
            currentSequence = 1;
        }

        prevChar = inputSplited[i];

        if (currentSequence > maxSequence) {
            maxSequence = currentSequence;
        }
    }

    return maxSequence;
}
