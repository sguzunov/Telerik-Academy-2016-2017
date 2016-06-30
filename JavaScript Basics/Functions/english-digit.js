function solve(args) {
    var digitsAsWords = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'],
        number = +args[0],
        lastDigit,
        lastDigitAsWord;

    lastDigit = number % 10;
    lastDigitAsWord = digitsAsWords[lastDigit];
    return lastDigitAsWord;
}

console.log(solve([43]));
