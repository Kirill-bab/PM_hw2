using System;
using System.Collections.Generic;
using System.Text;


namespace HW2
{
    public class BetService
    {
        decimal Odd;
        decimal MaxOdd = 25.00M;
        decimal MinOdd = 1.01M;

        public BetService()
        {
            Odd = new Random().Next((int)MinOdd, (int)MaxOdd) + (new Random().Next(100))/100.00M;
        }

        public float GetOdds()
        {
            Odd = new Random().Next((int)MinOdd, (int)MaxOdd) + (new Random().Next(100)) / 100.00M;
            return (float)Odd;
        }

        private bool IsWon()
        {
            int Chances = (int)Math.Round(1 / Odd * 100);
            Random rand = new Random();
            int unexpectable = rand.Next(101);
            //Console.WriteLine($"unexpectable: {unexpectable}, Chance: {Chances}");
            if (unexpectable >= 100 - Chances) return true;
            return false;
        }

        public decimal Bet(decimal amount)
        {
            if (IsWon()) return amount * Odd;
            return 0;
        }
    }
}
