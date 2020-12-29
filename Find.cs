using System;
using HW2;

namespace Task1._3
{
    class Find
    {
        static void Main(string[] args)
        {
            Account[] accounts = CreateAccountsArray();

            int id = new Random().Next(0, 10001);

            foreach (var account in accounts)
            {
                Console.WriteLine(account.id);
            }

            GetAccount(accounts[id].id, accounts);
        }

        public static void GetAccount(int id, Account[] accounts)
        {
            int left = 0, right = accounts.Length - 1, middle, index = 0, tries = 0;
            bool Is_Found = false;
            
            while(left <= right)
            {
                tries++;
                middle = (left + right) / 2;
                
                if (accounts[middle].id == id)
                {
                    index = middle;
                    Is_Found = true;
                    break;
                }
                else if (accounts[middle].id > id) right = middle - 1;
                else left = middle + 1;
            }

            if (Is_Found) Console.WriteLine("Account {0} was found at index {1} by {2} tries", id, index, tries);
            else Console.WriteLine("There is no account {0} in the list", id);
        } 

       private static Account[] CreateAccountsArray()
        {
            Account[] accounts = new Account[10000];
            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Account("UAH");
            }
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
            return accounts;
        }
    }
}
