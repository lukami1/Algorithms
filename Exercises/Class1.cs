using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
    
    public class Solution
    {
        public static ListNode Partition(ListNode head, int x)
        {
            var newNode = new ListNode(head.val);
            head = head.next;
            while (head != null)
            {
                if (head.val < x)
                {
                    newNode = MoveToLefT(newNode, x, head.val);
                }
                else
                {
                    var cp = newNode;
                    while (cp.next != null)
                    {
                        cp = cp.next;
                    }
                    cp.next = new ListNode(head.val);
                }
                head = head.next;
            }
            return newNode;
        }

        private static ListNode MoveToLefT(ListNode node, int v, int newV)
        {
            var cp = node;
            var n = new ListNode(newV);
            if (cp.val >= v)
            {
                n.next = cp;
                cp = n;
                return cp;
            }
            while (cp.next != null)
            {
                if (cp.next.val < v)
                {
                    cp = cp.next;
                }
                else
                {
                    var nn = cp.next;
                    n.next = nn;
                    cp.next = n;
                    return node;
                }
            }
            cp.next = n;
            return node;
        }
    }
}
