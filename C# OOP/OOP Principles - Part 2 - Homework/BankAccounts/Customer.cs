namespace BankAccounts
{
    using System;
    using BankAccounts.Contracts;

    internal class Customer : ICustomer
    {
        public Customer(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
