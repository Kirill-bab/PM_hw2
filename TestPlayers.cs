using System;
using HW2;

namespace Task_1._5
{
    class TestPlayers
    {
        static void Main(string[] args)
        {
            Player player = new Player("USD", "John", "Doe", "john777@gmail.com", "TheP@$$w0rd");
            Console.WriteLine("Login with login {0} and password {1} is {2}", player.FirstName + " " + player.LastName, "TheP@$$w0rd", player.IsPasswordValid("TheP@$$w0rd"));
            Console.WriteLine("Login with login {0} and password {1} is {2}", player.FirstName + " " + player.LastName, "TheP@$$w0rd234", player.IsPasswordValid("TheP@$$w0rd234"));
            player.Deposit(100, "USD");
            player.Withdraw(50, "EUR");

            try
            {
                player.Withdraw(1000, "USD");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Insufficient costs!");
            }

            try
            {
                Player pshe = new Player("PLN", "Yakuw", "Zagrazowy", "kurwaperdole@gmail.com", "Polska");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Unsupported currency!");
            }
        }
    }
}
