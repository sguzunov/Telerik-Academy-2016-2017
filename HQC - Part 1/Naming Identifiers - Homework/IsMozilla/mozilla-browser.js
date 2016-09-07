function onButtonClick(event, args) {
    var currentWindow = window,
        browser = currentWindow.navigator.appCodeName,
        isMozilla = browser === "Mozilla";

    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}