/* globals $ */

/*
Create a function that takes a selector and:
* Finds all elements with class `button` or `content` within the provided element
	* Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
	* Find the topmost `.content` element, that is before another `.button` and:
		* If the `.content` is visible:
			* Hide the `.content`
			* Change the content of the `.button` to "show"
		* If the `.content` is hidden:
			* Show the `.content`
			* Change the content of the `.button` to "hide"
		* If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
	* The provided ID is not a **jQuery object** or a `string`

*/
function solve() {
    'use strict';

    function isString(str) {
        return typeof(str) === 'string' || (str instanceof String);
    }

    return function(selector) {

        // Checks
        if (!selector) {
            throw {
                message: 'Selector cannot be null or undefined!'
            };
        }

        if (!isString(selector) && !(selector instanceof jQuery)) {
            throw {
                message: 'Selector must be a string or a jQuery object!'
            };
        }

        if (isString(selector)) {
            selector = $(selector);
        }

        if (!selector.length) {
            throw {
                message: 'Selector selects nothing!'
            };
        }

        selector.find('.button').each(function(i, button) {
            $(button).html('hide');
        });

        selector.on('click', '.button', function() {
            var $this = $(this),
                $content = $($this.next());
            while ($content.length) {
                if ($content.hasClass('content')) {
                    break;
                }

                $content = $($content.next());
            }

            if ($content.length) {
                if ($content.css('display') === 'none') {
                    $this.html('hide');
                    $content.css('display', '');
                } else {
                    $this.html('show');
                    $content.css('display', 'none');
                }
            }
        });
    };
}

module.exports = solve;