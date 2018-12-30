using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairInSortedRotated
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 11, 15, 6, 8, 9, 10 };
            int sum = 16;
            int n = arr.Length;
            var ht = new Hashtable();

            for (int i = 0; i < arr.Length; i++)
            {
                ht[arr[i]] = i;
                if (i != 0)
                    if (ht.ContainsKey(sum - arr[i]) && (int)ht[sum - arr[i]] != i)
                        Console.WriteLine("Found");
            }

            Console.WriteLine("Not Found");
        }

       
    }
}
