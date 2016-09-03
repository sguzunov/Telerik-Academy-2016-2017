/* globals $ */

/*

Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element - Done
* Add divs to the element
  * Each div's content must be one of the items from the contents array - Done
* The function must remove all previous content from the DOM element provided - Done
* Throws if:
  * The provided first parameter is neither string or existing DOM element - Done
  * The provided id does not select anything (there is no element that has such an id) - Done
  * Any of the function params is missing - Done
  * Any of the function params is not as described - Done
  * Any of the contents is neither `string` or `number`
    * In that case, the content of the element **must not be** changed
*/

module.exports = function() {

    function isString(str) {
        return typeof(str) === 'string' || (str instanceof String);
    }

    function isNumber(num) {
        return typeof(num) === 'number' || (num instanceof Number);
    }

    function isValidContent(contents) {
        var i,
            content;
        for (i = 0; i < contents.length; i += 1) {
            content = contents[i];
            if (!isString(content) && !isNumber(content)) {
                return false;
            }
        }

        return true;
    }

    return function(element, contents) {
        var divContent = document.createElement('div'),
            fragment = document.createDocumentFragment(),
            i;

        // Not all params
        if (arguments.length < 2) {
            throw {
                message: 'Should have 2 params!'
            };
        }

        if (typeof(element) === 'undefined' || typeof(contents) === 'undefined') {
            throw {
                message: 'Cannot have a param of type "undefined"!'
            };
        }

        if (element === null || contents === null) {
            throw {
                message: 'Params cannot have null value!'
            };
        }

        if (!isString(element) && !(element instanceof HTMLElement)) {
            throw {
                message: 'First param should be a string or DOM element!'
            };
        }

        if (!Array.isArray(contents)) {
            throw {
                message: 'Second param should be array!'
            };
        }

        if (!isValidContent(contents)) {
            throw {
                message: 'Invalid content!'
            };
        }

        if (isString(element)) {
            element = document.getElementById(element);
        }

        if (!element) {
            throw {
                message: 'Not existing DOM element!'
            };
        }

        for (i = 0; i < contents.length; i += 1) {
            divContent.innerHTML = contents[i];
            fragment.appendChild(divContent.cloneNode(true));
        }

        element.innerHTML = '';
        element.appendChild(fragment);
    };
};