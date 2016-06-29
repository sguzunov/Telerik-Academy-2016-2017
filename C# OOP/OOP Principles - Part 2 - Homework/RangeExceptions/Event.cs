namespace RangeExceptions
{
    using System;

    using Exceptions;

    internal class Event
    {
        private static readonly DateTime FromDate = new DateTime(1980, 01, 01);
        private static readonly DateTime ToDate = new DateTime(2013, 12, 31);

        private DateTime date;

        public Event(DateTime date)
        {
            this.Date = date;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                if (value < FromDate || value > ToDate)
                {
                    throw new InvalidRangeException<DateTime>(string.Format("Invalid date {0} for event!", date), FromDate, ToDate);
                }

                this.date = value;
            }
        }
    }
}
