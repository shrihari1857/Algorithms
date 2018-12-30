using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidAnagram
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "a";
            string t = "ab";
            bool result = true;
            //int len = s.Length;

            //if (t.Length > len)
            //    len = t.Length;

            int[] arr1 = new int[26];
            int[] arr2 = new int[26];

            for (int i = 0; i < s.Length; i++)
                arr1[(int)s[i] - 97] = arr1[(int)s[i] - 97] + 1;

            for (int i = 0; i < t.Length; i++)
                arr2[(int)t[i] - 97] = arr2[(int)t[i] - 97] + 1;

            if (s.Length != t.Length)
                return false;

            for (int i = 0; i < s.Length; i++)
                if (arr1[(int)s[i] - 97] != arr2[(int)s[i] - 97])
                    result = false;

        }
    }
}
