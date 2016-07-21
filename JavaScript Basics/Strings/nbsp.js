// function solve(params) {
//     const nbsp = `&nbsp;`;

//     let text = params[0],
//         changedText = ``;

//     for (let i = 0; i < text.length; i += 1) {
//         let char = text[i];
//         if (char === ` `) {
//             changedText += nbsp;
//         } else {
//             changedText += char;
//         }
//     }

//     console.log(changedText);
// }

function solve(params) {
    const nbsp = `&nbsp;`;

    let text = params[0],
        changedText = text.replace(/\s/g, nbsp);

    console.log(changedText);
}

solve(['This text contains 4 spaces!!']);