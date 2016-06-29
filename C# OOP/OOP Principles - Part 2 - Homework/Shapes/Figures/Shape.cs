namespace Shapes.Figures
{
    using Shapes.Figures.Contracts;

    internal abstract class Shape : IShape, ICalculatableShape
    {
        public Shape(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height { get; set; }

        public double Width { get; set; }

        public abstract double CalculateSurface();
    }
}
