using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //number required
            var n = 5;

            //need to accomodate an extra space for seed value
            var arr = new int[n + 1];

            //set the seed values
            arr[0] = 0;
            arr[1] = 1;

            //build the array. Here, we're solving small problems as base to higher problems - Overlapping subproblems
            //each iteration is an operation on it's own - Optimal substructure
            for (int i = 2; i <= n; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }


            Console.WriteLine($"fib({n})={arr[n]}");    //fib(5)=5
            Console.ReadLine();
        }
    }
}
