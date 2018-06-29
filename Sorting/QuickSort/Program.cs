using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 2, 9, 1, 6, 8, 5, 3, 7, 4 };
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(int[] arr, int start, int end)
        {
            if (start > end)
                return;

            //var pIndex = Partion(arr, start, end);
            var pIndex = RandomizedPartition(arr, start, end);
            Sort(arr, 0, pIndex.Value - 1);
            Sort(arr, pIndex.Value + 1, end);
        }

        private static int? RandomizedPartition(int[] arr, int start, int end)
        {
            var random = new Random().Next(start, end);
            var temp = arr[end];
            arr[end] = arr[random];
            arr[random] = temp;
            return Partion(arr, start, end);
        }

        private static int? Partion(int[] arr, int start, int end)
        {
            int? pIndex = null;
            var pivot = end;
            var pivotValue = arr[pivot];
            var temp = 0;
            for (int i = 0; i < pivot; i++)
            {
                if(arr[i] < arr[pivot] && pIndex.HasValue)
                {
                    temp = arr[i];
                    arr[i] = arr[pIndex.Value];
                    arr[pIndex.Value] = temp;
                    pIndex = pIndex + 1;
                }
                else if(arr[i] >= arr[pivot] && !pIndex.HasValue) 
                {
                    pIndex = i;
                }
            }
            if (pIndex.HasValue)
            {
                temp = arr[pIndex.Value];
                arr[pIndex.Value] = pivotValue;
                arr[pivot] = temp;
            }
            return pIndex.HasValue ? pIndex.Value : end;
        }
    }
}
