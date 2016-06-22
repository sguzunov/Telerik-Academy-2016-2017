function solve(args) {
    var firstNumber = +args[0],
        secondNumber = +args[1],
        thirdNumber = +args[2];

    if (firstNumber === 0 || secondNumber === 0 || thirdNumber === 0) {
        return '0';
    } else if (firstNumber > 0 || secondNumber > 0 || thirdNumber > 0) {
        if (firstNumber > 0 && secondNumber > 0 && thirdNumber > 0) {
            return '+';
        } else if (firstNumber > 0 && secondNumber < 0 && thirdNumber < 0) {
            return '+';
        } else if (secondNumber > 0 && firstNumber < 0 && thirdNumber < 0) {
            return '+';
        } else if (thirdNumber > 0 && firstNumber < 0 && secondNumber < 0) {
            return '+';
        } else {
            return '-';
        }
    } else {
        return '-';
    }
}

console.log(solve([1, 1, 1]));
console.log(solve([-1, 1, 1]));
console.log(solve([-1, -1, -1]));
