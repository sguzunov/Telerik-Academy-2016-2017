namespace Abstraction
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            IFigure circle = new Circle(5);
            double circlePerimeter = circle.CalculatePerimeter();
            double circleSurface = circle.CalculateSurface();
            Console.WriteLine("I am a circle. " + "My perimeter is {0:f2}. My surface is {1:f2}.", circlePerimeter, circleSurface);

            IFigure rectangle = new Rectangle(2, 3);
            double rectanglePerimeter = rectangle.CalculatePerimeter();
            double rectangleSurface = rectangle.CalculateSurface();
            Console.WriteLine("I am a rectangle. " + "My perimeter is {0:f2}. My surface is {1:f2}.", rectanglePerimeter, rectangleSurface);
        }
    }
}
