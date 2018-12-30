using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfIslands2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] grid = new char[,]
            {
                {'1','1','0','0','0'},
                {'1','1','0','0','0'},
                {'0','0','1','0','0'},
                {'0','0','0','1','1' }
            };
            //char[,] grid = new char[,]
            //{
            //    { '1','1','1','1','0'},
            //    { '1','1','0','1','0'},
            //    { '1','1','0','0','0'},
            //    { '0','0','0','0','0'}
            //};

            //char[,] grid = new char[,]
            //{
            //    { '1', '1'},
            //};

            var length = grid.GetLength(0);
            var breadth = grid.GetLength(1);
            var visited = new int[length, breadth];
            var queue = new Queue<int[]>(grid.Length);
            var count = 0;
            var flag = false;
            var dontExit = true;

            for (int i = 0; i < length; i++)
                for (int j = 0; j < breadth; j++)
                    if (grid[i, j] == '1')
                        queue.Enqueue(new int[] { i, j });

            int result = 0;

            if (queue.Count == 0 || queue.Count == 1)
                result = count;

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                visited[item[0], item[1]] = 1;

                for (int i = -1; i < 2; i=i+2)
                {
                    if (!dontExit)
                        break;

                    

                    for (int j = -1; j < 2; j=j+2)
                    {
                        var x = item[0] + i;
                        var y = item[1] + j;

                        if (x >= 0 && x < length)
                        {
                            if (grid[x, item[1]] == '1' && visited[x, item[1]] == 1)
                            {
                                flag = flag && false;
                                dontExit = false;
                                break;

                            }
                            else
                            {
                                flag = true;
                                visited[x, item[1]] = 1;
                            }
                            
                        }
                        if (y >= 0 && y < breadth)
                        {
                            if (grid[item[0], y] == '1' && visited[item[0], y] == 1)
                            {
                                flag = flag && false;
                                dontExit = false;
                                break;

                            }
                            else
                            {
                                flag = true;
                                visited[item[0], y] = 1;
                            }
                            
                        }


                        //if ((x >= 0 && x < length) || (y >= 0 && y < breadth))
                        //{
                        //    if (grid[x, item[1]] == '1' && visited[x, item[1]] == 1)
                        //    {
                        //        flag = flag && false;
                        //        dontExit = false;
                        //        break;
                        //    }
                        //    else
                        //    {
                        //       flag = true;
                        //        visited[x, item[1]] = 1;
                        //    }
                        //    if (grid[item[0], y] == '1' && visited[item[0], y] == 1)
                        //    {
                        //        flag = flag && false;
                        //        dontExit = false;
                        //        break;
                        //    }
                        //    else
                        //    {
                        //        flag = true;
                        //        visited[item[0], y] = 1;
                        //    }
                        //}
                    }
                }
                if (flag)
                    count++;

                flag = false;
                dontExit = true;

            }
        }
    }
}
