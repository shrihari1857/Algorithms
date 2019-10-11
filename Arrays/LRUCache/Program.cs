using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            var lrucCache = new LRUCache(2);
            lrucCache.Put(1, 1);
            lrucCache.Put(2, 2);
            x = lrucCache.Get(1);
            lrucCache.Put(3, 3);
            x = lrucCache.Get(2);
            lrucCache.Put(4, 4);
            x = lrucCache.Get(1);
            x = lrucCache.Get(3);
            x = lrucCache.Get(4);

        }
    }

    public class LRUCache
    {
        Queue queue;
        Hashtable hashtable = new Hashtable();
        int cap;
        public LRUCache(int capacity)
        {
            cap = capacity;
            queue = new Queue(capacity);
        }

        public int Get(int key)
        {
            if (hashtable.ContainsKey(key))
                return (int)hashtable[key];
            else
                return -1;
        }

        public void Put(int key, int value)
        {
            hashtable[key] = value;
            queue.Enqueue(key);

            if (queue.Count > cap)
            {
                var item = queue.Dequeue();
                hashtable.Remove(item);
            }
        }
    }
}
