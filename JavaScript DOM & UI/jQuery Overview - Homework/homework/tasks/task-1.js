/* globals $ */

/*

Create a function that takes a selector and COUNT, then generates inside a UL with COUNT LIs:
  * The UL must have a class `items-list`
  * Each of the LIs must:
    * have a class `list-item`
    * content "List item #INDEX"
      * The indices are zero-based
  * If the provided selector does not selects anything, do nothing
  * Throws if
    * COUNT is a `Number`, but is less than 1
    * COUNT is **missing**, or **not convertible** to `Number`
      * _Example:_
        * Valid COUNT values:
          * 1, 2, 3, '1', '4', '1123'
        * Invalid COUNT values:
          * '123px' 'John', {}, []
*/


function solve() {
    'use strict';

    return function(selector, count) {
        var i,
            $list,
            $item,
            $container;

        if (selector === undefined || selector === null) {
            throw {
                message: 'Selector cannot be undefined ot null!'
            };
        }

        if (typeof(selector) !== 'string' && !(selector instanceof String)) {
            throw {
                message: 'Selector must be a string!'
            };
        }

        if (!count) {
            throw {
                message: 'Count is missing!'
            };
        }

        count = +count;
        if (isNaN(count)) {
            throw {
                message: 'Count is invalid format number!!'
            };
        }

        if (count < 1) {
            throw {
                message: 'Count must be bigger than 1!'
            };
        }

        $container = $(selector);
        if (!$container.length) {
            return;
        }

        $list = $('<ul />')
            .addClass('items-list');
        $item = $('<li />')
            .addClass('list-item');

        for (i = 0; i < count; i += 1) {
            $item.html(`List item #${i}`);
            $list.append($item.clone());
        }

        $list.appendTo($container);
    };
}

module.exports = solve;