using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LeetCode2 : ILeetCode
    {
        public string Name => "Add Two Numbers";

        public string Description => @"You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

 

Example 1:

Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.

Example 2:

Input: l1 = [0], l2 = [0]
Output: [0]

Example 3:

Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]

 

Constraints:

    The number of nodes in each linked list is in the range [1, 100].
    0 <= Node.val <= 9
    It is guaranteed that the list represents a number that does not have leading zeros.

";

        public void Run()
        {
            int[] numbers = new int[] { 2, 4, 3 };
            int[] numbers2 = new int[] { 5, 6, 4 };
            ListNode l1 = CreateListNode(numbers);
            ListNode l2 = CreateListNode(numbers2);

            ListNode result = AddTwoNumbers(l1, l2);
        }

        private ListNode CreateListNode(int[] numbers)
        {
            ListNode dummy = new ListNode();
            ListNode current = dummy;

            foreach (int num in numbers)
            {
                current.next = new ListNode(num);
                current = current.next;
            }

            return dummy.next;
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var rootNode = new ListNode();
            var currentNode = rootNode;
            var remainder = 0;

            ListNode? currentListNode1 = l1;
            ListNode? currentListNode2 = l2;

            while(currentListNode1?.val != null || currentListNode2?.val != null || remainder != 0)
            {
                var sum = (currentListNode1?.val ?? 0) + (currentListNode2?.val ?? 0) + remainder;
                var nextInteger = sum % 10;
                remainder = sum / 10;

                currentNode.next = new ListNode(nextInteger);
                currentNode = currentNode.next;

                currentListNode1 = currentListNode1?.next;
                currentListNode2 = currentListNode2?.next;
            }
            return rootNode.next;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
