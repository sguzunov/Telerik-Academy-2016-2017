(function() {
    var elements = document.getElementsByTagName('input');
    for (var i = 0; i < elements.length; i++) {
    	console.log(elements[i]);
    	elements[i].style.backgroundColor='red';
    }
}());
