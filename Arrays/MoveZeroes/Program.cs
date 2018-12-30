using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 0, 1, 0, 3, 12 };

            int notzeroes = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    if (notzeroes != i)
                    {
                        nums[notzeroes] = nums[notzeroes] ^ nums[i];
                        nums[i] = nums[notzeroes] ^ nums[i];
                        nums[notzeroes] = nums[notzeroes] ^ nums[i];
                    }
                    notzeroes += 1;
                }
            }

            #region My Solution
            //int length = nums.Length;
            //int iniPointer = 0;

            //while (iniPointer < length)
            //{
            //    if (nums[iniPointer] != 0)
            //    {
            //        iniPointer = iniPointer + 1;
            //        continue;
            //    }

            //    for (int j = (iniPointer + 1); j < length; j++)
            //    {

            //        if(nums[j] != 0)
            //        {
            //            nums[iniPointer] = nums[j];
            //            nums[j] = 0;
            //            break;
            //        }

            //    }
            //    iniPointer = iniPointer + 1;
            //} 
            #endregion
        }
    }
}
