namespace Events
{
    using System;
    using Contracts;

    using Wintellect.PowerCollections;

    public class EventHolder : IEventHolder
    {
        private MultiDictionary<string, IEvent> eventsByTitle;
        private OrderedBag<IEvent> eventsOrderedByDate;

        public EventHolder()
        {
            this.eventsByTitle = new MultiDictionary<string, IEvent>(true);
            this.eventsOrderedByDate = new OrderedBag<IEvent>();
        }

        public void AddEvent(DateTime date, string title, string location)
        {
            var newEvent = new Event(date, title, location);
            this.eventsByTitle.Add(title.ToLower(), newEvent);
            this.eventsOrderedByDate.Add(newEvent);

            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;
            foreach (var eventToRemove in this.eventsByTitle[title])
            {
                removed++;
                this.eventsOrderedByDate.Remove(eventToRemove);
            }

            this.eventsByTitle.Remove(title);

            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<IEvent>.View eventsToShow = this.eventsOrderedByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                showed++;

                Messages.PrintEvent(eventToShow);
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}
