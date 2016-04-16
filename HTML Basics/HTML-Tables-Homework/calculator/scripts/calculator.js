(function() {
    document.getElementById('calculator')
        .addEventListener('click', function(ev) {
            var target = ev.target;
            if (target.tagName.toUpperCase() == 'INPUT' && target.type == 'button') {
                var targetValue = target.value;
                document.getElementById('calculator-result').value += targetValue;
            }
        });
}());
