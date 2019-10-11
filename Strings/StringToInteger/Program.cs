using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            //var str = "42";
            //var str = "   -42";
            //var str = "4193 with words";
            var str = "words and 987";
            //var str = "+-2";

            var sBuilder = new StringBuilder(str);
            var posMax = Int32.MaxValue;
            var negMax = Int32.MinValue;
            var posNumber = true;
            var rBuilder = new StringBuilder();
            var isDirty = false;
            int result = 0;

            for (int i = 0; i < sBuilder.Length; i++)
            {
                if ((sBuilder[i] == 0 || sBuilder[i] == 32)&& !isDirty)
                    continue;

                if (sBuilder[i] == 43 && !isDirty)
                {
                    isDirty = true;
                    posNumber = true;
                    rBuilder.Append(sBuilder[i]);
                    continue;
                }

                if (sBuilder[i] == 45 && !isDirty)
                {
                    isDirty = true;
                    posNumber = false;
                    rBuilder.Append(sBuilder[i]);
                    continue;
                }

                var c = sBuilder[i] - 48;
                if (c >= 0 && c < 10)
                {
                    isDirty = true;
                    rBuilder.Append(c);
                }
                else break;
                    
            }

            if (rBuilder.Length > 0)
            {
                if (Int32.TryParse(rBuilder.ToString(), out result))
                    result = 5;

                if (rBuilder.Length >= posMax.ToString().Length)
                {
                    if (posNumber)
                        result = posMax;

                    result = negMax;
                }

                result = 0;

            }
            result = Int32.Parse(rBuilder.ToString());
            //return result;

            //
        }
    }
}
