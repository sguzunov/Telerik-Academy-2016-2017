function solve(args) {
    var n = +args[0],
        maxSequence = -1000,
        currentSequence = 1,
        maxChar = args[1],
        i;

    for (i = 2; i < n; i += 1) {
        if (args[i] === maxChar) {
            currentSequence += 1;
        } else {
            maxChar = args[i];
            currentSequence = 1;
        }

        if (currentSequence > maxSequence) {
            maxSequence = currentSequence;
        }
    }

    console.log(maxSequence);
}

solve(['10', '2', '1', '1', '2', '3', '3', '2', '2', '2', '1']);
