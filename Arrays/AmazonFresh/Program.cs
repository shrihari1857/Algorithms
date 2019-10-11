using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonFresh
{
    class Program
    {
        static void Main(string[] args)
        {
            //var list = 
                ClosestXdestinations(3, new int[,] { { 1, 2 }, { 3, 4 }, { 1, -1 } }, 2);
        }

        //List<List<int>>
        public static void  ClosestXdestinations(int numDestinations,
                                                int[,] allLocations,
                                                int numDeliveries)
        {
            var arr = new Destination[numDestinations];

            for (int i = 0; i < numDestinations; i++)
            {
                double sum = 0.0;
                var list = new List<int>();

                for (int j = 0; j < 2; j++)
                {
                    sum = sum + Math.Pow(allLocations[i, j], 2);
                    list.Add(allLocations[i, j]);
                }
                arr[i] =
                    new Destination
                    {
                        distance = Math.Sqrt(sum),
                        Coords = list
                    };
            }

            heapSort(arr, numDestinations);

            var result = new List<List<int>>();

            for (int i = 0; i < numDeliveries; i++)
            {
                result.Add(arr[i].Coords);
            }

            return result;
           
        }

        static void heapSort(Destination[] arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                Destination temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                heapify(arr, i, 0);
            }
        }
        static void heapify(Destination[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left].distance > arr[largest].distance)
                largest = left;
            if (right < n && arr[right].distance > arr[largest].distance)
                largest = right;
            if (largest != i)
            {
                Destination swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                heapify(arr, n, largest);
            }
        }
    }

    public class Destination
    {
        public double distance { get; set; }
        public List<int> Coords { get; set; }
    }



    //public class Heap<T>
    //{
    //    private List<T> _data = new List<T>();

    //    public void Insert(T t)
    //    {
    //        _data.Add(default(T));
    //        Increase(_data.Count - 1, t);
    //    }

    //    public int size()
    //    {
    //        return _data.Count;
    //    }

    //    private void Swap(int item1, int item2)
    //    {
    //        var temp = _data[item1];
    //        _data[item1] = _data[item2];
    //        _data[item2] = temp;
    //    }

    //    internal void HeapSort(Heap<int> heap, int lastMaxPointer)
    //    {
    //        if (lastMaxPointer <= 0)
    //            return;

    //        Swap(0, lastMaxPointer);
    //        lastMaxPointer = lastMaxPointer - 1;
    //        minHeapify(0, lastMaxPointer);
    //        HeapSort(heap, lastMaxPointer);
    //    }

    //    public T Peek()
    //    {
    //        return _data[0];
    //    }

    //    public T DeleteMax()
    //    {
    //        var retValue = _data[0];
    //        _data[0] = _data[_data.Count - 1];
    //        _data.RemoveAt(_data.Count - 1);
    //        minHeapify(0, _data.Count - 1);
    //        return retValue;
    //    }

    //    public void Increase(int i, T t)
    //    {
    //        _data[i] = t;
    //        //_data.Count - 1
    //        var index = i;
    //        while (index > 0 && _data[(int)Math.Floor((double)(index - 1) / 2)]) < _data[index]))
    //        {
    //            Swap(index, index / 2);
    //            index = index / 2;
    //        }
    //    }

    //    public void minHeapify(int index, int finalIndex)
    //    {
    //        if (index >= finalIndex)
    //            return;

    //        var largest = index;
    //        var left = index * 2 + 1;
    //        var right = left + 1;


    //        if (left >= finalIndex && Comparer<T>.Default.Compare(_data[index], _data[left]) < 0)
    //            largest = left;

    //        if (right >= finalIndex && Comparer<T>.Default.Compare(_data[largest], _data[right]) < 0)
    //            largest = right;

    //        if (index != largest)
    //        {
    //            Swap(index, largest);
    //            minHeapify(largest, finalIndex);
    //        }


    //    }
    //}
}
