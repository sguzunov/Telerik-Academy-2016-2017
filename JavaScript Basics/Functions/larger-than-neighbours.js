function solve(args) {
    var n = +args[0],
        numbers = args[1].split(' ').map(function(x) {
            return +x;
        }),
        count = 0,
        i;

    for (i = 1; i < numbers.length - 1; i += 1) {
        if (numbers[i] >= numbers[i - 1] && numbers[i] >= numbers[i + 1]) {
            count += 1;
        }
    }

    return count;
}
