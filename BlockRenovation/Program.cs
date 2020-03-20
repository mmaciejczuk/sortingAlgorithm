using System;
using System.Collections.Generic;

namespace BlockRenovation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] items = { "red", "blue", "red", "green", "blue" };
            string[] order = { "blue", "red", "black" };

            List<string> results = SortItemsByOrder(items, order);

            foreach(var result in results)
                Console.Write(result + " ");

            Console.ReadKey();
        }

        public static List<string> SortItemsByOrder(string[] items, string[] order)
        {
            // sorted items will be in the temp table
            string[] temp = new string[items.Length];
            List<string> result = new List<string>();

            for (int i = 0; i < items.Length; i++)
            {
                temp[i] = items[i];
            }

            Array.Sort(temp);

            // take elements from order[], find the occurencies in temp[] and copy to items[] in order
            for (int i = 0; i < order.Length; i++)
            {
                // find index of the first occurrence order element in items[] array
                int k = FirstOccurrence(temp, 0, items.Length - 1, order[i], items.Length);

                if (k == -1)
                    continue;

                // copy all occurencies to items[]
                for (int j = k; (j < items.Length && temp[j] == order[i]); j++)
                {
                    result.Add(temp[j]);
                }
            }

            return result;
        }

        // Binary search algorithm
        public static int FirstOccurrence(string[] arr, int low, int high, string x, int n)
        {
            if (high >= low)
            {
                int mid = low + (high - low) / 2;

                // comparing two strings alphabetically (if index x is larger then arr[mid-1])
                if ((mid == 0 || (string.Compare(x, arr[mid - 1]) > 0 ? true : false)) && arr[mid] == x)
                    return mid;

                // comparing two strings alphabetically (if index x is larger then arr[mid])
                if (string.Compare(x, arr[mid]) > 0 ? true : false)
                    return FirstOccurrence(arr, (mid + 1), high,
                                 x, n);
                return FirstOccurrence(arr, low, (mid - 1), x, n);
            }
            // element is not found
            return -1;
        }
    }
 }

