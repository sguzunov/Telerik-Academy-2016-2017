/*
    Create the famous game "Snake":

    The snake is a sequence of rectangles/ellipses
    The snake can move left, right, up or down
    The snake dies if it reaches any of the edges or when it tries to eat itself
    A food should be generated
    When the snake eats the food, it grows and new food is generated at random position
    Implement a high-score board, kept in localStorage
*/

window.onload = function() {
    const snakePieceRadius = 5,
        foodColor = '#e55b5b',
        step = 2;

    let canvasObj = document.getElementById('the-canvas'),
        ctx = canvasObj.getContext('2d'),
        canvasWidth = canvasObj.width,
        canvasHeight = canvasObj.height,
        Snake,
        direction = 'right',
        directionsDelta = {
            up: {
                x: 0,
                y: -step
            },
            right: {
                x: step,
                y: 0
            },
            down: {
                x: 0,
                y: step
            },
            left: {
                x: -step,
                y: 0
            },
        };

    function drawCircle(position, radius, fillColor) {
        ctx.fillStyle = fillColor ? fillColor : ctx.fillStyle;
        ctx.beginPath();
        ctx.arc(position.x, position.y, radius, 0, 2 * Math.PI);
        ctx.closePath();
        ctx.fill();
    }


    Snake = function() {
        const snakePieceRadius = 5,
            snakeInitialLength = 3,
            snakeColor = '#2ed5e8';

        function Snake() {
            this.pieces = [];
        }

        Snake.prototype = {
            create: function() {
                for (let i = snakeInitialLength; i >= 0; i -= 1) {
                    this.pieces.push({
                        x: i * snakePieceRadius * 2 + snakePieceRadius,
                        y: snakePieceRadius,
                        dir: 'right'
                    });
                }

                return this;
            },
            render: function(drawer) {
                this.pieces.forEach(function(piece) {
                    drawer(piece, snakePieceRadius, snakeColor);
                }, this);

                return this;
            },
            move: function(delta) {
                for (let i = this.piece.length - 1; i > 0; i -= 1) {
                    // let
                }
            }
        };

        return Snake;
    }();

    // let snake = new Snake().create().render(drawCircle);
};