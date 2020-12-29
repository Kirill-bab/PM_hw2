using System;
using HW2;

namespace Task_1._1
{
    class TestAccounts
    {
        public static void Main(string[] args)
        {
            Account usd = new Account("USD");
            Account eur = new Account("EUR");
            Account uah = new Account("UAH");

            eur.Deposit(10, "EUR");
            eur.Withdraw(3, "UAH");
            uah.Deposit(121, "USD");

            try
            {
                usd.Withdraw(5, "USD");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Insufficient costs!");
            }

            try
            {
                Account pln = new Account("PLN");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Unsopported currency!");
            }

            Console.WriteLine("Account with currency {0} has {1} balance", "UAH", uah.GetBalance("UAH"));
            Console.WriteLine("Account with currency {0} has {1} balance", "USD", usd.GetBalance("USD"));
            Console.WriteLine("Account with currency {0} has {1} balance", "EUR", eur.GetBalance("EUR"));
        }
    }
}
