using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainsDuplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result = Dup();

            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static bool Dup()
        {
            int[] nums = new int[] { 1, 2, 3};
            Hashtable htable = new Hashtable();
            int len = nums.Length;

            for (int i = 0; i < len; i++)
            {
                if (htable.ContainsKey(nums[i]))
                {
                    return true;
                }
                else
                {
                    htable[nums[i]] = nums[i];
                }
            }

            return false;
        }
    }
}
