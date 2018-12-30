using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            var head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(1);

            head = Rev(head);
        }

        private static ListNode Rev(ListNode node)
        {
            if (node.next == null)
                return node;
            else
            {
                var head = Rev(node.next);
                node.next.next = node;
                node.next = null;
                return head;
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
