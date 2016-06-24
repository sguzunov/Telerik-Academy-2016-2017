function solve(args) {
    var number = +args[0],
        i,
        j,
        line;

    for (i = 0; i < number; i += 1) {
        line = '';
        for (j = 0; j < number; j += 1) {
            line += (i + j + 1) + ' ';
        }

        console.log(line);
    }
}

solve([3]);