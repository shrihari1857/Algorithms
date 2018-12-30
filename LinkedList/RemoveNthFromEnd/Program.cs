using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNthFromEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            var head = new ListNode(1);
           head.next = new ListNode(2);
           head.next.next = new ListNode(3);
           head.next.next.next = new ListNode(4);
           head.next.next.next.next = new ListNode(5);
            int length = 0;
            var nodeList = new List<ListNode>();

            var currNode = head;

            while (currNode != null)
            {
                length++;
                nodeList.Add(currNode);
                currNode = currNode.next;
            }

            var arr = nodeList.ToArray();

            if (length == n)
                head = head.next;
            else
                arr[length - n -1].next = arr[(length - n)%length].next;
            //arr[n % length].next = arr[length - n].next;

            //return head;

            //if ((n % length) == 0)
            //{
            //    head = arr[length - n].next;
            //}
            //arr[length - 1 - n].next = arr[length - n].next;



        }
    }

    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }
}
