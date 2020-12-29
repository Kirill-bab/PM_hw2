using System;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
    class Tools
    {
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

                if (accounts[i].id >= accounts[groundElementIndex].id)
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

        public static void GetAccount(int id, Account[] accounts)
        {
            int left = 0, right = accounts.Length - 1, middle, index = 0, tries = 0;
            bool Is_Found = false;

            while (left <= right)
            {
                tries++;
                middle = (left + right) / 2;

                if (accounts[middle].id == id)
                {
                    index = middle;
                    Is_Found = true;
                    break;
                }
                else if (accounts[middle].id > id) right = middle - 1;
                else left = middle + 1;
            }

            if (Is_Found) Console.WriteLine("Account {0} was found at index {1} by {2} tries", id, index, tries);
            else Console.WriteLine("There is no account {0} in the list", id);
        }
    }
}
