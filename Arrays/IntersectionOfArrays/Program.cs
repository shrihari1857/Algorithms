using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionOfArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] nums1 = { 1, 2, 2, 1 };
            //int[] nums2 = { 2, 2 };

            int[] nums1 = {1, 2, 2, 1};
            int[] nums2 = { 2 };

            int len1 = nums1.Length;
            int len2 = nums2.Length;

            int[] arr = new int[len1];
            int count = 0;

            for (int i = 0; i < len2; i++)
                for (int j = 0; j < len1; j++)
                    if (nums2[i] == nums1[j] && arr[j] == 0)
                    {
                        arr[j] = 1;
                        count++;
                        break;
                    }

            int[] result = new int[count];
            int pointer = 0;
            for (int i = 0; i < len1; i++)
                if (arr[i] == 1)
                {
                    result[pointer] = nums1[i];
                    pointer++;
                }
        }
    }
}
