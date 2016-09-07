namespace Abstraction
{
    using System;

    public class Rectangle : IFigure
    {
        private readonly double height;
        private readonly double width;

        public Rectangle(double height, double width)
        {
            if (height <= 0 || width <= 0)
            {
                throw new ArgumentException("Height and width should be bigger than 0!");
            }

            this.height = height;
            this.width = width;
        }

        public double CalculatePerimeter()
        {
            double perimeter = (2 * this.height) + (2 * this.width);

            return perimeter;
        }

        public double CalculateSurface()
        {
            double surface = this.height * this.width;

            return surface;
        }
    }
}
