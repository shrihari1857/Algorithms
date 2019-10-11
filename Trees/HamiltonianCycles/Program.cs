using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamiltonianCycles
{
    class Program
    {
        static List<int[]> result = new List<int[]>();
        static int[] x;
        static int n;
        static int[,] graph;
        static void Main(string[] args)
        {

            graph = new int[5, 5]
            {
                { 0, 1, 1, 0, 1 },
                { 1, 0, 1, 1, 1 },
                { 1, 1, 0, 1, 0 },
                { 0, 1, 1, 0, 1 },
                { 1, 1, 0, 1, 0 }
            };
            x = new int[5];
            x[0] = 1;
            n = 5;
            int k = 1;
            Hamiltonion(k);

        }

        private static void Hamiltonion(int k)
        {
            do
            {
                NextVertex(k);

                if (x[k] == 0)
                    return;

                if (k == n - 1)
                {
                    result.Add(x);  //add it to the list
                    return;
                }
                else
                    Hamiltonion(k + 1);

            } while (true);
        }

        private static void NextVertex(int k)
        {
            do
            {
                x[k] = (x[k] + 1) % (n + 1);

                if (x[k] == 0 || x[k] >= n) return;

                if (graph[x[k - 1], x[k]] != 0)
                {
                    if (k > 0 && graph[x[k - 1], x[k]] != 0)
                    {
                        for (int i = 0; i < x[k - 1]; i++)
                        {
                            if (x[i] == x[k])
                                break;

                            if (i == k)
                                if (k < n || (k == n) && graph[x[n - 1], x[1]] != 0)
                                    return;
                        }
                        if(x[k] >= k)
                            return;
                    }
                    //else
                        
                }

            } while (true);
        }
    }
}
