function solve(args) {
    var inputSpited = args[0].split('\n').map(function(x) {
            return +x;
        }),
        numbers = inputSpited.slice(1),
        n = inputSpited[0],
        maxNumberIndex,
        i,
        j;

    for (i = 0; i < n - 1; i += 1) {
        minNumberIndex = i;
        for (j = i + 1; j < n; j += 1) {
            if (numbers[minNumberIndex] > numbers[j]) {
                minNumberIndex = j;
            }
        }

        if (minNumberIndex !== i) {
            numbers[minNumberIndex] ^= numbers[i];
            numbers[i] = numbers[minNumberIndex] ^ numbers[i];
            numbers[minNumberIndex] = numbers[minNumberIndex] ^ numbers[i];
        }
    }

    return numbers.join('\n');
}

console.log(solve(['5\n4\n2\n1\n8\n3']));