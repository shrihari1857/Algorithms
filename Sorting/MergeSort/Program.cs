using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 2, 4, 1, 6, 8, 5, 3, 7, 9};
            Sort(arr);
        }

        private static void Sort(int[] arr)
        {
            if (arr.Length < 2)
                return;

            var mid = arr.Length / 2;
            var left = new ArraySegment<int>(arr, 0, mid).ToArray<int>();
            var right = new ArraySegment<int>(arr, mid, arr.Length - mid).ToArray<int>();

            Sort(left);
            Sort(right);
            Merge(left, right, arr);

        }

        private static void Merge(int[] left, int[] right, int[] arr)
        {
            var i = 0;
            var j = 0;
            var k = 0;

            while (!(i >= left.Length) && !(j >= right.Length))
            {
                if (left[i] < right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }
        }
    }
}
