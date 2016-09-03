namespace RotatedSize
{
    using System;

    public class Figure : IFigure
    {
        private double width;
        private double height;

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height should be greater than 0!");
                }

                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width should be greater than 0!");
                }

                this.width = value;
            }
        }

        public static IFigure GetRoratedFigure(IFigure figure, double angle)
        {
            double angleSinusAbsoluteValue = Math.Abs(Math.Sin(angle));
            double angleCosinusAbsoluteValue = Math.Abs(Math.Cos(angle));
            double width = (angleCosinusAbsoluteValue * figure.Width) +
                (angleSinusAbsoluteValue * figure.Height);
            double height = (angleSinusAbsoluteValue * figure.Width) +
                (angleCosinusAbsoluteValue * figure.Height);

            var rotatedFigure = new Figure(width, height);

            return rotatedFigure;
        }
    }
}
