using GraphTheory.Sets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            var dsSet = new DisjointSet();
            dsSet.MakeSet(1);
            dsSet.MakeSet(2);
            dsSet.MakeSet(3);
            dsSet.MakeSet(4);
            dsSet.MakeSet(5);
            dsSet.MakeSet(6);
            dsSet.MakeSet(7);

            dsSet.MakeSet(11);
            dsSet.MakeSet(12);
            dsSet.MakeSet(13);
            dsSet.MakeSet(14);

            dsSet.Union(1, 2);
            dsSet.Union(2, 3);
            dsSet.Union(4, 5);
            dsSet.Union(6, 7);
            dsSet.Union(5, 6);
            dsSet.Union(3, 7);

        }
    }
}
