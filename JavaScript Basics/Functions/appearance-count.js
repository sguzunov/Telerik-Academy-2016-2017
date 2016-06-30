function solve(args) {
    var n = +args[0],
        numbers = args[1].split(' ').map(function(x) {
            return +x;
        }),
        chosenOne = +args[2],
        count = 0;

    for (var i = 0; i < numbers.length; i += 1) {
        if (numbers[i] === chosenOne) {
            count += 1;
        }
    }

    return count;
}
