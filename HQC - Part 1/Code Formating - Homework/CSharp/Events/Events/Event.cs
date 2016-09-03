namespace Events
{
    using System;
    using System.Text;

    using Events.Contracts;

    public class Event : IEvent, IComparable
    {
        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; private set; }

        public string Title { get; private set; }

        public string Location { get; private set; }

        public int CompareTo(object obj)
        {
            IEvent other = obj as IEvent;
            int comparedByDate = this.Date.CompareTo(other.Date);
            int comparedByTitle = this.Title.CompareTo(other.Title);
            int comparedByLocation = this.Location.CompareTo(other.Location);
            if (comparedByDate == 0)
            {
                if (comparedByTitle == 0)
                {
                    return comparedByLocation;
                }
                else
                {
                    return comparedByTitle;
                }
            }
            else
            {
                return comparedByDate;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            string dateFormat = "yyyy-MM-ddTHH:mm:ss";

            builder.Append(this.Date.ToString(dateFormat));
            builder.Append(" | " + this.Title);
            if (this.Location != null && this.Location != string.Empty)
            {
                builder.Append(" | " + this.Location);
            }

            return builder.ToString();
        }
    }
}
