using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mat = { { 0, 0, 0, 1 },
                        { 0, 1, 1, 1 },
                        { 1, 1, 1, 1 },
                        { 0, 0, 0, 0 } };
            var result = rowWithMax1s(mat);
        }

        private static object rowWithMax1s(int[,] mat)
        {
            // Initialize max values
            int max_row_index = 0, max = -1;
            var R = mat.GetLength(0);
            var C = mat.GetLength(1);

            // Traverse for each row and count number of 1s 
            // by finding the index of first 1
            int i, index;
            for (i = 0; i < R; i++)
            {
                var row = mat.GetRow(i);
                index = first(row, 0, C - 1);
                if (index != -1 && C - index > max)
                {
                    max = C - index;
                    max_row_index = i;
                }
            }

            return max_row_index;
        }

        private static int first(int[] arr, int low, int high)
        {
            if (high >= low)
            {
                // Get the middle index 
                int mid = low + (high - low) / 2;

                // Check if the element at middle index is first 1
                if ((mid == 0 || arr[mid - 1] == 0) && arr[mid] == 1)
                    return mid;

                // If the element is 0, recur for right side
                else if (arr[mid] == 0)
                    return first(arr, (mid + 1), high);

                // If element is not first 1, recur for left side
                else
                    return first(arr, low, (mid - 1));
            }
            return -1;
        }
    }

    public static class Extensions
    {
        public static T[] GetRow<T>(this T[,] matrix, int row)
        {
            var rowLength = matrix.GetLength(1);
            var rowVector = new T[rowLength];

            for (var i = 0; i < rowLength; i++)
                rowVector[i] = matrix[row, i];

            return rowVector;
        }
    }
}
