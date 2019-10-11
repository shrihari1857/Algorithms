using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 6;
            var arr = new int[n + 1];

            arr[0] = 1;

            for (int i = 1; i < arr.Length; i++)
            {
                if (n == i )
                {
                    arr[i] = 1 + arr[n - i];
                }
                else
                {
                    arr[i] = arr[i - 1];
                }
            }
        }
    }
}
