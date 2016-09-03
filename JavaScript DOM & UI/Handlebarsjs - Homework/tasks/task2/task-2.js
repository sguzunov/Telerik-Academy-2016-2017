window.addEventListener('load', function() {
    'use strict';

    let data = {
        animals: [{
            name: 'Lion',
            url: 'https://susanmcmovies.files.wordpress.com/2014/12/the-lion-king-wallpaper-the-lion-king-2-simbas-pride-4685023-1024-768.jpg'
        }, {
            name: 'Turtle',
            url: 'http://www.enkivillage.com/s/upload/images/a231e4349b9e3f28c740d802d4565eaf.jpg'
        }, {
            name: 'Dog'
        }, {
            name: 'Cat',
            url: 'http://i.imgur.com/Ruuef.jpg'
        }, {
            name: 'Dog Again'
        }]
    };

    let htmlTemplate = '<div class="container">' +
        '<h1>Animals</h1>' +
        '<ul class="animals-list">' +
        '<li>' +
        '<a href="https://susanmcmovies.files.wordpress.com/2014/12/the-lion-king-wallpaper-the-lion-king-2-simbas-pride-4685023-1024-768.jpg">See a Lion</a>' +
        '</li>' +
        '<li>' +
        '<a href="http://www.enkivillage.com/s/upload/images/a231e4349b9e3f28c740d802d4565eaf.jpg">See a Turtle</a>' +
        '</li>' +
        '<li>' +
        '<a href="http://cdn.playbuzz.com/cdn/3170bee8-985c-47bc-bbb5-2bcb41e85fe9/d8aa4750-deef-44ac-83a1-f2b5e6ee029a.jpg">No link for Dog, here is Batman!</a>' +
        '</li> ' +
        '<li>' +
        '<a href="http://i.imgur.com/Ruuef.jpg">See a Cat</a>' +
        '</li>' +
        '<li>' +
        '<a href="http://cdn.playbuzz.com/cdn/3170bee8-985c-47bc-bbb5-2bcb41e85fe9/d8aa4750-deef-44ac-83a1-f2b5e6ee029a.jpg">No link for Dog Again, here is Batman!</a>' +
        '</li>' +

        '{{#each animals}}' +
        '<li>' +
        '{{#if url}}' +
        '<a href="{{this.url}}">See a {this.name}</a>' +
        '{{else}}' +
        '<a href="http://cdn.playbuzz.com/cdn/3170bee8-985c-47bc-bbb5-2bcb41e85fe9/d8aa4750-deef-44ac-83a1-f2b5e6ee029a.jpg">No link for {{this.name}}, here is Batman!</a>' +
        '{{/if}}' +
        '</li>' +
        '{{/each}}' +
        '</ul>' +
        '</div>';

    let template = Handlebars.compile(htmlTemplate);
    document.getElementsByTagName('body')[0].innerHTML += template(data);
});