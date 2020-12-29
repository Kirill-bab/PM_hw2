using System;
using HW2;

namespace Task_4._1
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 4; i++)
            {
                Exception exeption;
                switch (i)
                {
                    case 0:
                        exeption = new InsufficientFundsExeption();
                        break;
                    case 1:
                        exeption = new LimitExceedExeption();
                        break;
                    case 2:
                        exeption = new PaymentServiceExeption();
                        break;
                    default:
                        exeption = new Exception();
                        break;
                }
                try
                {
                    throw exeption;
                }
                catch (InsufficientFundsExeption)
                {
                    Console.WriteLine("Insufficient Funds Exeption!");
                }
                catch (LimitExceedExeption)
                {
                    Console.WriteLine("Limit Exceed Exeption!");
                }
                catch (PaymentServiceExeption)
                {
                    Console.WriteLine("Payment Service Exeption!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Exeption!");
                }
            }
        }
    }
}
