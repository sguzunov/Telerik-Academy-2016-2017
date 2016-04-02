using System;

namespace BankAccountData
{
    class Program
    {
        static void Main()
        {
            string holderFirstName = "Pesho";
            string holderMiddleName = "Peshov";
            string holderLastName = "Peshov";
            decimal balance = 9999.99M;
            string iban = "IT 99 A 01234 56789 012345678901";
            int firstCardNumber = 123;
            int secondCardNumber = 213;
            int thirdCardNumber = 321;

            Console.WriteLine(holderFirstName);
            Console.WriteLine(holderMiddleName);
            Console.WriteLine(holderLastName);
            Console.WriteLine(balance);
            Console.WriteLine(iban);
            Console.WriteLine(firstCardNumber);
            Console.WriteLine(secondCardNumber);
            Console.WriteLine(thirdCardNumber);
        }
    }
}
