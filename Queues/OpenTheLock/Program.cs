using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTheLock
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new string[] { "0201", "0101", "0102", "1212", "2002" };
            var f = openLock(t, "0202");
        }

        public static int openLock(String[] deadends, String target)
        {
            HashSet<String> dead = new HashSet<String>();

            foreach (var d in deadends)
            {
                dead.Add(d);
            }

            Queue<String> queue = new Queue<String>();
            queue.Enqueue("0000");
            queue.Enqueue(null);

            HashSet<String> seen = new HashSet<String>();
            seen.Add("0000");

            int depth = 0;
            while (queue.Count != 0)
            {
                String node = queue.Dequeue();
                if (node == null)
                {
                    depth++;
                    if (queue.Peek() != null)
                        queue.Enqueue(null);
                }
                else if (node.Equals(target))
                {
                    return depth;
                }
                else if (!dead.Contains(node))
                {
                    for (int i = 0; i < 4; ++i)
                    {
                        for (int d = -1; d <= 1; d += 2)
                        {
                            int y = ((node[i] - '0') + d + 10) % 10;
                            String nei = node.Substring(0, i) + ("" + y) + node.Substring(i + 1);
                            if (!seen.Contains(nei))
                            {
                                seen.Add(nei);
                                queue.Enqueue(nei);
                            }
                        }
                    }
                }
            }
            return -1;
        }
    }
}
