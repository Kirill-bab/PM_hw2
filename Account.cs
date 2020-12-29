using System;
using System.Collections.Generic;



namespace HW2
{
    public class Account
    {
        public int id { get; }
        static int addNumb = 0;
        string Currency;
        decimal Amount;

        public Account(string _Currency)
        {
            if (_Currency == "UAH" || _Currency == "EUR" || _Currency == "USD")
                Currency = _Currency;
            else 
                throw new NotSupportedException(nameof(_Currency));
            Amount = 0;
            id = GenerateId();
        }

        private static int GenerateId()
        {
            if(addNumb > 50050000)
            {
                Console.WriteLine("Accounts list is full!");
                throw new StackOverflowException(nameof(addNumb));
            }
            int temp = 50050000 + addNumb;

            addNumb = -addNumb;

            if (addNumb >= 0) addNumb++;

            return temp;            
        }
        public void Deposit(decimal _Amount, string _Currency)
        {
            if (!(_Currency == "UAH" || _Currency == "EUR" || _Currency == "USD") || _Amount < 0)
                throw new NotSupportedException(nameof(_Currency));

            if (Currency == _Currency)
            {
                Amount += _Amount;
                return;
            }

            switch (Currency)
            {
                case "USD":
                    if (_Currency == "EUR")
                        Amount += (decimal)1.19 * _Amount;
                    else
                        Amount += (decimal)(1 / 28.36) * _Amount;
                    break;

                case "UAH":
                    if (_Currency == "EUR")
                        Amount += (decimal)33.63 * _Amount;
                    else
                        Amount += (decimal)28.36 * _Amount;
                    break;

                case "EUR":
                    if (_Currency == "USD")
                        Amount += (decimal)(1 / 1.19) * _Amount;
                    else
                        Amount += (decimal)(1 / 33.63) * _Amount;
                    break;
            }
        }
        public void Withdraw(decimal _Amount, string _Currency)
        {
            if (!(_Currency == "UAH" || _Currency == "EUR" || _Currency == "USD") || _Amount < 0)
                throw new NotSupportedException(nameof(_Currency));

            if (Currency == _Currency) goto N;
            
            switch (Currency)
            {
                case "USD":
                    if (_Currency == "EUR")
                        _Amount = (decimal)1.19 * _Amount;
                    else
                        _Amount = (decimal)(1 / 28.36) * _Amount;
                    break;

                case "UAH":
                    if (_Currency == "EUR")
                        _Amount = (decimal)33.63 * _Amount;
                    else
                        _Amount = (decimal)28.36 * _Amount;
                    break;

                case "EUR":
                    if (_Currency == "USD")
                        _Amount = (decimal)(1 / 1.19) * _Amount;
                    else
                        _Amount = (decimal)(1 / 33.63) * _Amount;
                    break;
            }
            N: if (_Amount > Amount) throw new NotSupportedException(nameof(_Amount));

            Amount -= _Amount;
        }

        public decimal GetBalance(string _Currency)
        {
            if (!(_Currency == "UAH" || _Currency == "EUR" || _Currency == "USD"))
                throw new NotSupportedException(nameof(_Currency));

            if (Currency == _Currency)
                return Amount;

            switch (Currency)
            {
                case "USD":
                    if (_Currency == "EUR")
                        return (decimal)(1 / 1.19) * Amount;
                    else
                        return (decimal) 28.36 * Amount;

                case "UAH":
                    if (_Currency == "EUR")
                       return (decimal)(1 / 33.63) * Amount;
                    else
                        return (decimal)(1 / 28.36) * Amount;

                case "EUR":
                    if (_Currency == "USD")
                        return (decimal)1.19 * Amount;
                    else
                        return (decimal)33.63 * Amount;
            }
         
            return 0;
        }

    }

}
