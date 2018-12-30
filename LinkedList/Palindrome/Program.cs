using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result = true;
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(1);
            var newHead = head;
            var revHead = new ListNode(head.val);
            var node = head;

            while (head.next != null)
            {
                node = new ListNode(head.next.val);
                node.next = revHead;
                revHead = node;
                head = head.next;
            }

            while (newHead.next != null)
            {
                if (newHead.next.val != node.next.val)
                    result = false;

                newHead = newHead.next;
                node = node.next;
            }
        }
    }

    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }
}
