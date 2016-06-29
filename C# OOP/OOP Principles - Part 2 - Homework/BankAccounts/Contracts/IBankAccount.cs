namespace BankAccounts.Contracts
{
    internal interface IBankAccount
    {
        ICustomer Customer { get; }

        decimal Balance { get; }

        decimal InterestRate { get; }

        decimal CalculateInterestAmount(int months);
    }
}
