using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            ToH(3, "A", "B", "C");

            Console.ReadLine();

        }

        private static void ToH(int n, string from, string to, string spare)
        {
            if(n > 0)
            {
                ToH(n - 1, from, spare, to);
                Console.WriteLine($"Move disk from {from} to {to}");
                ToH(n - 1, spare, to, from);
            }

        }
    }
}
