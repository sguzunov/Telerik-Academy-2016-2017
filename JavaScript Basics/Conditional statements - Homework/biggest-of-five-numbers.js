function solve(args) {
    var x1 = +args[0],
        x2 = +args[1],
        x3 = +args[2],
        x4 = +args[3],
        x5 = +args[4],
        biggest;

    biggest = x1;
    if (biggest < x2 || biggest < x3 || biggest < x4 || biggest < x5) {
        biggest = x2;
        if (biggest < x3 || biggest < x4 || biggest < x5) {
            biggest = x3;
            if (biggest < x4) {
                biggest = x4;
            }

            if (biggest < x5) {
                biggest = x5;
            }
        }
    }

    return biggest;
}
