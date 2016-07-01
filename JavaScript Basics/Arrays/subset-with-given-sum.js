function solve(args) {
    var input = args[0],
        targetSum = args[1],
        numbers = input.slice(1),
        currentSum = numbers[0];

    function findSum(numbers, targetSum, currentSum, nextIndex = 1) {
        let isFound = false;
        for (let i = nextIndex; i < numbers.length; i += 1) {
            if (currentSum + numbers[i] === targetSum) {
                isFound = true;
            } else {
                isFound = findSum(numbers, targetSum, currentSum + numbers[i], i + 1);
            }

            if (isFound) {
                break;
            }
        }

        return isFound;
    }

    return findSum(numbers, targetSum, numbers[0]);
}

console.log(solve([
    [2, 1, 2, 4, 3, 5, 2, 6], 14
]));