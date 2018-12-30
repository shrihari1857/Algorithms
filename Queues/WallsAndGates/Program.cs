using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallsAndGates
{
    class Program
    {
        /*
         You are given a m x n 2D grid initialized with these three possible values.

-1 - A wall or an obstacle.
0 - A gate.
INF - Infinity means an empty room. We use the value 231 - 1 = 2147483647 to represent INF as you may assume that the distance to a gate is less than 2147483647.
Fill each empty room with the distance to its nearest gate. If it is impossible to reach a gate, it should be filled with INF.

Example: 

Given the 2D grid:

INF  -1  0  INF
INF INF INF  -1
INF  -1 INF  -1
  0  -1 INF INF
After running your function, the 2D grid should be:

  3  -1   0   1
  2   2   1  -1
  1  -1   2  -1
  0  -1   3   4
             */
        static void Main(string[] args)
        {

            //int[,] rooms = new int[,]
            //{
            //    { 2147483647  , -1          , 0          ,2147483647 },
            //    { 2147483647  ,2147483647   ,2147483647  , -1        },
            //    { 2147483647  , -1          ,2147483647  , -1        },
            //    {   0         , -1          ,2147483647  ,2147483647 },
            //};

            int[,] rooms = new int[,] { { 0, 2147483647, -1, 2147483647, 2147483647, -1, -1, 0, 0, -1, 2147483647, 2147483647, 0, -1, 2147483647, 2147483647, 2147483647, 2147483647, 0, 2147483647, 0, -1, -1, -1, -1, 2147483647, -1, -1, 2147483647, 2147483647, -1, -1, 0, 0, -1, 0, 0, 0, 2147483647, 0, 2147483647, -1, -1, 0, -1, 0, 0, 0, 2147483647 }, { 2147483647, 0, -1, 2147483647, 0, -1, -1, -1, -1, 0, 0, 2147483647, 2147483647, -1, -1, 2147483647, -1, -1, 2147483647, 2147483647, -1, 0, -1, 2147483647, 0, 2147483647, -1, 2147483647, 0, 2147483647, 0, 2147483647, -1, 2147483647, 0, 2147483647, -1, 2147483647, 0, 2147483647, 2147483647, 0, -1, 2147483647, -1, -1, -1, 0, 2147483647 } };

            var queue = new Queue<int[]>(rooms.Length);
            var l = rooms.GetLength(0);
            var b = rooms.GetLength(1);


            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (rooms[i, j] == 0)
                        queue.Enqueue(new int[] { i, j });
                }
            }

            var hashTable = new Hashtable();

            while (queue.Count > 0)
            {
                var d = queue.Dequeue();
                for (int i = -1; i < 2; i+=2)
                {
                    for (int j = -1; j < 2; j+=2)
                    {
                        var x = d[0] + i;
                        if (x >= 0 && x < rooms.GetLength(0))
                        {
                            var t = b * x + d[1];
                            if (!hashTable.ContainsKey(t) && rooms[x, d[1]] == Int32.MaxValue)
                            {
                                rooms[x, d[1]] = rooms[d[0], d[1]] + 1;
                                hashTable[t] = 1;
                                queue.Enqueue(new int[] { x, d[1] });
                            }
                        }
                        var y = d[1] + j;
                        if (y >= 0 && y < rooms.GetLength(1))
                        {
                            var p = b * d[0] + y;
                            if (!hashTable.ContainsKey(p) && rooms[d[0], y] == Int32.MaxValue)
                            {
                                rooms[d[0], y] = rooms[d[0], d[1]] + 1;
                                hashTable[p] = 1;
                                queue.Enqueue(new int[]{d[0], y});
                            }
                        }
                    }
                }
            }
        }
    }
}
