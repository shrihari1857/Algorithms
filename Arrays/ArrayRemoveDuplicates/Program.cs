using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayRemoveDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            //var htable = new Hashtable();
            //int[] nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4,3,7,2,633,633, 700};
            //int count = 0;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (!htable.ContainsKey(nums[i]))
            //    {
            //        htable[nums[i]] = nums[i];
            //        nums[count] = nums[i];
            //        count = count + 1;
            //    }
            //}


            //int[] nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4, 5, 7, 8, 633, 633, 700,700, 800, 899, 950 };
            int[] nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            //var arr = new int[nums[nums.Length - 1]];
            //int count = 0;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] < arr[nums[i]])
            //    {
            //        htable[nums[i]] = nums[i];
            //        nums[i] = arr[nums[i]];
            //        count = count + 1;
            //    }
            //}

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    for (int j = i + 1; j < nums.Length; j++)
            //    {
            //        if(nums[j] > nums[i])
            //        {
            //            nums[i + 1] = nums[j];

            //            count++;
            //            break;
            //        }
            //        nums[j] = 0;
            //    }
            //}
            int length = nums.Length;
            int iniPointer = 0;
            int runningPointer = 1;

            while (runningPointer < length && iniPointer < length)
            {
                if (nums[iniPointer] != nums[runningPointer])
                {
                    iniPointer++;
                    nums[iniPointer] = nums[runningPointer];
                }

                runningPointer++;
            }
            //  Console.WriteLine(iniPointer + 1);
            int result = iniPointer + 1;
            for (int i = 0; i < result; i++)
            {
                Console.WriteLine(nums[i]);
            }

            //foreach (var num in nums)
            //    if (!htable.ContainsKey(num))
            //    {
            //        htable[num] = num;
            //        nums[htable.Count - 1] = num;
            //    }

            //int[] nums2 = new int[htable.Count];

            // Array.Clear(nums, 0, nums.Length);
            // nums.Initialize();
            //htable.Keys.Cast<int>().OrderBy(c=>c).ToArray().CopyTo(nums, 0);
            Console.ReadLine();
        }

    }
}
