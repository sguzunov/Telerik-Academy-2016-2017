namespace Shapes.Figures
{
    internal class Rectangle : Shape
    {
        public Rectangle(double height, double width) : base(height, width)
        {
        }

        public override double CalculateSurface()
        {
            double surface = this.Height * this.Width;
            return surface;
        }
    }
}
