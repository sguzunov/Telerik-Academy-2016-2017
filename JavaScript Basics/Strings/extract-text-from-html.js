function solve(params) {
    'use strict';

    let result = ``;
    params.forEach(function(line) {
        line = line.trim();
        result += line.replace(/<(.+?)>/g, ``).trim();
    });

    console.log(result);
}


solve([
    '<html>',
    '  <head>',
    '    <title>Sample site</title>',
    '  </head>',
    '  <body>',
    '    <div>text',
    '      <div>more text</div>',
    '      and more...',
    '    </div>',
    '    in body',
    '  </body>',
    '</html>'
]);