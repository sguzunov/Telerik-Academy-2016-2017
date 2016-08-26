namespace Events.Contracts
{
    using System;

    public interface IEvent : IComparable
    {
        DateTime Date { get; }

        string Title { get; }

        string Location { get; }
    }
}
