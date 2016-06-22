function solve(args) {
    var firstNumber = +args[0],
        secondNumber = +args[1],
        thirdNumber = +args[2],
        greatest,
        middle,
        smallest;

    if (firstNumber >= secondNumber && firstNumber >= thirdNumber) { // first number is the greatest
        greatest = firstNumber;
        if (secondNumber > thirdNumber) {
            middle = secondNumber;
            smallest = thirdNumber;
        } else {
            middle = thirdNumber;
            smallest = secondNumber;
        }
    } else if (secondNumber >= firstNumber && secondNumber >= thirdNumber) { // second number is the greatest
        greatest = secondNumber;
        if (firstNumber > thirdNumber) {
            middle = firstNumber;
            smallest = thirdNumber;
        } else {
            middle = thirdNumber;
            smallest = firstNumber;
        }
    } else { // Third number is the greatest
        greatest = thirdNumber;
        if (firstNumber > secondNumber) {
            middle = firstNumber;
            smallest = secondNumber;
        } else {
            middle = secondNumber;
            smallest = firstNumber;
        }
    }

    return greatest + ' ' + middle + ' ' + smallest;
}

console.log(solve([5, 1, 2]));
console.log(solve([-2, -2, 1]));
console.log(solve([-2, 4, 3]));
console.log(solve([0, -2.5, 5]));
console.log(solve([-1.1, -0.5, -0.1]));
console.log(solve([10, 20, 30]));
console.log(solve([1, 1, 1]));
