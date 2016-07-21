function solve(params) {
    'use strict';

    const openArrow = `<`,
        closeArrow = `<`,
        slash = `/`;

    let text = params[0],
        mixedTag = `orgcase`,
        upperTag = `upcase`,
        lowerTag = `lowcase`,
        tags = [],
        isInTag = false;

    for (let i = 0; i < text.length; i += 1) {
        let char = text[i];
        if (isInTag) {
            if (char === openArrow) {
                let tagName = extractName(i + 1, text);
                tags.push(tagName);
            }
        } else {
            if (char === openArrow) {
                let tagName = extractName(i + 1, text);
                tags.push(tagName);
            }
        }
    }

    function extractName(index, text) {
        let closeIndex = text.indexOf(closeArrow, index);
        return text.substring(index, closeIndex);
    }

    function isOpenTag(index, text) {
        return text[index] === openArrow && text[index + 1] !== slash;
    }
}

solve([
    'We are <orgcase>liViNg</orgcase> in a <upcase>yellow submarine</upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.'
]);