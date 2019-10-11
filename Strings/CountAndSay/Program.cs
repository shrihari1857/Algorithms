using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountAndSay
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "1";
            int n = 4;
            var chars = s.ToCharArray();
            int len = 0;
            StringBuilder builder;

            for(int f = 0; f < (n - 1); f++)
            {
                builder = new StringBuilder();
                len = s.Length;
                int j = 0;
                int count = 1;

                for (int i = 0; i < len; i++)
                {
                    char c = s[j];

                    while (count < len && (j + 1) < len && c == s[j + 1])
                    {
                        i++;
                        count++;
                        j++;
                    }

                    builder.Append(count);
                    builder.Append(c);
                    count = 1;
                    c = Char.MinValue;
                    j++;
                }
                s = builder.ToString();
            }
        }
    }
}
