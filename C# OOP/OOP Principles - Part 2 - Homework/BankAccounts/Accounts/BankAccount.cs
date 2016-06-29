namespace BankAccounts.Accounts
{
    using System;

    using BankAccounts.Contracts;

    internal class BankAccount : IBankAccount
    {
        private decimal balance;
        private decimal interestRate;

        public BankAccount(ICustomer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            protected set
            {
                if (value < 0M)
                {
                    throw new ArgumentException("Acoount balance cannot be negative!");
                }

                this.balance = value;
            }
        }

        public ICustomer Customer { get; private set; }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }

            private set
            {
                if (value < 0M)
                {
                    throw new ArgumentException("Acoount interest rate cannot be negative!");
                }

                this.interestRate = value;
            }
        }

        public virtual decimal CalculateInterestAmount(int months)
        {
            decimal interestAmount = months * this.InterestRate;
            return interestAmount;
        }
    }
}
