/* globals $ */

/*

Create a function that takes an id or DOM element and:

  If an id is provided, select the element
  Finds all elements with class button or content within the provided element
    Change the content of all .button elements with "hide"
  When a .button is clicked:
    Find the topmost .content element, that is before another .button and:
      If the .content is visible:
        Hide the .content
        Change the content of the .button to "show"
      If the .content is hidden:
        Show the .content
        Change the content of the .button to "hide"
      If there isn't a .content element after the clicked .button and before other .button, do nothing
  Throws if:
  The provided DOM element is non-existant
  The id is neither a string nor a DOM element
*/

function solve() {
    'use strict';

    function isString(str) {
        return typeof(str) === 'string' || str instanceof String;
    }

    return function(selector) {
        if (!selector) {
            throw {
                message: 'Selector cannot be null or undefined!'
            };
        }

        if (!isString(selector) && !(selector instanceof HTMLElement)) {
            throw {
                message: 'Selector must be a string or any DOM element!'
            };
        }

        if (isString(selector)) {
            selector = document.getElementById(selector);
        }

        if (!selector) {
            throw {
                message: 'Element is not existing!'
            };
        }

        let buttons = selector.querySelectorAll('.button');
        for (let i = 0, len = buttons.length; i < len; i += 1) {
            buttons[i].innerHTML = 'hide';
        }

        selector.addEventListener('click', function(ev) {
            let target = ev.target;
            if (target.className.indexOf('button') < 0) {
                return;
            }

            let nextEl = target.nextElementSibling,
                topMostContent,
                isValidTopMostContent = false;

            while (nextEl) {
                if (nextEl.className.indexOf('content') >= 0) {
                    // let hasButtonAfterContent = nextEl.nextElementSibling &&
                    // nextEl.nextElementSibling.className.indexOf('button');
                    // if (hasButtonAfterContent) {
                    // isValidTopMostContent = true;
                    topMostContent = nextEl;
                    // }

                    break;
                }

                nextEl = nextEl.nextElementSibling;
            }

            // if (isValidTopMostContent) {
            if (topMostContent.style.display === 'none') {
                topMostContent.style.display = '';
                target.innerHTML = 'hide';
            } else {
                topMostContent.style.display = 'none';
                target.innerHTML = 'show';
            }
            // }

        }, false);
    };
}

module.exports = solve;