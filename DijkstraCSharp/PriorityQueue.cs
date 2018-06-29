using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraCSharp
{
    public class PriorityQueue
    {
        private List<PQtype> _data = new List<PQtype>();

        public Vertex Minumum()
        {
            return _data[0].Vertex;
        }

        public void Insert(PQtype newItem)
        {
            _data.Add(newItem);
            var index = _data.Count - 1;
            var parentIndex = (int)Math.Floor((double)(index - 1) / 2);
            while (index >=0 && parentIndex >=0 && _data[index].Distance < _data[parentIndex].Distance)
            {
                Swap(index, parentIndex);
                index = index / 2;
            }

        }

        public Vertex DeleteMinimum()
        {
            var minHeap = _data[0];
            _data[0] = _data[_data.Count - 1];
            _data.RemoveAt(_data.Count - 1);
            MinHeapify(0);

            return minHeap.Vertex;
        }

        public void DecreaseKey(Vertex vertex, int value)
        {
            var done = false;
            var index = 0;
            var key = 0;
            while (!done && index < _data.Count)
            {
                if (_data[index].Vertex == vertex)
                {
                    _data[index].Distance = value;
                    done = true;
                    key = index;
                }
                index = index + 1;
            }
            while (key > 0 && Convert.ToInt32(_data[(int)Math.Floor((double)(key - 1) / 2)].Distance) > Convert.ToInt32(_data[key].Distance))
            {
                Swap(key, key / 2);
                key = key / 2;
            }
        }

        private void MinHeapify(int index)
        {
            var largest = index;
            var left = index * 2 + 1;
            var right = left + 1;
            var lastPointer = _data.Count - 1;

            if (left <= lastPointer && _data[left].Distance < _data[largest].Distance)
                largest = left;

            if (right <= lastPointer && _data[right].Distance < _data[largest].Distance)
                largest = right;

            if (largest != index)
            {
                Swap(index, largest);
                MinHeapify(largest);
            }
        }

        public bool isEmpty()
        {
            return _data.Count == 0;
        }
        private void Swap(int index, int largest)
        {
            var temp = _data[index];
            _data[index] = _data[largest];
            _data[largest] = temp;
        }
    }
}
