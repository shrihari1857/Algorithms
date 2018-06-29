using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadixSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 329, 457, 657, 839, 436, 720, 355 };
            
            var max = 0;
            var mod = 10;
            var d = 1;

            for (int i = 0; i < arr.Length; i++)
                if (arr[i] > max)
                    max = arr[i];

            var digits =  Convert.ToInt32(Math.Floor(Math.Log10(max) + 1));

            for (int i = 0; i < digits; i++)
            {
                arr = RSort(arr, mod, d);
                mod = mod * 10;
                d = d * 10;
            }
        }

        private static int[] RSort(int[] arr, int mod, int d)
        {
            var c = new int[10];
            var result = new int[arr.Length];

            for (int j = 0; j < arr.Length; j++)
                c[(arr[j] % mod) / d] = c[(arr[j] % mod) / d] + 1;

            for (int k = 1; k < c.Length; k++)
                c[k] = c[k] + c[k - 1];

            for (int l = arr.Length - 1; l >= 0; l--)
            {
                result[c[(arr[l] % mod) / d] - 1] = arr[l];
                c[(arr[l] % mod) / d]--;
            }

            return result;
        }
    }
}
