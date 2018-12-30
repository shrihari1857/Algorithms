using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUnique
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            string s = "loveleetcode";
            int[] arr = new int[26];

            for (int i = 0; i < s.Length; i++)
                    arr[s[i] - 97] = arr[s[i] - 97] + 1;

            for (int i = 0; i < s.Length; i++)
                if (arr[s[i] - 97] == 1)
                    result = i;

            result = -1;    
        }
    }
}
