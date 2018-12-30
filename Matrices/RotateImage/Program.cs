using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateImage
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion
            /*
                 You are given an n x n 2D matrix representing an image.

    Rotate the image by 90 degrees (clockwise).

    Note:

    You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.

    Example 1:

    Given input matrix = 
    [
      [1,2,3],
      [4,5,6],
      [7,8,9]
    ],

    rotate the input matrix in-place such that it becomes:
    [
      [7,4,1],
      [8,5,2],
      [9,6,3]
    ]
    Example 2:

    Given input matrix =
    [
      [ 5, 1, 9,11],
      [ 2, 4, 8,10],
      [13, 3, 6, 7],
      [15,14,12,16]
    ], 

    rotate the input matrix in-place such that it becomes:
    [
      [15,13, 2, 5],
      [14, 3, 4, 1],
      [12, 6, 8, 9],
      [16, 7,10,11]
    ]
                 */
            #endregion

            var matrix = new int[3, 3]
            {
                {1,2,3},
                {4,5,6},
                {7,8,9}
            };

            int length = matrix.Length - 1;

            for (int i = 0; i <= (length) / 2; i++)
            {
                for (int j = i; j < length - i; j++)
                {

                    //Coordinate 1
                    int p1 = matrix[i,j];

                    //Coordinate 2
                    int p2 = matrix[j,length - i];

                    //Coordinate 3
                    int p3 = matrix[length - i,length - j];

                    //Coordinate 4
                    int p4 = matrix[length - j,i];

                    //Swap values of 4 coordinates.
                    matrix[j,length - i] = p1;
                    matrix[length - i,length - j] = p2;
                    matrix[length - j,i] = p3;
                    matrix[i,j] = p4;
                }
            }
        }
    }
}
