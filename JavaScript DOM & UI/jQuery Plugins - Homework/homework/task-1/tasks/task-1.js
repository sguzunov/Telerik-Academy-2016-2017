/* globals module, $, console */
'use strict';

function solve() {
    return function(selector) {
        var $selector = $(selector);
        $selector.hide();
        var $dropDown = $('<div />').append($selector).addClass('dropdown-list');
        var $options = $selector.find('option');
        var $currentOption = $('<div />').addClass('current').html($($options.first()).html());
        $currentOption.attr('data-value', $($options.first()).attr('value'));
        var $optionsContainer = $('<div />').addClass('options-container').css({
            'position': 'absolute',
            'display': 'none'
        });

        var $dropDownItem = $('<div />').addClass('dropdown-item');
        $options.each(function(i, option) {
            var $option = $(option);
            $dropDownItem.attr('data-value', $option.attr('value'));
            $dropDownItem.attr('data-index', i);
            $dropDownItem.html($option.html());
            $optionsContainer.append($dropDownItem.clone(true));
        });

        $currentOption.on('click', function() {
            if ($optionsContainer.css('display') === 'none') {
                $(this).html('Select an option');
                $optionsContainer.show();
            }
        });

        $optionsContainer.on('click', '.dropdown-item', function() {
            var $clickedOption = $(this);
            $selector.val($clickedOption.attr('data-value'));
            $currentOption.html($clickedOption.html());
            $currentOption.attr('data-value', $clickedOption.attr('data-value'));
            $optionsContainer.hide();
        });

        $currentOption.appendTo($dropDown);
        $optionsContainer.appendTo($dropDown);
        $dropDown.prependTo($('body'));
    };
}

module.exports = solve;