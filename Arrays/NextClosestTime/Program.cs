using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextClosestTime
{
    class Program
    {
        static string result = string.Empty;
        static int minDiff = int.MaxValue;

        static void Main(string[] args)
        {
            var res = nextClosestTime("19:34");
        }

        public static string nextClosestTime(String time)
        {
            int originalMins = int.Parse(time.Substring(0, 2)) * 60 + int.Parse(time.Substring(3, 2));
            
            var list = new List<char>
            {
                time[0],
                time[1],
                time[3],
                time[4]
            };

            dfs(list, string.Empty, originalMins);

            return result;
        }

        private static void dfs(List<char> list, string temp, int originalMins)
        {
            if (temp.Length == 4)
            {
                var hourString = temp.Substring(0, 2);
                var minString = temp.Substring(2, 2);
                var hour = int.Parse(hourString);
                var min = int.Parse(minString);

                if (hour > 23 || min > 59)
                    return;

                var totalMins = hour * 60 + min;

                //
                if (totalMins <= originalMins)
                    totalMins += 24 * 60;
                //else
                //    totalMins = 0;

                if (minDiff > (totalMins - originalMins))
                {
                    minDiff = totalMins - originalMins;
                    result = hourString + ":" + minString;
                }
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                temp += list[i];
                dfs(list, temp, originalMins);
                temp = temp.Substring(0, temp.Length - 1);
            }
        }
    }
}
