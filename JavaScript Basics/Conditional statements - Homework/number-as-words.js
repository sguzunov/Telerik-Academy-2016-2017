function solve(args) {
    'use strict';

    var number = +args[0],
        digit,
        numberAsWord = '',
        toLower = false,
        digitsAsWord = ['Zero', 'One', 'Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine'],
        numbersAsWordBetween10And20 = [
            'Ten', 'Eleven', 'Twelve', 'Thirteen', 'Fourteen', 'Fifteen',
            'Sixteen', 'Seventeen', 'Eighteen', 'Nineteen'
        ];

    if (number >= 100) {
        digit = (number / 100) | 0;
        number = number % 100;
        toLower = true;
        numberAsWord += digitsAsWord[digit - 1] + ' hundred';
    }

    if (number >= 10 && number <= 19) {
        if (toLower) {
            numberAsWord += ' and ' + numbersAsWordBetween10And20[number % 10].toLowerCase();
        } else {
            numberAsWord += numbersAsWordBetween10And20[number % 10];
        }
    } else if (number >= 20 && number <= 99) {
        
    }

    return numberAsWord;
}

console.log(solve([15]));
