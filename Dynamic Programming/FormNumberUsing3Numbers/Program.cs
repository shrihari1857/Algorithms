using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormNumberUsing3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Given 3 numbers {1, 3, 5}, we need to tell
             the total number of ways we can form a number 'N' 
             using the sum of the given three numbers.
             (allowing repetitions and different arrangements).
             
             Total number of ways to form 6 is: 8
             1+1+1+1+1+1
             1+1+1+3
             1+1+3+1
             1+3+1+1
             3+1+1+1
             3+3
             1+5
             5+1
             */

            var n = 6;

            Console.WriteLine(Solve(n));    //8
            Console.ReadLine();
        }

        private static int Solve(int n)
        {
            if (n < 0)
                return 0;

            if (n == 0)
                return 1;

            var first = Solve(n - 1);
            var second = Solve(n - 3);
            var third = Solve(n - 5);

            return first + second + third;
        }
    }
}
