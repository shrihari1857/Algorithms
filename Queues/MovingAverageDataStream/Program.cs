using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingAverageDataStream
{
    class Program
    {
        static void Main(string[] args)
        {
            var movingAverage = new MovingAverage(5);
            movingAverage.Next(12009);
            movingAverage.Next(1965);
            movingAverage.Next(-940);
            movingAverage.Next(-8516);
        }
    }

    public class MovingAverage
    {
        MyCircularQueue _myCircularQueue;
        int _size;
        int _total;
        int _count;
        /** Initialize your data structure here. */
        public MovingAverage(int size)
        {
            _myCircularQueue = new MyCircularQueue(size);
        }

        public double Next(int val)
        {
            _total = _total + val;
            _count++;

            if(_myCircularQueue.IsFull())
            {
                _total = _total - _myCircularQueue.Front();
                _myCircularQueue.DeQueue();
                _count--;
            }

            _myCircularQueue.EnQueue(val);

            decimal result = (decimal)_total /_count;

            return (double)result;

        }
    }

    public class MyCircularQueue
    {
        int[] arr;
        int head = 0;
        int tail = -1;
        int count = 0;
        int length = 0;

        /** Initialize your data structure here. Set the size of the queue to be k. */
        public MyCircularQueue(int k)
        {
            arr = new int[k];
            length = k;
        }

        /** Insert an element into the circular queue. Return true if the operation is successful. */
        public bool EnQueue(int value)
        {
            if (count == length)
                return false;

            tail = (tail + 1) % length;
            arr[tail] = value;
            count++;
            return true;
        }

        /** Delete an element from the circular queue. Return true if the operation is successful. */
        public bool DeQueue()
        {
            if (count == 0)
                return false;

            count--;
            head = (head + 1) % length;

            return true;
        }

        /** Get the front item from the queue. */
        public int Front()
        {
            if (count == 0)
                return -1;

            return arr[head];
        }

        /** Get the last item from the queue. */
        public int Rear()
        {
            if (count == 0)
                return -1;

            return arr[tail];
        }

        /** Checks whether the circular queue is empty or not. */
        public bool IsEmpty()
        {
            return count == 0;
        }

        /** Checks whether the circular queue is full or not. */
        public bool IsFull()
        {
            return count == length;
        }
    }
}
