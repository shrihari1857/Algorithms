using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCircularQueue obj = new MyCircularQueue(5);
            bool param_1 = obj.EnQueue(6);
            int param_8 = obj.Rear();
            int param_81 = obj.Rear();
            bool param_6 = obj.DeQueue();
            bool param_2 = obj.EnQueue(5);
            int param_81s = obj.Rear();
            bool param_6s = obj.DeQueue();
            int param_7s = obj.Front();
            bool param_6ss = obj.DeQueue();
            bool param_6sa = obj.DeQueue();
            bool param_6ssa = obj.DeQueue();


           
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

            tail = (tail + 1)%length;
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
            head = (head + 1)%length;

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
