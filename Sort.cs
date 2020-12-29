using System;
using HW2;

namespace Task_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Account[] accounts = new Account[1000000];
            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Account("UAH");
            }
            foreach (var item in accounts)
            {
                Console.WriteLine(item.id);
            }

            GetSortedAccounts(accounts);

            Console.WriteLine("First 10 accounts are:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(accounts[i].id);
            }

            Console.WriteLine("Last 10 accounts are:");
            for (int i = accounts.Length - 11; i < accounts.Length; i++)
            {
                Console.WriteLine(accounts[i].id);
            }
        }

        public static void GetSortedAccounts(Account[] accounts)
        {
            bool isSorted = false;
            Account temp;
            while (isSorted == false)
            {
                isSorted = true;
                for (int i = accounts.Length - 1; i > 0; i--)
                {
                    if (accounts[i].id < accounts[i - 1].id)
                    {
                        temp = accounts[i];
                        accounts[i] = accounts[i - 1];
                        accounts[i - 1] = temp;
                        isSorted = false;
                    }
                }
            }
        }
    }
}
