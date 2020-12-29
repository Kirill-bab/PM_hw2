using System;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
    public abstract class PaymentMethodBase
    {
        public string Name { get; protected set; }
    }

    interface ISupportDeposit
    {
        void StartDeposit(decimal amount, string currency);
    }

    interface ISupportWithdrawal
    {
        string StartWithdrawal(decimal amount, string currency);
    }

     public class CreditCard : PaymentMethodBase,  ISupportDeposit, ISupportWithdrawal
    {
        public CreditCard()
        {
            Name = "Credit Card";
        }

        public void StartDeposit(decimal amount, string currency)
        {
            decimal sum = 0;
            switch (currency)
            {
                case "USD":
                    sum = amount * (decimal)28.36;
                    break;
                case "EUR":
                    sum = amount * (decimal)33.63;
                    break;
                case "UAH":
                    sum = amount;
                    break;
                default:
                    throw new Exception();
            }
            if (sum > 3000) throw new LimitExceedExeption();

            Console.WriteLine("Please, enter your card 16-digit number: ");
            bool wrongInput = false;
            string CardNumber;
            while (true)
            {
                CardNumber = Console.ReadLine().Trim().Replace(" ","");
                     if (!(CardNumber.StartsWith("4") || CardNumber.StartsWith("5")) || CardNumber.Length != 16 || !long.TryParse(CardNumber, out long temp) )
                    {
                    Console.WriteLine("Wrong card number! Try again.");
                    continue;
                    }
                break;
            }

            Console.WriteLine("Enter expiry date: ");
            int[] expiryDate = new int[5];
            while (true)
            {
                wrongInput = false;
                for (int i = 0; i < 5; i++)
                {
                    if(i == 2)
                    {
                        Console.Write("/");
                        continue;
                    }
                    if (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out int temp) && i != 2)
                    {
                        wrongInput = true;
                        break;
                    }
                    expiryDate[i] = temp;
                }
                if (wrongInput || expiryDate[0] > 1 || (expiryDate[0] == 1 && expiryDate[1] > 2) || (expiryDate[0] == 0 && expiryDate[1] == 0) || expiryDate[3] < 2)
                {
                    Console.WriteLine("\nWrong expiry date! Try again.");
                    continue;
                }
                break;
            }
            Console.WriteLine("\nPlease, enter your card CVV: ");
            while (true)
            {
                wrongInput = false;
                for (int i = 0; i < 3; i++)
                {
                    if (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out int temp))
                    {
                        wrongInput = true;
                        break;
                    }
                }
                if (wrongInput)
                {
                    Console.WriteLine("Wrong card CVV! Try again.");
                    continue;
                }
                break;
            }
            Console.WriteLine($"\nYou have successfully withdraw {amount} {currency} from your card!");
        }

        public string StartWithdrawal(decimal amount, string currency)
        {
            Console.WriteLine("Please, enter your card 16-digit number: ");
            string CardNumber;
            while (true)
            {
                CardNumber = Console.ReadLine().Trim().Replace(" ", "");
                if (!(CardNumber.StartsWith("4") || CardNumber.StartsWith("5")) || CardNumber.Length != 16 || !long.TryParse(CardNumber, out long temp))
                {
                    Console.WriteLine("Wrong card number! Try again.");
                    continue;
                }
                break;
            }
            return $"\nYou have successfully deposit { amount} { currency} to your card!";
        }
    }
}
