namespace BankAccounts.Accounts
{
    using Contracts;
    using Exceptions;

    internal class MortgageAccount : BankAccount, IDepositable
    {
        private const int YearMonths = 12;

        public MortgageAccount(ICustomer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
        {
        }

        public void Deposite(decimal ammount)
        {
            if (ammount < 0M)
            {
                throw new BankException("Deposited money cannot be negative!");
            }

            this.Balance += ammount;
        }

        public override decimal CalculateInterestAmount(int months)
        {
            decimal interestAmmount = 0.0M;
            if (this.Customer is Company)
            {
                if (months > 12)
                {
                    interestAmmount = ((this.InterestRate / 2) * YearMonths) + base.CalculateInterestAmount(months - 12);
                }
                else
                {
                    interestAmmount = (this.InterestRate / 2) * months;
                }
            }
            else if (this.Customer is Individual && months > 6)
            {
                interestAmmount = base.CalculateInterestAmount(months - 6);
            }

            return interestAmmount;
        }
    }
}
