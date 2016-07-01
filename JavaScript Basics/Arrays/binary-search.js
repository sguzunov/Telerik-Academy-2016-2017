function solve(args) {
    var input = args[0].split('\n').map(function(x) {
            return +x;
        }),
        n = input[0],
        numbers = input.slice(1, input.length - 2),
        target = input[input.length - 1],
        left = 0,
        right = numbers.length - 1,
        middle = (numbers.length / 2) | 0;

    numbers.sort(function(x, y) {
        return x - y;
    });

    while (left <= right) {
        if (target > numbers[middle]) {
            left = middle + 1;
        } else if (target < numbers[middle]) {
            right = middle - 1;
        } else {
            return middle;
        }

        middle = ((right + left) / 2) | 0;
    }

    return -1;
}

console.log(solve(['10\n1\n2\n4\n8\n16\n31\n32\n64\n77\n99\n32']));