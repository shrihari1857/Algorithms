using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;
            Hashtable htable = new Hashtable();
            int len = nums.Length;
            var result = new List<int>();

            for (int i = 0; i < len; i++)
                if (htable.ContainsKey(nums[i]))
                    htable[nums[i]] = (int)htable[nums[i]] + 1;
                else
                    htable[nums[i]] = 1;

            for (int i = 0; i < len; i++)
                if (htable.ContainsKey(target - nums[i]))
                {
                    if ((target - nums[i]) == nums[i] && (int)htable[target - nums[i]] == 1)
                        continue;

                    result.Add(i);
                }

            var x = result.ToArray();
        }
    }
}
