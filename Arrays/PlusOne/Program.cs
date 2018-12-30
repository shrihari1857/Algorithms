using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusOne
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] digits = new int[] { 9, 9, 9, 9, 9, 9 };
            int len = digits.Length;

            var stack = new Stack<int>();

            var pointer = len - 1;
            int lastDigit = 0;
            digits[pointer] = digits[pointer] + 1;

            while (pointer >= 0)
            {
                lastDigit = digits[pointer];
                if (lastDigit > 9)
                {
                    if (pointer == 0)
                    {
                        stack.Push(0);
                        stack.Push(1);
                    }
                    else
                    {
                        stack.Push(0);
                        digits[pointer - 1] = digits[pointer - 1] + 1;
                    }
                }
                else
                {
                    stack.Push(lastDigit);
                }
                pointer = pointer - 1;
            }

            var arr = stack.ToArray();

        }
    }
}
