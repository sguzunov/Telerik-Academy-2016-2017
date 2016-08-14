window.addEventListener('load', function() {
    'use strict';

    let data = {
        headers: ['Vendor', 'Model', 'OS'],
        items: [{
            col1: 'Nokia',
            col2: 'Lumia 920',
            col3: 'Windows Phone'
        }, {
            col1: 'LG',
            col2: 'Nexus 5',
            col3: 'Android'
        }, {
            col1: 'Apple',
            col2: 'iPhone 6',
            col3: 'iOS'
        }]
    };

    let htmlTemplate = '<table class="items-table">' +
        '<thead>' +
        '<tr>' +
        '{{#each headers}}' +
        '<th>{{this}}</th>' +
        '{{/each}}' +
        '</tr>' +
        '</thead>' +
        '<tbody>' +
        '{{#each items}}' +
        '<tr>' +
        '<td>{{this.col1}}</td>' +
        '<td>{{this.col2}}</td>' +
        '<td>{{this.col3}}</td>' +
        '</tr>' +
        '{{/each}}' +
        '</tbody>' +
        '</table>';

    let template = Handlebars.compile(htmlTemplate);
    document.getElementById('container').innerHTML = template(data);
});