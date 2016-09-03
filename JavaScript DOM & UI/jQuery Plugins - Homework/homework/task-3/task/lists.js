/* globals $, console */

'use strict';

$.fn.lists = function(lists) {
    let $wrapper = $('<section />');
    let $itemsSection = $('<article/>').addClass('items-section');
    let $sectionTitle = $('<strong/>').html('Names');
    let $addPanel = $('<div/>').addClass('add-panel');
    var $addButton = $('<a/>').addClass('add-btn').appendTo($addPanel);
    var $addInput = $('<input/>').addClass('add-input')
        .appendTo($addPanel)
        .hide();

    let $itemsList = $('<ul/>').addClass('items-list');
    let $item = $('<li/>').addClass('item');
    $item.attr('draggable', true);

    for (let list of lists) {
        $itemsSection.empty();
        $itemsList.empty();

        $sectionTitle.html(list[0]);
        for (let i = 1; i < list.length; i += 1) {
            $item.html(list[i]);
            $itemsList.append($item.clone(true));
        }

        $itemsSection.append($sectionTitle.clone(true));
        $itemsSection.append($addPanel.clone(true));
        $itemsSection.append($itemsList.clone(true));
        $wrapper.append($itemsSection.clone(true));
    }

    $wrapper.on('click', '.add-btn', function() {
        let $this = $(this);
        $this.hide();
        $($this.next()).show();
    });

    $wrapper.on('drag', '.item', function(ev) {

    });

    // $addButton.on('click', function() {
    //     $(this).hide();
    //     $addInput.show();
    // });

    // $addInput.on('keypress', function(ev) {
    //     if (ev.keyCode === 13) {
    //         let $this = $(this);
    //         $this.hide();
    //         let value = $this.val();
    //         if (value !== '') {
    //             $item.html(value);
    //             $itemsList.append($item.clone());
    //             $(this).val('');
    //         }

    //         $addButton.show();
    //     }
    // });

    $wrapper.appendTo(this);
};