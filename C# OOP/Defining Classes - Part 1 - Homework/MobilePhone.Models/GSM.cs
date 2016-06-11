namespace MobilePhone.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MobilePhone.Models.Common;

    public class GSM
    {
        private const string MissingField = "---";
        private const decimal IPhone4sPrice = 800M;
        private const double IPhone4sDisplaySize = 4.0;
        private const long IPhone4sDisplayColors = 16000000;

        private static GSM iPhone4S = new GSM(
            "IPhone4S",
            "Apple",
            IPhone4sPrice,
            "John Johnson",
            new Battery("LLL", 300, 14, BatteryType.LiIon),
            new Display(IPhone4sDisplaySize, IPhone4sDisplayColors));

        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private IList<Call> callHistory;

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.callHistory = new List<Call>();
        }

        public GSM(
            string model,
            string manufacturer,
            decimal? price = null,
            string owner = null)
            : this(model, manufacturer)
        {
            this.Price = price;
            this.Owner = owner;
        }

        public GSM(
            string model,
            string manufacturer,
            decimal? price,
            string owner,
            Battery battery = null,
            Display display = null)
            : this(model, manufacturer, price, owner)
        {
            this.Battery = battery;
            this.Display = display;
        }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
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

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                DataValidator.CheckIfNullOrEmptyValue(value, "Model");
                this.manufacturer = value;
            }
        }

        public decimal? Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Price cannot be null!");
                }

                DataValidator.CheckIfNegativeOrZeroValue(value.Value, "Price");
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                DataValidator.CheckIfNullOrEmptyValue(value, "Owner");
                this.owner = value;
            }
        }

        public Battery Battery { get; set; }

        public Display Display { get; set; }

        public IList<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
        }

        public static decimal CalculateCallsPrice(decimal pricePerMinute, IList<Call> calls)
        {
            decimal totalPrice = 0.0M;
            foreach (var call in calls)
            {
                int minutes = call.Duration / 60;
                totalPrice += minutes * pricePerMinute;
            }

            return totalPrice;
        }

        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            if (!this.CallHistory.Contains(call))
            {
                throw new InvalidOperationException("Such a call does not exists!");
            }

            this.CallHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        public override string ToString()
        {
            var viewBuilder = new StringBuilder();
            viewBuilder.AppendLine($"Model: {this.Model}");
            viewBuilder.AppendLine($"Manufacturer: {this.Manufacturer}");
            viewBuilder.AppendLine(string.Format("Price: {0}", this.Price != null ? this.Price.ToString() : MissingField));
            viewBuilder.AppendLine($"Owner: {this.Owner ?? MissingField}");
            if (this.Battery != null)
            {
                viewBuilder.Append(Battery.ToString());
            }

            if (this.Display != null)
            {
                viewBuilder.Append(Display.ToString());
            }

            return viewBuilder.ToString();
        }
    }
}
