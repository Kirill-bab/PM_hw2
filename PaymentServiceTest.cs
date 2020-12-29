using System;
using HW2;

namespace Task_3._2
{
    class PaymentServiceTest
    {
        static void Main(string[] args)
        {
            PaymentService paymentService = new PaymentService();
            paymentService.StartDeposit(50, "USD");                    // for MasterCard  

            Console.WriteLine("\n");

            paymentService.StartWithdrawal(50, "USD");                 // for wrong card

            Console.WriteLine("\n");

            paymentService.StartWithdrawal(50, "USD");                 // for Visa

            Console.WriteLine("\n");

            paymentService.StartDeposit(50, "USD");                    // for Privet48

            Console.WriteLine("\n");

            paymentService.StartWithdrawal(50, "USD");                 // for Stereobank

            Console.WriteLine("\n");

            paymentService.StartDeposit(50, "USD");                    // for GiftVoucher

            Console.WriteLine("\n");

            paymentService.StartDeposit(500, "USD");                    // for GiftVoucher

        }
    }
}
