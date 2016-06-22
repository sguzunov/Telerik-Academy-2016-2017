function solve(args) {
    'use strict';

    var number = +args[0],
        digit,
        numberAsWord,
        toLower = false,
        digitsAsWord = ['One', 'Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine'],
        numbersAsWordBetween10And20 = [
            'Ten', 'Eleven', 'Twelve', 'Thirteen', 'Fourteen', 'Fifteen',
            'Sixteen', 'Seventeen', 'Eighteen', 'Nineteen', 'Twenty'
        ];

    if (number > 99) {
        digit = number / 100;
        number %= 100;
        toLower = true;
        numberAsWord += digitsAsWord[digit] + ' hundred and';
    }

    if (number >= 10 && number <= 20) {
        if (toLower) {
            numberAsWord += numbersAsWordBetween10And20[number % 10].toLowerCase();
        } else {
            numberAsWord += numbersAsWordBetween10And20[number % 10];
        }
    } else {

    }
}
