(function($) {
    'use strict';

    $.fn.listview = function(data) {
        let $list = $(this);
        let templateId = $list.attr('data-template');
        let htmlTemplate = $('#' + templateId).html();
        let template = Handlebars.compile(htmlTemplate);
        let $fragment = $('<div/>');

        data.forEach(function(element) {
            $fragment.html($fragment.html() + template(element));
        }, this);

        $list.html($fragment.html());
    };

}(jQuery));