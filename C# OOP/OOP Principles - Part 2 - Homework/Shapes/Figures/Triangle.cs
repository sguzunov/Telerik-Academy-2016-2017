namespace Shapes.Figures
{
    internal class Triangle : Shape
    {
        public Triangle(double height, double width) : base(height, width)
        {
        }

        public override double CalculateSurface()
        {
            double surface = (this.Height * this.Width) / 2;
            return surface;
        }
    }
}
