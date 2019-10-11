using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMoreSoln
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 9, 8, 5, 4, 3, 6, 2};
            var rotateTo = 3;
            var temp = 0;
            var lastPointer = Convert.ToInt32((float)arr.Length / 2);
            for (int i = 0; i < lastPointer; i++)
            {
                var nextPointer = (i + rotateTo) % arr.Length;
                temp = arr[i];
                arr[i] = arr[nextPointer];
                arr[nextPointer] = temp;
            }
            Console.WriteLine(string.Join(", ", arr));
            Console.ReadLine();
        }
    }
}
