function solve(args) {
    'use strict';

    var numbers = args[1].split(' ').map(function(x) {
            return +x;
        }),
        sortedNumbers = [];

    function getMax(index, numbers) {
        var i,
            maxElementIndex = index;
        for (i = index + 1; i < numbers.length; i += 1) {
            if (numbers[maxElementIndex] < numbers[i]) {
                maxElementIndex = i;
            }
        }

        return maxElementIndex;
    }

    function sortAscending(numbers) {
        var i,
            maxElementIndex = 0;
        for (i = 0; i < numbers.length; i += 1) {
            maxElementIndex = getMax(i, numbers);
            if (maxElementIndex !== i) {
                numbers[maxElementIndex] = numbers[maxElementIndex] ^ numbers[i];
                numbers[i] = numbers[maxElementIndex] ^ numbers[i];
                numbers[maxElementIndex] = numbers[maxElementIndex] ^ numbers[i];
            }
        }

        return numbers;
    }

    sortedNumbers = sortAscending(numbers).reverse();
    return sortedNumbers.join(' ');
}
