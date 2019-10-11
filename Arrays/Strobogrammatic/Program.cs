using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strobogrammatic
{
    class Program
    {
        public static Hashtable candidate = new Hashtable();
        static void Main(string[] args)
        {
            var result = findStrobogrammatic(5);
        }

        public static List<String> findStrobogrammatic(int n)
        {
            List<string> rst = new List<string>();
            candidate["0"] =  "0";
            candidate["1"] =  "1";
            candidate["8"] =  "8";
            candidate["6"] =  "9";
            candidate["9"] =  "6";
            rst = searchAndCombine(n);
            for (int i = 0; i < rst.Count; i++)
            {
                if ((long.Parse(rst[i]) + "").Length != n)
                {
                    rst.RemoveAt(i);
                    i--;
                }
            }
            return rst;
        }

        public static List<string> searchAndCombine(int n)
        {
            List<string> list = new List<string>();
            if (n <= 0)
            {
                return list;
            }
            else if (n == 1)
            {
                list.Add("0");
                list.Add("1");
                list.Add("8");
                return list;
            }
            else if (n == 2)
            {
                list.Add("69");
                list.Add("11");
                list.Add("88");
                list.Add("96");
                list.Add("00");
                return list;
            }
            else
            {//n >= 2
                List<string> temp = searchAndCombine(n - 2);
                foreach(string str in temp)
                {
                    foreach(DictionaryEntry entry in candidate)
                    {
                        list.Add(entry.Key + str + entry.Value);
                    }
                }
            }
            return list;
        }
    }
}
//}
