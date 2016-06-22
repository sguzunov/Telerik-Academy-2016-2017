function solve(args) {
    var a = +args[0],
        b = +args[1],
        c = +args[2],
        D,
        x1,
        x2;

    D = b * b - 4 * a * c;
    if (D > 0) {
        x1 = (-b - Math.sqrt(D)) / (2 * a);
        x2 = (-b + Math.sqrt(D)) / (2 * a);
        return 'x1=' + x1.toFixed(2) + '; x2=' + x2.toFixed(2);
    } else if (D === 0) {
        x1 = -b / (2 * a);
        x2 = x1;
        return 'x1=x2=' + x1.toFixed(2);
    } else {
        return 'no real roots';
    }
}

console.log(solve([2, 5, -3]));
console.log(solve([-1, 3, 0]));
console.log(solve([-0.5, 4, -8]));
console.log(solve([5, 2, 8]));
console.log(solve([0.2, 9.572, 0.2]));
