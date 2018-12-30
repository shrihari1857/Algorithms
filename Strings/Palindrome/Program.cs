using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "0P";
            List<int> ints = new List<int>();
            int temp = 0;

            for (int i = 0; i < s.Length; i++)
            {
                temp = (int)s[i];
                if (temp > 64 && temp < 91)
                    temp = temp + 32;

                if ((temp > 96 && temp < 123) || (temp > 47 && temp < 58))
                    ints.Add(temp);
            }

            var arr = ints.ToArray();
            var len = ints.Count;
            var arr1 = new int[len];
            bool result = true;
            for (int i = 0; i < len; i++)
                arr1[len - 1 - i] = arr[i];

            for (int i = 0; i < len; i++)
                if (arr[i] != arr1[i])
                    result = false; 

            //return result;

        }
    }
}
