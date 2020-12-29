using System;
using HW2;

namespace Task_2._1
{
    class BetServiseTest
    {
        static void Main(string[] args)
        {
            BetService betService = new BetService();

            for (int i = 0; i < 10; i++)
            {
                float odd = betService.GetOdds();
                decimal result = betService.Bet(100);

                Console.WriteLine($"I've bet 100 USD with the odd {odd} and I've earned {result}");
            }

            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                float odd = betService.GetOdds();
                if(odd < 12)
                {
                    i--;
                    continue;
                }
                decimal result = betService.Bet(100);

                Console.WriteLine($"I've bet 100 USD with the odd {odd} and I've earned {result}");
            }

            Console.WriteLine();
            decimal Money = 10000M;
            CarefullStudent(Money, betService);
            Console.WriteLine();
            RiskyStudent(Money, betService);
        }

        public static void CarefullStudent(decimal Money, BetService betService)
        {
            while (Money > 0 && Money < 150000)
            {
                decimal bet = 0;
                float odd = betService.GetOdds();
                if (odd > 3) continue;
                else if (odd > 2)
                {
                    if (Money < 100) bet = Money;
                    else bet = 100;
                }
                else if (odd > 1.5 && Money >= 1000) bet = 1000;
                else if (Money >= 5000) bet = 5000;

                decimal result = betService.Bet(bet);
                Money = Money - bet + result;

                Console.WriteLine($"I've bet {bet} USD with the odd {odd} and I've earned {result}");
            }

            Console.WriteLine($"Game is over. My balance is {Money}");
        }

        public static void RiskyStudent(decimal Money, BetService betService)
        {
            while (Money > 0 && Money < 150000)
            {
                decimal bet = 0;
                float odd = betService.GetOdds();
                if (odd > 10) continue;
                else if (odd > 5)
                {
                    if (Money < 100) bet = Money;
                    else bet = 100;
                }
                else if (odd > 3 && Money >= 1000) bet = 1000;
                else if (Money >= 5000) bet = 5000;

                decimal result = betService.Bet(bet);
                Money = Money - bet + result;

                Console.WriteLine($"I've bet {bet} USD with the odd {odd} and I've earned {result}");
            }

            Console.WriteLine($"Game is over. My balance is {Money}");
        }
    }
}
