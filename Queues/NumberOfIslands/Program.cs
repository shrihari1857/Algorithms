using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion
            /*
                Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

   Example 1:

   Input:
   11110
   11010
   11000
   00000

   Output: 1
   Example 2:

   Input:
   11000
   11000
   00100
   00011

   Output: 3
                */
            #endregion

            char[,] grid = new char[,]
            {
                {'1','1','0','0','0'},
                {'1','1','0','0','0'},
                {'0','0','1','0','0'},
                {'0','0','0','1','1' }
            };
            //char[,] grid = new char[,]
            //{
            //{'1','1','1','1','0'},
            //{'1','1','0','1','0'},
            //{'1','1','0','0','0'},
            //{'0','0','0','0','0'}
            //};

            var queue = new Queue<int[]>(grid.Length);
            var visited = new int[grid.Length];
            var length = grid.GetLength(0);
            var breadth = grid.GetLength(1);
            var count = 0;
            var allZeroCount = 0;
            var onesCount = true;

            for (int i = 0; i < length; i++)
                for (int j = 0; j < breadth; j++)
                    if (grid[i, j] == '1')
                        queue.Enqueue(new int[] { i, j });

            int result = 0;

            if (queue.Count == 0)
                result = count;
            // return count;
            //else
            //    count++;

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                visited[breadth * item[0] + item[1]] = 1;

                var t = breadth * (item[0] - 1) + item[1];
                if (item[0] - 1 >= 0 && t >= 0 && visited[t] == 0)
                {
                    if (grid[item[0] - 1, item[1]] == '0')
                        allZeroCount++;
                    else //if (visited[t] == 0)
                    {
                        onesCount = onesCount && true;
                        visited[t] = 1;
                    }
                    //else if (onesCount)
                    //    onesCount = false;
                    //else if (visited[t] == 0)
                    //    onesCount = true;

                    
                    queue.Enqueue(new int[] { item[0] - 1, item[1] });
                }
                t = breadth * (item[0] + 1) + item[1];
                if (item[0] + 1 <= length - 1 && t >= 0 && visited[t] == 0)
                {
                    if (grid[item[0] + 1, item[1]] == '0')
                        allZeroCount++;
                    else //if (visited[t] == 0)
                    {
                        onesCount = onesCount && true;
                        visited[t] = 1;
                    }
                    //else if (onesCount)
                    //    onesCount = false;
                    //else if (visited[t] == 0)
                    //    onesCount = true;
                    queue.Enqueue(new int[] { item[0] + 1, item[1] });
                }
                t = breadth * (item[0]) + item[1] - 1;
                if (item[1] - 1 >= 0 && t >= 0 && visited[t] == 0)
                {
                    if (grid[item[0], item[1] - 1] == '0')
                        allZeroCount++;
                    else// if (visited[t] == 0)
                    {
                        onesCount = onesCount && true;
                        visited[t] = 1;
                    }
                    //else if (onesCount)
                    //    onesCount = false;
                    //else if (visited[t] == 0)
                    //    onesCount = true;
                    queue.Enqueue(new int[] { item[0], item[1] - 1 });
                }
                t = breadth * (item[0]) + item[1] + 1;
                if (item[1] + 1 <= breadth - 1 && t >= 0 && visited[t] == 0)
                {
                    if (grid[item[0], item[1] + 1] == '0')
                        allZeroCount++;
                    else// if (visited[t] == 0)
                    {
                        onesCount = onesCount && true;
                        visited[t] = 1;
                    }
                    //else if (onesCount)
                    //    onesCount = false;
                    //else if (visited[t] == 0)
                    //    onesCount = true;
                    queue.Enqueue(new int[] { item[0], item[1] + 1 });
                }

                if (allZeroCount == 4 || onesCount)
                {
                    count++;
                    
                }

                onesCount = false;

                allZeroCount = 0;
                

            }

        }
    }
}
