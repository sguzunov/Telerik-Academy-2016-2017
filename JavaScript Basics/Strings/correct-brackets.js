function solve(params) {
    let input = params[0],
        openBrackets = 0,
        closeBrackets = 0;

    for (let i = 0; i < input.length; i += 1) {
        let char = input[i];
        if (char === `(`) {
            openBrackets += 1;
        } else if (char === `)`) {
            if (openBrackets === 0) {
                return `Incorrect`;
            }

            closeBrackets += 1;
        }
    }

    return openBrackets === closeBrackets ? `Correct` : `Incorrect`;
}

console.log(solve([')(a+b))']));