using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion
            /*
                 You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

                You may assume the two numbers do not contain any leading zero, except the number 0 itself.

                Example:

                Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
                Output: 7 -> 0 -> 8
                Explanation: 342 + 465 = 807.
                 */
            #endregion
            //var l1 = new ListNode(2);
            //l1.next = new ListNode(4);
            //l1.next.next = new ListNode(3);

            //var l2 = new ListNode(5);
            //l2.next = new ListNode(6);
            //l2.next.next = new ListNode(4);

            var l1 = new ListNode(9);
            var l2 = new ListNode(1);
            l2.next = new ListNode(9);
            l2.next.next = new ListNode(9);
            l2.next.next.next = new ListNode(9);
            l2.next.next.next.next = new ListNode(9);
            l2.next.next.next.next.next = new ListNode(9);
            l2.next.next.next.next.next.next = new ListNode(9);
            l2.next.next.next.next.next.next.next = new ListNode(9);
            l2.next.next.next.next.next.next.next.next = new ListNode(9);
            l2.next.next.next.next.next.next.next.next.next = new ListNode(9);

            var s1 = new StringBuilder();
            var s2 = new StringBuilder();
            

            var head = l1;
            while (head != null)
            {
                s1.Insert(0, head.val.ToString());
                head = head.next;
            }

            head = l2;
            while (head != null)
            {
                s2.Insert(0, head.val.ToString());
                head = head.next;
            }

            var length1 = s1.Length - 1;
            var length2 = s2.Length - 1;

            var length = length1;

            if (length2 > length1)
                length = length2;

            int d = 0;
            ListNode newHead = new ListNode(0); ;
            ListNode refHead = newHead;
            var firstZero = false;
            var firstHead = false;

            while (length >= 0)
            {
                
                int a = 0;
                int b = 0;
                int c = 0;

                if (length1 >= 0)
                    a = Int32.Parse(s1[length1].ToString());

                if (length2 >= 0)
                    b = Int32.Parse(s2[length2].ToString());

                c = a + b + d;

                if (c > 9)
                {
                    c = c % 10;
                    d = 1;
                }
                else
                    d = 0;

                if (c > 0 && !firstZero)
                {
                    firstZero = true;
                   
                }

                if (firstZero)
                {
                    var item = new ListNode(c);

                    if (!firstHead)
                    {
                        newHead = item;
                        refHead = newHead;
                        firstHead = true;
                    }
                    else
                    {
                        newHead.next = item;
                        newHead = item;
                    }
                }

                length--;
                length1--;
                length2--;
            }

            if (d > 0)
                newHead.next = new ListNode(d);

        }
    }

     public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
