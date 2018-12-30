using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {

            #region MyRegion
            /*
               Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order.

  Example 1:

  Input:
  [
   [ 1, 2, 3 ],
   [ 4, 5, 6 ],
   [ 7, 8, 9 ]
  ]
  Output: [1,2,3,6,9,8,7,4,5]
  Example 2:

  Input:
  [
    [1, 2, 3, 4],
    [5, 6, 7, 8],
    [9,10,11,12]
  ]
  Output: [1,2,3,4,8,12,11,10,9,5,6,7]
               */
            #endregion


            var matrix = new int[3, 3]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i; j < matrix.GetLength(1); j++)
                {

                }
            }
        }
    }
}
