using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1};
            int k = 3;
            int temp = 0;
            int len = arr.Length;

            //solution 1 - naive
            //for (int i = 0; i < k; i++)
            //{
            //    temp = arr[len - 1];
            //    for (int j = (len - 1); j > 0; j--)
            //    {
            //        arr[j] = arr[j - 1];
            //    }
            //    arr[0] = temp;
            //}

            //solution 2
            int[] arr1 = new int[len];

            for (int i = 0; i < len; i++)
                arr1[i] = arr[i];
            int newPointer = 0;
            for (int j = 0; j < len; j++)
            {
                newPointer = (j + k)%len;
                arr[newPointer] = arr1[j];
            }
                


            
        }
    }
}
