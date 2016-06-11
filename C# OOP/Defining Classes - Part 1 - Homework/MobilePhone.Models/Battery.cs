namespace MobilePhone
{
    using System.Text;

    using Models.Common;

    public class Battery
    {
        private string model;
        private int hoursIdle;
        private int hoursTalk;

        public Battery(string model, int hoursIdle, int hoursTalk, BatteryType type)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.Type = type;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                DataValidator.CheckIfNullOrEmptyValue(value, "Model");
                this.model = value;
            }
        }

        public int HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }

            set
            {
                DataValidator.CheckIfNegativeOrZeroValue(value, "Hours idle");
                this.hoursIdle = value;
            }
        }

        public int HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }

            set
            {
                DataValidator.CheckIfNegativeOrZeroValue(value, "Hours talk");
                this.hoursTalk = value;
            }
        }

        public BatteryType Type { get; set; }

        public override string ToString()
        {
            var viewBuilder = new StringBuilder();
            viewBuilder.AppendLine($"Model: {this.Model}");
            viewBuilder.AppendLine($"Hours idle: {this.HoursIdle}");
            viewBuilder.AppendLine($"Hours talk: {this.HoursTalk}");
            viewBuilder.AppendLine($"Type: {this.Type}");
            return viewBuilder.ToString();
        }
    }
}
