namespace Abstraction
{
    using System;

    public class Circle : IFigure
    {
        private double radius;

        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius should be bigger than 0!");
            }

            this.radius = radius;
        }

        public double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.radius;

            return perimeter;
        }

        public double CalculateSurface()
        {
            double surface = Math.PI * this.radius * this.radius;

            return surface;
        }
    }
}
