using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class Heap<T>
    {
        private List<T> _data = new List<T>();

        public void Insert(T t)
        {
            _data.Add(default(T));
            Increase(_data.Count - 1, t);
        }

        public int size()
        {
            return _data.Count;
        }

        private void Swap(int item1, int item2)
        {
            var temp = _data[item1];
            _data[item1] = _data[item2];
            _data[item2] = temp;
        }

        internal void HeapSort(Heap<int> heap, int lastMaxPointer)
        {
            if (lastMaxPointer <= 0)
                return;

            Swap(0, lastMaxPointer);
            lastMaxPointer = lastMaxPointer - 1;
            maxHeapify(0, lastMaxPointer);
            HeapSort(heap, lastMaxPointer);
        }

        public T Peek()
        {
            return _data[0];
        }

        public T DeleteMax()
        {
            var retValue = _data[0];
            _data[0] = _data[_data.Count - 1];
            _data.RemoveAt(_data.Count - 1);
            maxHeapify(0, _data.Count - 1);
            return retValue;
        }

        public void Increase(int i, T t)
        {
            _data[i] = t;
            //_data.Count - 1
            var index = i;
            while (index > 0 && Convert.ToInt32(_data[(int)Math.Floor((double)(index - 1)/2)]) < Convert.ToInt32(_data[index]))
            {
                Swap(index, index / 2);
                index = index / 2;
            }
        }

        public void maxHeapify(int index, int finalIndex)
        {
            if (index >= finalIndex)
                return;

            var largest = index;
            var left = index * 2 + 1;
            var right = left + 1;

            
            if (left <= finalIndex && Comparer<T>.Default.Compare(_data[index], _data[left]) < 0)
                largest = left;

            if (right <= finalIndex && Comparer<T>.Default.Compare(_data[largest], _data[right]) < 0)
                largest = right;

            if (index != largest)
            {
                Swap(index, largest);
                maxHeapify(largest, finalIndex);
            }


        }
    }
}
