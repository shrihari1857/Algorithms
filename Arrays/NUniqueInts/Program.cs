using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUniqueInts
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = 5;
            int even = N % 2;
            var half = N / 2;
            var temp = half;
            var arr = new int[N]; 

            for (int i = 0; i < half; i++)
            {
                arr[i] = -1 * temp;
                temp--;
            }

            if (even != 0)
            {
                arr[half] = 0;
                half++;
            }

            temp = 1;
            for (int i = half; i < arr.Length; i++)
            {
                arr[i] = temp;
                temp++;
            }
        }
    }
}
