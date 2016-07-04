function solve(args) {
    Array.prototype.remove = function(element) {
        var i;
        for (i = 0; i < this.length; i += 1) {
            if (this[i] === element) {
                this.splice(i, 1);
                i -= 1;
            }
        }
    };

    var elements = args;
    elements.remove(elements[0]);
    elements.forEach(function(element) {
        console.log(element);
    });
}