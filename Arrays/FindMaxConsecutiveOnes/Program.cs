using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMaxConsecutiveOnes
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = findMaxConsecutiveOnes(new int[] { 1, 0, 1, 1, 0 });
        }

        public static int findMaxConsecutiveOnes(int[] nums)
        {
            int k = 1, low = 0, zeroCount = 0, ret = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    zeroCount++;
                }
                while (zeroCount > k)
                {
                    if (nums[low] == 0)
                    {
                        zeroCount--;
                    }
                    low++;
                }
                ret = Math.Max(ret, i - low + 1);
            }

            return ret;
        }
    }
}
