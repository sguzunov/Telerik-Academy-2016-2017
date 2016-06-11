namespace MobilePhone
{
    using System.Text;

    using MobilePhone.Models.Common;

    public class Display
    {
        private double size;
        private long numberOfColors;

        public Display(double size, long numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        public long NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }

            set
            {
                DataValidator.CheckIfNegativeOrZeroValue(value, "Number of colors");
                this.numberOfColors = value;
            }
        }

        public double Size
        {
            get
            {
                return this.size;
            }

            set
            {
                DataValidator.CheckIfNegativeOrZeroValue(value, "Size");
                this.size = value;
            }
        }

        public override string ToString()
        {
            var viewBuilder = new StringBuilder();
            viewBuilder.AppendLine($"Display size: {this.Size}");
            viewBuilder.Append($"Display colors: {this.numberOfColors}");
            return viewBuilder.ToString();
        }
    }
}
