function solve(args) {
    var input = args[0].split('\n').map(function(x) {
            return +x;
        }),
        n = input[0],
        numbers = input.slice(1),
        prev = numbers[0],
        mostFreq = 0,
        currentFreq = 1,
        i,
        mostFreqNumber = prev;

    var sorted = numbers.sort();
    for (i = 1; i < n; i += 1) {
        if (sorted[i] === prev) {
            currentFreq += 1;
        } else {
            currentFreq = 1;
        }

        if (currentFreq > mostFreq) {
            mostFreq = currentFreq;
            mostFreqNumber = prev;
        }

        prev = sorted[i];
    }

    return mostFreqNumber + ' (' + mostFreq + ' times)';
}

console.log(solve(['5\n1\n1\n2\n5\n2\n5\n5\n2']));