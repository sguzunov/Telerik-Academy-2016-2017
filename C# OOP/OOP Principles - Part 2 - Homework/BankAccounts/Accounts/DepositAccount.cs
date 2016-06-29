namespace BankAccounts.Accounts
{
    using Contracts;
    using Exceptions;

    internal class DepositAccount : BankAccount, IDepositable, IWithdrawable
    {
        public DepositAccount(ICustomer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
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

        public void WithDraw(decimal ammount)
        {
            if (ammount < 0M)
            {
                throw new BankException("Cannot with draw negative ammouny of money!");
            }

            this.Balance -= ammount;
        }

        public override decimal CalculateInterestAmount(int months)
        {
            decimal interestAmmount = 0.0M;
            if (this.Balance < 0 || this.Balance >= 1000)
            {
                interestAmmount = base.CalculateInterestAmount(months);
            }

            return interestAmmount;
        }
    }
}
