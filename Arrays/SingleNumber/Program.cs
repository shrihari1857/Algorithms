using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(SingleNumber2());
            Console.WriteLine(SingleNumber1());
            Console.ReadLine();
        }

        private static int SingleNumber1()
        {
            int[] nums = new int[] { 2, 2, 2, 1 };
            for (int i = 1; i < nums.Length; i++)
                nums[0] ^= nums[i];

            return nums[0];
        }

        private static int SingleNumber2()
        {
            int[] nums = new int[] { 2 };
            Hashtable htable = new Hashtable();
            int len = nums.Length;
            int singleNumber = 0;

            for (int i = 0; i < len; i++)
            {
                
                if(!htable.ContainsKey(nums[i]))
                    htable[nums[i]] = 1;
                else
                    htable[nums[i]] = (int)htable[nums[i]] + 1;
            }

            foreach (var num in nums)
            {
                if ((int)htable[num] == 1)
                    singleNumber = num;
            }
            return singleNumber;
        }
    }
}
