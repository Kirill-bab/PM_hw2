using System;
using HW2;
using System.Linq;

namespace Task_1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Account[] accounts = new Account[1000000];
            
            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Account("UAH");
            }
            
            GetSortedAccountsByQuickSort(accounts);

            Console.WriteLine("First 10 accounts are:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(accounts[i].id);
            }

            Console.WriteLine("Last 10 accounts are:");
            for (int i = accounts.Length - 11; i < accounts.Length; i++)
            {
                Console.WriteLine(accounts[i].id);
            }
        }


        // By the way, here is an intresting link with the best quick sort algorithm explanation I guess anyone can give:
        // https://youtu.be/ywWBy6J5gz8
        public static void GetSortedAccountsByQuickSort(Account[] accounts)
        {
            int left = 0, right = (accounts.Length - 1);
            QuickSort(accounts, left, right);
        }

        public static void QuickSort(Account[] accounts, int left, int right)
        {
            if (left >= right) return;
            int groundElementIndex = right;

            for (int i = left; i < groundElementIndex; i++)
            {
                if (accounts[i].id < accounts[groundElementIndex].id) continue;

                if(accounts[i].id >= accounts[groundElementIndex].id)
                {
                    Account temp = accounts[i];
                    accounts[i] = accounts[groundElementIndex - 1];
                    accounts[groundElementIndex - 1] = accounts[groundElementIndex];
                    accounts[groundElementIndex] = temp;
                    groundElementIndex--;
                    i--;
                }
            }

            QuickSort(accounts, left, groundElementIndex - 1);
            QuickSort(accounts, groundElementIndex + 1, right);
        }

    }
}
