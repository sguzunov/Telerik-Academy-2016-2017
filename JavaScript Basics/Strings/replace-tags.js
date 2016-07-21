// // function solve(params) {
// //     'use strict';

// //     const Href = "href=\"";
// //     const AnchorCloseTag = "</a>";

// //     let linkStartIndex = 0,
// //         inAnchor = false,
// //         inLink = false,
// //         markDown = ``,
// //         link = ``,
// //         html = params[0];

// //     for (let i = 0; i < html.length; i++) {
// //         if (inAnchor) {
// //             if (inLink) {
// //                 if (html[i] !== '"') {
// //                     link += html[i];
// //                 } else {
// //                     link += ")";
// //                     inLink = false;
// //                     i = html.indexOf('>', i);
// //                     markDown += '[';
// //                 }
// //             }

// //             // In content
// //             else {
// //                 if (html[i] === '<' && html[i + 1] === '/' && html[i + 2] === 'a') {
// //                     markDown += ']' + link;
// //                     inAnchor = false;
// //                     i += AnchorCloseTag.length - 1;

// //                     // Ready for a new link.
// //                     link = ``;
// //                 } else {
// //                     markDown += html[i];
// //                 }
// //             }
// //         } else if (isAnchorStart(i, html)) {
// //             inAnchor = true;
// //             inLink = true;
// //             linkStartIndex = html.indexOf(Href, i) + Href.length - 1;
// //             i = linkStartIndex;
// //             link += '(';
// //         } else {
// //             markDown += html[i];
// //         }
// //     }

// //     function isAnchorStart(index, html) {
// //         return html[i] === '<' && html[i + 1] === 'a';
// //     }

// //     console.log(markDown);
// // }

// function solve(params) {
//     let text = params[0];


// }

// solve(['<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>']);
// //      <p>Please visit [our site](http://academy.telerik.com) to choose a training course. Also visit [our forum](www.devbg.org) to discuss the courses.</p>


function replaceTags(text) {
    text = text.replace(/<a href="/g, ' [URL=');
    text = text.replace(/">/g, ']');
    text = text.replace(/<\/a>/g, '/URL]');

    return text;
}

var text = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';

console.log(replaceTags(text));