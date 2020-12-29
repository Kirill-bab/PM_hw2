using System;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
    public class Bank : PaymentMethodBase, ISupportDeposit, ISupportWithdrawal
    {
        protected string[] AvailableCards;
        protected decimal TransactionsSum = 0M;
        public virtual void StartDeposit(decimal amount, string currency) { }
       

        public virtual string StartWithdrawal(decimal amount, string currency) { return ""; }
        
    }

    public class Privet48 : Bank
    {        
        public Privet48()
        {
            Name = "Privet48";
            AvailableCards = new string[] { "Gold", "Platinum" };
        }

        public override void StartDeposit(decimal amount, string currency)
        {
            decimal sum = TransactionsSum;
            switch (currency)
            {
                case "USD":
                    sum += amount * (decimal)28.36;
                    break;
                case "EUR":
                    sum += amount * (decimal)33.63;
                    break;
                case "UAH":
                    sum += amount;
                    break;
                default:
                    throw new Exception();
            }
            if (sum > 10000) throw new PaymentServiceExeption();

            Console.WriteLine($"Welcome, dear client to the bank {Name}!");
            Console.Write("Please, enter your login: ");
            string login = Console.ReadLine();
            Console.Write("Please, enter your password: ");
            Console.ReadLine();
            Console.WriteLine($"\nHello Mr {login}. Pick a card to proceed the transaction:");
            int number;
            while (true)
            {
                for (int i = 0; i < AvailableCards.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {AvailableCards[i]}");
                }
                Console.WriteLine();
                Console.Write("Enter option number: ");

                if (!int.TryParse(Console.ReadLine(), out number) || number <= 0 || number > AvailableCards.Length)
                {
                    Console.WriteLine("Wrong option nuber! Try again!");
                    continue;
                }
                break;
            }
            number--;
            Console.WriteLine($"You have successfully withdraw {amount} {currency} from your {AvailableCards[number]} card");
            TransactionsSum += sum;
        }

        public override string StartWithdrawal(decimal amount, string currency)
        {
            decimal sum = TransactionsSum;
            switch (currency)
            {
                case "USD":
                    sum += amount * (decimal)28.36;
                    break;
                case "EUR":
                    sum += amount * (decimal)33.63;
                    break;
                case "UAH":
                    sum += amount;
                    break;
                default:
                    throw new Exception();
            }
            if (sum > 10000) throw new PaymentServiceExeption();

            Console.WriteLine($"Welcome, dear client to the bank {Name}!");
            Console.Write("Please, enter your login: ");
            string login = Console.ReadLine();
            Console.Write("Please, enter your password: ");
            Console.ReadLine();
            Console.WriteLine($"\nHello Mr {login}. Pick a card to proceed the transaction:");
            int number;
            while (true)
            {
                for (int i = 0; i < AvailableCards.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {AvailableCards[i]}");
                }
                Console.WriteLine();
                Console.Write("Enter option number: ");

                if (!int.TryParse(Console.ReadLine(), out number) || number <= 0 || number > AvailableCards.Length)
                {
                    Console.WriteLine("Wrong option nuber! Try again!");
                    continue;
                }
                break;
            }
            number--;
            TransactionsSum += sum;
            return $"You have successfully deposit {amount} {currency} to your {AvailableCards[number]} card";            
        }
    }
    public class Stereobank : Bank
    {
        public Stereobank()
        {
            Name = "Stereobank";
            AvailableCards = new string[] { "Black", "White", "Iron" };
        }

        public override void StartDeposit(decimal amount, string currency)
        {
            decimal totalSum = TransactionsSum;
            decimal currentSum = 0;
            switch (currency)
            {
                case "USD":
                    currentSum = amount * (decimal)28.36;
                    break;
                case "EUR":
                    currentSum = amount * (decimal)33.63;
                    break;
                case "UAH":
                    currentSum = amount;
                    break;
                default:
                    throw new Exception();
            }
            totalSum += currentSum;
            if (currentSum > 3000) throw new LimitExceedExeption();
            if (totalSum > 7000) throw new PaymentServiceExeption();

            Console.WriteLine($"Welcome, dear client to the bank {Name}!");
            Console.Write("Please, enter your login: ");
            string login = Console.ReadLine();
            Console.Write("Please, enter your password: ");
            Console.ReadLine();
            Console.WriteLine($"\nHello Mr {login}. Pick a card to proceed the transaction:");
            int number;
            while (true)
            {
                for (int i = 0; i < AvailableCards.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {AvailableCards[i]}");
                }
                Console.WriteLine();
                Console.Write("Enter option number: ");

                if (!int.TryParse(Console.ReadLine(), out number) || number <= 0 || number > AvailableCards.Length)
                {
                    Console.WriteLine("Wrong option nuber! Try again!");
                    continue;
                }
                break;
            }
            number--;
            Console.WriteLine($"You have successfully withdraw {amount} {currency} from your {AvailableCards[number]} card");
            TransactionsSum = totalSum;
        }
        public override string StartWithdrawal(decimal amount, string currency)
        {
            decimal totalSum = TransactionsSum;
            decimal currentSum = 0;
            switch (currency)
            {
                case "USD":
                    currentSum = amount * (decimal)28.36;
                    break;
                case "EUR":
                    currentSum = amount * (decimal)33.63;
                    break;
                case "UAH":
                    currentSum = amount;
                    break;
                default:
                    throw new Exception();
            }
            totalSum += currentSum;
            if (currentSum > 3000) throw new LimitExceedExeption();
            if (totalSum > 7000) throw new PaymentServiceExeption();

            Console.WriteLine($"Welcome, dear client to the bank {Name}!");
            Console.Write("Please, enter your login: ");
            string login = Console.ReadLine();
            Console.Write("Please, enter your password: ");
            Console.ReadLine();
            Console.WriteLine($"\nHello Mr {login}. Pick a card to proceed the transaction:");
            int number;
            while (true)
            {
                for (int i = 0; i < AvailableCards.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {AvailableCards[i]}");
                }
                Console.WriteLine();
                Console.Write("Enter option number: ");

                if (!int.TryParse(Console.ReadLine(), out number) || number <= 0 || number > AvailableCards.Length)
                {
                    Console.WriteLine("Wrong option nuber! Try again!");
                    continue;
                }
                break;
            }
            number--;
            TransactionsSum = totalSum;
            return $"You have successfully deposit {amount} {currency} to your {AvailableCards[number]} card";
        }
    }

    public class GiftVoucher : PaymentMethodBase, ISupportDeposit
    {
        public static List<GiftVoucher> AllVauchers = new List<GiftVoucher>(5);
        private bool IsUsed;
        public long number { get; private set; }
        public GiftVoucher()
        {            
            IsUsed = false;
            Name = "GiftVoucher";
            AllVauchers.Add(this);
            number = 0;
        }

        public void StartDeposit(decimal amount, string currency)
        {
            if (IsUsed)
            {
                Console.WriteLine("Here");
                throw new InsufficientFundsExeption();                
            }

                while (amount != 100 && amount != 500 && amount != 1000)
                {
                    Console.WriteLine("Please, enter correct amount (100/500/1000):");
                    if (!decimal.TryParse(Console.ReadLine(), out amount)) continue;
                }
            Console.WriteLine("Please, enter gift card 10-digit number:");
            string CardNumber;
            while (true)
            {
                CardNumber = Console.ReadLine().Trim().Replace(" ", "");
                if (CardNumber.Length != 10 || !long.TryParse(CardNumber, out long temp))
                {
                    Console.WriteLine("Wrong card number! Try again.");
                    continue;
                }
                number = temp;
                foreach (var vaucher in AllVauchers)
                {
                    if (this != vaucher && vaucher.number == this.number) throw new InsufficientFundsExeption();
                }
                break;
            }
            IsUsed = true;
            Console.WriteLine($"You have successfully withdraw {amount} {currency} from your Gift vaucher");
        }
    }
}
