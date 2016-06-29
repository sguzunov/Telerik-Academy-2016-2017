namespace RangeExceptions.Exceptions
{
    using System;

    internal class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException(string message, T from, T to) : this(message, from, to, null)
        {
        }

        public InvalidRangeException(string message, T from, T to, Exception innerException) : base(message, innerException)
        {
            this.From = from;
            this.To = to;
        }

        public T From { get; set; }

        public T To { get; set; }

        public override string Message
        {
            get
            {
                string result = $"{base.Message} Accepted range:[From: {this.From}, To: {this.To}]";
                return result;
            }
        }
    }
}
