using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 3423423;
            
            int i = 0;
            if (x < 0)
                i = 1;

            StringBuilder builder = new StringBuilder(x.ToString());
            char temp;
            int len = builder.Length;
            int k = 0;
            for (int j = i; j < (len + i)/2; j++)
            {
                temp = builder[len - 1 - k];
                builder[len - 1 - k] = builder[j];
                builder[j] = temp;
                k++;
            }
            var r = Convert.ToInt64(builder.ToString());
        }
    }
}
