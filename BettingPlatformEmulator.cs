using System;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
     public class BettingPlatformEmulator
    {
        public static readonly List<Player> Players = new List<Player>(10);
        private Player ActivePlayer;
        public readonly Account Account;
        private BetService BetService;
        private PaymentService paymentService;
        private  static List<PaymentService> AllPaymentServices = new List<PaymentService>(10);
        private float CurrentOdds;
        public BettingPlatformEmulator()
        {
            Account = new Account("USD");
            BetService = new BetService();
            CurrentOdds = 0;
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                if (ActivePlayer == null)
                {
                    Console.WriteLine("======================================");
                    Console.WriteLine("Welcome to our Betting Platform!\n======================================\n\tMENU");
                    Console.WriteLine("1. Register");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. Stop");

                    Console.Write("Enter option's number: ");
                    bool inputIsCorrect = int.TryParse(Console.ReadLine().Trim(),out int answer);

                    if (!inputIsCorrect)
                    {
                        Console.WriteLine("Wrong input!");
                        continue;
                    }

                    switch (answer)
                    {
                        case 1:  Register();
                            break;
                        case 2: Login();
                            break;
                        case 3: Exit();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("============================================");
                    Console.WriteLine("Welcome to our Betting Platform {0}!\n\tMENU", ActivePlayer.FirstName);
                    Console.WriteLine("============================================");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Get Odds");
                    Console.WriteLine("4. Bet");
                    Console.WriteLine("5. Get balance");
                    Console.WriteLine("6. Logout");

                    Console.Write("Enter option's number: ");
                    bool inputIsCorrect = int.TryParse(Console.ReadLine().Trim(), out int answer);

                    if (!inputIsCorrect)
                    {
                        Console.WriteLine("Wrong input!");
                        continue;
                    }
                    Console.WriteLine("--------------------------");
                    switch (answer)
                    {
                        case 1:
                            Deposit();
                            break;
                        case 2:
                            Withdraw();
                            break;
                        case 3:
                            GetOdds();
                            break;
                        case 4:
                            Bet();
                            break;
                        case 5:
                            GetBalance();
                            break;
                        case 6:
                            Logout();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void Bet()
        {
            string Currency = GetCurrency();
            decimal amount;
            Console.Write("Please, enter amount you want to bet: ");
            while (true) 
            {
                if (!Decimal.TryParse(Console.ReadLine().Trim(), out amount))
                {
                    Console.WriteLine("Incorrect input! Try again!");
                    continue;
                }
                break;
            }
            try
            {
                ActivePlayer.Withdraw(amount, Currency);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Withdraw failure!");
                Console.WriteLine("Insufficient funds!");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("\nBet accepted!");
            Console.Write("Obtaining results");
            for (int i = 0; i < 3; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
            }
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\n");
            decimal result = BetService.Bet(amount);

            if(result == 0)
            {
                Console.WriteLine("Ah! It was a bit unlucky. That could happen to anyone.");
                Console.WriteLine("How about you try again and proove that that was just a small misfortune?");
            }
            else
            {
                Console.WriteLine("Woah! Someone is definitely lucky today!\n");
                Console.WriteLine($"You bet {amount} {Currency} with odds {CurrentOdds} and won {result} {Currency}!");
                Console.WriteLine($"Your net profit is: {result - amount}\n");
                Console.WriteLine("Then don't waste your fortune! Bet again!");
            }
            ActivePlayer.Deposit(result, Currency);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        private void GetOdds()
        {
            CurrentOdds = BetService.GetOdds();
            Console.WriteLine($"Here are Odds: {CurrentOdds}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        private void Exit()
        {
            System.Environment.Exit(1);
        }
        private void GetBalance()
        {
            string Currency = GetCurrency();
            
            Console.WriteLine();
            ActivePlayer.GetBalance(Currency);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        private void Deposit()
        {
            string Currency = GetCurrency();
            
            decimal Amount;
            while (true)
            {
                Console.Write("Enter deposit amount: ");
                if(!decimal.TryParse(Console.ReadLine().Trim(), out  Amount) || Amount < 0)
                {
                    Console.WriteLine("Wrong input!");
                    continue;
                }
                break;
            }
            bool fail = false;
            try
            {
                paymentService.StartDeposit(Amount, Currency);
            }
            catch (LimitExceedExeption)
            {
                Console.WriteLine("Please, try to make a transaction with lower amount");
                fail = true;
            }
            catch (InsufficientFundsExeption)
            {
                Console.WriteLine("Please, try to make a transaction with lower amount or change payment method");
                fail = true;
            }
            catch (PaymentServiceExeption)
            {
                Console.WriteLine("You exceeded this bank transactions limit!\nPlease, try to make a transaction with lower amount or change payment method");
                fail = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong. Try again later...");
                fail = true;
            }

            if (fail) 
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Deposit success!");
            ActivePlayer.Deposit(Amount, Currency);
            Account.Deposit(Amount, Currency);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void Withdraw()
        {
            string Currency = GetCurrency();
            
            decimal Amount;
            while (true)
            {
                Console.Write("Enter amount you want to withdraw: ");
                if (!decimal.TryParse(Console.ReadLine().Trim(), out Amount) || Amount < 0)
                {
                    Console.WriteLine("Wrong input!");
                    continue;
                }
                break;
            }

            if (Account.GetBalance("USD") < ActivePlayer.GetBalance("USD"))
            {
                try
                {
                    Account.Withdraw(Amount, Currency);
                }
                catch (NotSupportedException)
                {
                    Console.WriteLine("Withdraw failure!");
                    Console.WriteLine("There is some problem on the program side. Please, try later.");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    return;
                }
            }
            bool fail = false;
            string result = "";
            try
            {
                result = paymentService.StartWithdrawal(Amount, Currency);
            }
            catch (LimitExceedExeption)
            {
                Console.WriteLine("Please, try to make a transaction with lower amount");
                fail = true;
            }
            catch (InsufficientFundsExeption)
            {
                Console.WriteLine("Please, try to make a transaction with lower amount or change payment method");
                fail = true;
            }
            catch (PaymentServiceExeption)
            {
                Console.WriteLine("You exceeded this bank transactions limit!\nPlease, try to make a transaction with lower amount or change payment method");
                fail = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong. Try again later...");
                fail = true;
            }

            if (fail)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }
           
                try
                {
                    ActivePlayer.Withdraw(Amount, Currency);
                }
                catch (NotSupportedException)
                {
                    Console.WriteLine("Withdraw failure!");
                    Console.WriteLine("Insufficient funds!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                    return;
                }
            Console.WriteLine("Withdrawall success!");
            Console.WriteLine(result);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void Register()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("Registering new player.");
            Console.Write("Enter your name, please: ");
            string name = Console.ReadLine();
            Console.Write("Enter your Last name, please: ");
            string Lastname = Console.ReadLine();
            Console.Write("Enter your Email, please: ");
            string email = Console.ReadLine();
            string password;
            while (true)
            {
                Console.Write("Enter your Password, please: ");
                password = Console.ReadLine().Trim();
                Console.Write("Repeat your Password, please: ");
                string repeatPassword = Console.ReadLine().Trim();

                if(password != repeatPassword)
                {
                    Console.WriteLine("Passwords are not equal!");
                    continue;
                }
                break;                
            }
            string Currency = GetCurrency();
           
            Players.Add(new Player(Currency, name, Lastname, email, password));
            paymentService = new PaymentService();
            AllPaymentServices.Add(paymentService);
            Console.WriteLine("Registration success!");
            Console.WriteLine("-------------------");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();            
        }

        private void Login()
        {

            if(Players.Count == 0)
            {
                Console.WriteLine("Players list is empty!");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("-------------------");
            Console.WriteLine("Logging in.");
            Console.Write("Enter First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine().Trim();

            Player currPlayer = Players[0];
            bool isFound = false;

            foreach (var player in Players)
            {
                if(player.FirstName == firstName && player.LastName == lastName)
                {
                    currPlayer = player;
                    isFound = true;
                    break;
                }
            }

            if (isFound && currPlayer.IsPasswordValid(password))
            {
                ActivePlayer = currPlayer;
                Console.WriteLine("Login success!");
                paymentService = AllPaymentServices[Players.IndexOf(currPlayer)];
            }
            else Console.WriteLine("No user with such parameters found!");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void Logout()
        {
            CurrentOdds = 0;
            ActivePlayer.Dispose();
            ActivePlayer = null;
        }

        private string GetCurrency()
        {
            string Currency;
            while (true)
            {
                Console.Write("Enter your account currency, please: ");
                Currency = Console.ReadLine().Trim().ToUpper();
                if (!(Currency == "USD" || Currency == "EUR" || Currency == "UAH"))
                {
                    Console.WriteLine("Unsupported currency!");
                    Console.WriteLine("We support : UAH, USD, EUR");
                    continue;
                }
                break;
            }
            return Currency;
        }
    }
}
