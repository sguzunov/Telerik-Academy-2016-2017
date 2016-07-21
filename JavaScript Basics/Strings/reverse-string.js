function solve(params) {
    let inputStr = params[0],
        reversed = '';

    for (let i = inputStr.length - 1; i >= 0; i -= 1) {
        reversed += inputStr[i];
    }

    console.log(reversed);
}