using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            //100, 30, 20, 1, 3, 10, 15
            var arr = new int[] { 10, 9, 8, 7, 43, 235, 256,977, 4};
            var heap = new Heap<int>();
            foreach (var item in arr)
                heap.Insert(item);

            heap.HeapSort(heap, heap.size() - 1);
            //var max = heap.Peek();
            //heap.Increase(8, 40);
            //Get and delete max heap
            //var maxDeleted = heap.DeleteMax();
            
        }
    }
}
