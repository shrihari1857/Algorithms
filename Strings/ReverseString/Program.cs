using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "hello";
            var builder = new StringBuilder(s);
            char temp;
            int len = s.Length;

            for (int i = 0; i < len/2; i++)
            {
                temp = builder[len - 1 - i];
                builder[len - 1- i] = builder[i];
                builder[i] = temp;
            }
            

        }
    }
}
