window.onload = function() {
    let canvasObj = document.getElementById('the-canvas'),
        ctx = canvasObj.getContext('2d'),
        canvasWidth = canvasObj.width,
        canvasHeight = canvasObj.height,
        circle = {
            x: 5,
            y: canvasHeight / 2,
            radius: 5
        },
        stepX = 5,
        stepY = 5,
        deltas = [{
            x: stepX,
            y: stepY
        }, {
            x: stepX,
            y: -stepY
        }, {
            x: -stepX,
            y: -stepY
        }, {
            x: -stepX,
            y: stepY
        }],
        deltaIndex = 0;

    function drawCircle(circle) {
        ctx.clearRect(0, 0, canvasObj.width, canvasObj.height);
        ctx.beginPath();
        ctx.arc(circle.x, circle.y, circle.radius, 0, 2 * Math.PI);
        ctx.closePath();
        ctx.fill();
    }

    function nextDelta() {
        deltaIndex += 1;
        if (deltaIndex >= deltas.length) {
            deltaIndex = 0;
        }
    }

    function updatePosition(circle) {
        let isOutOfX = circle.x + circle.radius > canvasWidth || circle.x - circle.radius < 0;
        let isOutOfY = circle.y + circle.radius > canvasHeight || circle.y - circle.radius < 0;

        if (isOutOfX || isOutOfY) {
            nextDelta();
        }

        let delta = deltas[deltaIndex];
        circle.x += delta.x;
        circle.y += delta.y;
    }

    function moveCircle() {
        drawCircle(circle);
        updatePosition(circle);
        requestAnimationFrame(moveCircle);
    }

    moveCircle();
};