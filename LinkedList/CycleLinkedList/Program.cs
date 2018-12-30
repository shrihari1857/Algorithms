using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var head = new ListNode(1);
            var f = head;

            for (int i = 2; i < 5; i++)
            {
                f.next = new ListNode(i);
                f = f.next;
            }
            var g = f;

            for (int i = 5; i < 10; i++)
            {
                f.next = new ListNode(i);
                f = f.next;
            }

            f.next = g;

            bool result = false;
            var slow = head;
            var fast = head.next.next;

            while (fast != null && fast.next != null)
            {
                if (fast == slow)
                    result = true;

                slow = slow.next;
                fast = fast.next.next;

            }


            //for (int i = 10; i < 15; i++)
            //{
            //    f.next = new ListNode(i);
            //    f = f.next;
            //}
        }
    }

     public class ListNode
     {
         public int val;
         public ListNode next;
         public ListNode(int x)
          {
              val = x;
              next = null;
          }
     }
}
