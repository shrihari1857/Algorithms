using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularArraySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var arr = new int[] { 12, 14, 18, 21, 3, 6, 8, 9 };
            var index = CircularSearch(arr, 8);
        }

        private static object CircularSearch(int[] arr, int x)
        {
            var low = 0;
            var high = arr.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (x == arr[mid])
                    return mid;

                if(arr[mid] <=arr[high])
                {
                    if (x > arr[mid] && x <= arr[high])
                        low = mid + 1;
                    else
                        high = mid - 1;
                }
                else
                {
                    if (arr[low] <= x && x < arr[mid])
                        high = mid - 1;
                    else
                        low = mid + 1;
                }
            }

            return -1;
        }
    }
}
