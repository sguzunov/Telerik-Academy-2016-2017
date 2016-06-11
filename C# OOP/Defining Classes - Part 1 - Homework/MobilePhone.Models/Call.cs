namespace MobilePhone.Models
{
    using System;

    using Common;

    public class Call
    {
        private ushort duration;

        public Call(string dialledNumber, ushort duration)
        {
            this.DateAndTime = DateTime.Now;
            this.DialledNumber = dialledNumber;
            this.Duration = duration;
        }

        public Call(DateTime dateAndTime, string dialledNumber, ushort duration) : this(dialledNumber, duration)
        {
            this.DateAndTime = dateAndTime;
        }

        public DateTime DateAndTime { get; set; }

        public string DialledNumber { get; set; }

        public ushort Duration
        {
            get
            {
                return this.duration;
            }

            set
            {
                DataValidator.CheckIfNegativeOrZeroValue(value, "Duration");
                this.duration = value;
            }
        }

        public override string ToString()
        {
            string view = $"Number: {this.DialledNumber}, Dialled on: {this.DateAndTime.ToString("dd/MM/yyy HH:mm:ss")}, Call duration: {this.duration} s";
            return view;
        }
    }
}
