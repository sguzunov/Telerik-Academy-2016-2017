namespace Events
{
    using System.Text;

    using Contracts;

    public static class Messages
    {
        private const string EventAddedMessage = "Event added";
        private const string NoEventsMessage = "No events found";
        private const string EventsDeletedMessageFormat = "{0} events deleted";

        private static StringBuilder output;

        static Messages()
        {
            output = new StringBuilder();
        }

        public static string GetOutput()
        {
            return output.ToString();
        }

        public static void EventAdded()
        {
            output.AppendLine(EventAddedMessage);
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendLine(string.Format(EventsDeletedMessageFormat, x));
            }
        }

        public static void NoEventsFound()
        {
            output.AppendLine(NoEventsMessage);
        }

        public static void PrintEvent(IEvent eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.AppendLine(eventToPrint.ToString());
            }
        }
    }
}
