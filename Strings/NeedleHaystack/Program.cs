using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedleHaystack
{
    class Program
    {
        static void Main(string[] args)
        {
            string haystack = "hello";
            string needle = "ll";
            int runningPointer = needle.Length - 1;
            int slowPointer = 0;
            int finalPointer = 0;

            var chars = haystack.ToCharArray();

            while (runningPointer <= (haystack.Length - 1))
            {
                var f = new string(chars, slowPointer, needle.Length);
                if (needle == f)
                    finalPointer = slowPointer;
                runningPointer++;
                slowPointer++;
            }

            //var builder = new StringBuilder(haystack);
            //int finalPointer = 0;

            //while (runningPointer <= (haystack.Length - 1))
            //{
            //    if (needle == builder.ToString(slowPointer, needle.Length))
            //        finalPointer = slowPointer;

            //    runningPointer++;
            //    slowPointer++;
            //}

            //finalPointer = -1;


        }
    }
}
