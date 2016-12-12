using System;

namespace Dealership.Exceptions
{
    public class NotExistingUserException : Exception
    {
        public NotExistingUserException(string message) : base(message)
        {
        }
    }
}
