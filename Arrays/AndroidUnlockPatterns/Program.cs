using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidUnlockPatterns
{
    class Program
    {
        static int result;
        static void Main(string[] args)
        {
            var result = numberOfPatterns(3, 4);
        }

        public static int numberOfPatterns(int m, int n)
        {
            bool[] visited = new bool[10];
            for (int i = 1; i <= 9; i++)
            {
                visited[i] = true;
                dfs(i, 1, m, n, visited);
                visited[i] = false;
            }

            return result;
        }
        private static bool canMove(int start, int end, bool[] visited)
        {
            if (visited[end])
            {
                return false;
            }

            // on the same row
            if (Math.Abs(start - end) == 2 && (start - 1) / 3 == (end - 1) / 3)
            {
                return visited[(start + end) / 2];
            }

            // on the same col
            if (Math.Abs(start - end) == 6 && start % 2 == end % 2)
            {
                return visited[(start + end) / 2];
            }

            if (start + end == 10)
            {
                return visited[5];
            }

            return true;
        }

        private static void dfs(int start, int count, int m, int n, bool[] visited)
        {
            if (count >= m && count <= n)
            {
                result++;
            }

            if (count > n)
            {
                return;
            }

            for (int i = 1; i <= 9; i++)
            {
                if (!canMove(start, i, visited))
                {
                    continue;
                }

                visited[i] = true;
                dfs(i, count + 1, m, n, visited);
                visited[i] = false;
            }
        }
    }
}
