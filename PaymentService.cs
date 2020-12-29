using System;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
    public class PaymentService
    {
        PaymentMethodBase[] AvailablePaymentMethods;

        public PaymentService()
        {
            AvailablePaymentMethods = new PaymentMethodBase[] { new CreditCard(), new Privet48(), new Stereobank(), new GiftVoucher() };
        }

        public void StartDeposit(decimal amount, string currency)
        {
            int randomExeption = new Random().Next(101);
            if (randomExeption <= 2) throw new Exception();
            Console.WriteLine("Welcome to our payment service!\nPlease, choose the option:");
            for (int i = 0; i <AvailablePaymentMethods.Length; i++)
            {
                if(AvailablePaymentMethods[i] is ISupportDeposit)
                {
                    Console.WriteLine($"{i+1}. {AvailablePaymentMethods[i].Name}");
                }
            }
            int number;
            while (true)
            {
                Console.Write("Enter option number: ");

                if (!int.TryParse(Console.ReadLine(), out number) || number <= 0 || number > AvailablePaymentMethods.Length)
                {
                    Console.WriteLine("Wrong option nuber! Try again!");
                    continue;
                }
                break;
            }
            number--;
            if(AvailablePaymentMethods[number] is GiftVoucher )
            {
                AvailablePaymentMethods[number] = new GiftVoucher();
            }
            ISupportDeposit paymentMethod = (ISupportDeposit)AvailablePaymentMethods[number];
            paymentMethod.StartDeposit(amount, currency);
        }

        public string StartWithdrawal(decimal amount, string currency)
        {
            int randomExeption = new Random().Next(101);
            if (randomExeption <= 2) throw new Exception();

            Console.WriteLine("Welcome to our payment service!\nPlease, choose the option:");
            for (int i = 0; i < AvailablePaymentMethods.Length; i++)
            {
                if (AvailablePaymentMethods[i] is ISupportWithdrawal)
                {
                    Console.WriteLine($"{i + 1}. {AvailablePaymentMethods[i].Name}");
                }
            }
            int number;
            while (true)
            {
                Console.Write("Enter option number: ");

                if (!int.TryParse(Console.ReadLine(), out number) || number <= 0 || number > AvailablePaymentMethods.Length)
                {
                    Console.WriteLine("Wrong option nuber! Try again!");
                    continue;
                }
                break;
            }
            number--;

            ISupportWithdrawal paymentMethod = (ISupportWithdrawal)AvailablePaymentMethods[number];
            return paymentMethod.StartWithdrawal(amount, currency);
        }
    }
}
