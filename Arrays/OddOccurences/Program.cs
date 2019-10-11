using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 2, 2, 3, 5, 7, 8, 9, 3, 7, 5, 8, 9, 7 };
            var missing = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                missing = missing ^ arr[i];
            }
        }
    }
}
