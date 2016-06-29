namespace BankAccounts.Accounts
{
    using Contracts;
    using Exceptions;

    internal class LoanAccount : BankAccount, IDepositable
    {
        public LoanAccount(ICustomer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
        {
        }

        public void Deposite(decimal ammount)
        {
            if (ammount < 0.0M)
            {
                throw new BankException("Deposited money cannot be negative!");
            }

            this.Balance += ammount;
        }

        public override decimal CalculateInterestAmount(int months)
        {
            decimal interestAmmount = 0.0M;
            if (this.Customer is Company && months > 2)
            {
                interestAmmount = this.InterestRate * (months - 2);
            }
            else if (this.Customer is Individual && months > 3)
            {
                interestAmmount = this.InterestRate * (months - 3);
            }

            return interestAmmount;
        }
    }
}
