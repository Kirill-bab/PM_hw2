using System;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
    public sealed class Player : IDisposable
    {
        private int Id { get; }
        public readonly string FirstName;
        public readonly string LastName;
        public readonly string Email;
        private string Password;
        Account Account;

        static int addNumb = 0;

        public Player(string Currency, string _FirstName, string _LastName, string _Email, string _Password)
        {
            Account = new Account(Currency);
            FirstName = _FirstName;
            LastName = _LastName;
            Email = _Email;
            Password = _Password;
            Id = GenerateId();
        }

        private int GenerateId()
        {
            if (addNumb > 50049999)
            {
                Console.WriteLine("Player list is full!");
                throw new StackOverflowException(nameof(addNumb));
            }
            int temp = 50050000 + addNumb;

            addNumb = -addNumb;

            if (addNumb >= 0) addNumb++;

            return temp;
        }

        public bool IsPasswordValid(string password)
        {
            return Password == password;
        }

        public void Deposit(decimal _Amount, string _Currency)
        {
            Account.Deposit(_Amount, _Currency);
        }

        public void Withdraw(decimal _Amount, string _Currency)
        {
            Account.Withdraw(_Amount, _Currency);
        }

        public decimal GetBalance(string _Currency)
        {
            decimal balance = Account.GetBalance(_Currency);
            Console.WriteLine($"You have {balance} {_Currency} on your account"  );
            return balance;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
