(function() {
    'use strict';

    var browserName = navigator.appName,
        addScroll = false,
        off = 0,
        text = "",
        pageX = 0,
        pageY = 0;
    if (navigator.userAgent.indexOf('MSIE 5') >= 0 || navigator.userAgent.indexOf('MSIE 6') >= 0) {
        addScroll = true;
    }

    document.addEventListener('mousemove', mouseMove);

    if (browserName === "Netscape") {
        document.captureEvents(Event.MOUSEMOVE);
    }

    function mouseMove(ev) {
        if (browserName === "Netscape") {
            pageX = ev.pageX - 5;
            pageY = ev.pageY;
            if (document.layers.ToolTip.visibility === 'show') {
                PopTip();
            }
        } else {
            pageX = event.x - 5;
            pageY = event.y;
            if (document.all.ToolTip.style.visibility === 'visible') {
                PopTip();
            }
        }
    }

    function PopTip() {
        if (browserName === "Netscape") {
            theLayer = document.layersToolTip;
            if ((pageX + 120) > window.innerWidth) {
                pageX = window.innerWidth - 150;
            }

            theLayer.left = pageX + 10;
            theLayer.top = pageY + 15;
            theLayer.visibility = 'show';
        } else {
            theLayer = document.all.ToolTip;
            if (theLayer) {
                pageX = event.x - 5;
                pageY = event.y;
                if (addScroll) {
                    pageX = pageX + document.body.scrollLeft;
                    pageY = pageY + document.body.scrollTop;
                }

                if ((pageX + 120) > document.body.clientWidth) {
                    pageX = pageX - 150;
                }

                theLayer.style.pixelLeft = pageX + 10;
                theLayer.style.pixelTop = pageY + 15;
                theLayer.style.visibility = 'visible';
            }
        }
    }

    function HideTip() {
        args = HideTip.arguments;
        if (browserName === "Netscape") {
            document.layersToolTip.visibility = 'hide';
        } else {
            document.all.ToolTip.style.visibility = 'hidden';
        }
    }

    function HideMenu(menu) {
        if (browserName === "Netscape") {
            document.layers[menu].visibility = 'hide';
        } else {
            document.all[menu].style.visibility = 'hidden';
        }
    }

    function ShowMenu(menu) {
        if (browserName === "Netscape") {
            theLayer = document.layers[menu];
            theLayer.visibility = 'show';
        } else {
            theLayer = document.all[menu];
            theLayer.style.visibility = 'visible';
        }
    }
}());