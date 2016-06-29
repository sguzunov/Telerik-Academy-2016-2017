namespace BankAccounts.Exceptions
{
    using System;

    internal class BankException : ApplicationException
    {
        public BankException(string message) : base(message)
        {
        }
    }
}
