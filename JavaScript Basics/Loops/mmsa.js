function solve(args) {
    var min = +args[0],
        max = +args[0],
        sum = 0,
        average = 0,
        currentNumber,
        i;

    for (i = 0; i < args.length; i += 1) {
        currentNumber = +args[i];
        sum += currentNumber;
        if (min > currentNumber) {
            min = currentNumber;
        }

        if (max < currentNumber) {
            max = currentNumber;
        }
    }

    average = (sum / args.length).toFixed(2);
    max = max.toFixed(2);
    min = min.toFixed(2);
    sum = sum.toFixed(2);

    console.log('min=' + min.toFixed(2));
    console.log('max=' + max);
    console.log('sum=' + sum);
    console.log('avg=' + average);
}

solve(['2', '5', '1']);