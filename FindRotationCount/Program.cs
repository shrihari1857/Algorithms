using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRotationCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 15, 22, 23, 28, 31, 38, 5, 6, 8, 10, 12 };
            var count = FindRotnCount(arr);
        }

        private static int FindRotnCount(int[] arr)
        {
            var low = 0;
            var n = arr.Count();
            var high = n - 1;
            while (low <= high)
            {
                if (arr[low] <= arr[high])    //Case 1
                    return low;

                int mid = (low + high) / 2;
                int next = (mid + 1) % n;
                int prev = (mid + n - 1) % n;

                if (arr[mid] <= arr[next] && arr[mid] >= arr[prev]) //Case 2
                    return mid;
                else if (arr[mid] <= arr[high]) //Case 3
                    high = mid - 1;
                else if (arr[mid] >= arr[low])  //Case 4
                    low = mid + 1;
            }

            return -1;
        }
    }
}
