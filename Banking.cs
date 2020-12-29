using System;
using HW2;

namespace Task_3._1
{
    class Banking
    {
        static void Main(string[] args)
        {
            CreditCard MasterCard = new CreditCard();
            MasterCard.StartDeposit(50, "USD");       // for MasterCard
            Console.WriteLine();

            CreditCard SomeCard = new CreditCard();
            SomeCard.StartWithdrawal(50,"USD");       // for wrong card
            Console.WriteLine();

            CreditCard Visa = new CreditCard();
            Visa.StartWithdrawal(50, "USD");          // for Visa
            Console.WriteLine();

            Privet48 privet48 = new Privet48();
            privet48.StartDeposit(50, "USD");         // for Privet48
            Console.WriteLine();

            Stereobank Stereobank = new Stereobank(); // for Stereobank
            Stereobank.StartWithdrawal(50, "USD");
            Console.WriteLine();

            GiftVoucher giftVoucher = new GiftVoucher();
            giftVoucher.StartDeposit(50, "USD");      // for GiftVaucher
            giftVoucher.StartDeposit(500, "USD");
        }
    }
}
