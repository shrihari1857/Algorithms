using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingSort
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var arr = new int[] { 2, 5, 3, 0, 2, 3, 0, 3 };
            var c = new int[10];    //assuming range is from 0 to 9
            var result = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
                c[arr[i]] = c[arr[i]] + 1;

            for (int i = 1; i < c.Length; i++)
                c[i] = c[i] + c[i - 1];

            for (int i = arr.Length - 1; i >=0 ; i--)
            {
                result[c[arr[i]] - 1] = arr[i];
                c[arr[i]]--;
            }

        }
    }
}
