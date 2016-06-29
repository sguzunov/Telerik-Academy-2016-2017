namespace Shapes
{
    using System;
    using System.Collections.Generic;

    using Figures;
    using Figures.Contracts;

    internal class Test
    {
        private static void Main()
        {
            Shape[] shapes =
            {
                new Rectangle(3, 4.2),
                new Triangle(5, 7),
                new Square(7)
            };

            PrintSurfaces(shapes);
        }

        private static void PrintSurfaces(IEnumerable<ICalculatableShape> shapes)
        {
            foreach (var shape in shapes)
            {
                double surface = shape.CalculateSurface();
                Console.WriteLine(surface);
            }
        }
    }
}
