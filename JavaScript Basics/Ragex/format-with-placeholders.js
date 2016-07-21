function solve(params) {
    String.prototype.formatPlaceholders = function(options) {
        options = options || {};

        let text = this;
        for (let prop in options) {
            let regex = new RegExp('#{' + prop + '}', 'g');
            text = text.replace(regex, options[prop]);
        }

        return text;
    };

    let options = JSON.parse(params[0]),
        text = params[1];

    let formated = text.formatPlaceholders(options);
    console.log(formated);
}


solve([
    '{ "name": "John" }',
    "Hello, there! Are you #{name}?"
]);