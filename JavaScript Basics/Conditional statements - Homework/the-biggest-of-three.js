function solve(args) {
    var firstNumber = +args[0],
        secondNumber = +args[1],
        thirdNumber = +args[2],
        biggest;

    biggest = firstNumber;
    if (biggest < secondNumber) {
        biggest = secondNumber;
    }

    if (biggest < thirdNumber) {
        biggest = thirdNumber;
    }

    return biggest;
}

console.log(solve([1,1,1]));
console.log(solve([2,1,1]));
console.log(solve([2,3,1]));
console.log(solve([2,3,5]));