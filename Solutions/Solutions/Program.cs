using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
    {
        while (node != null)
        {
            Console.Write(node.data);

            node = node.next;

            if (node != null)
            {
                Console.Write(sep);
            }
        }
    }

    // Complete the mergeLists function below.

    /*
     * For your reference:
     *
     * SinglyLinkedListNode {
     *     int data;
     *     SinglyLinkedListNode next;
     * }
     *
     */
    static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
    {
        SinglyLinkedList merge = new SinglyLinkedList();

        while(head1 != null && head2 != null)
        {
            if(head1.data == head2.data)
            {
                merge.InsertNode(head1.data);
                merge.InsertNode(head2.data);

                head1 = head1.next;
                head2 = head2.next;
            }
            else if(head1.data < head2.data)
            {
                merge.InsertNode(head1.data);

                head1 = head1.next;
            }
            else if (head2.data < head1.data)
            {
                merge.InsertNode(head2.data);

                head2 = head2.next;
            }
            else if(head1 == null)
            {
                merge.InsertNode(head1.data);

                head1 = head1.next;
            }
            else if (head2 == null)
            {
                merge.InsertNode(head2.data);

                head2 = head2.next;
            }
        }

        if((head1 == null && head2 != null) || (head1 != null && head2 == null))
        {
            var temp = head1 == null ? head2 : head1;

            while(temp != null)
            {
                merge.InsertNode(temp.data);

                temp = temp.next;
            }
        }

        return merge.head;
    }

    static void Main(string[] args)
    {

        int tests = Convert.ToInt32(Console.ReadLine());

        for (int testsItr = 0; testsItr < tests; testsItr++)
        {
            SinglyLinkedList llist1 = new SinglyLinkedList();

            int llist1Count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llist1Count; i++)
            {
                int llist1Item = Convert.ToInt32(Console.ReadLine());
                llist1.InsertNode(llist1Item);
            }

            SinglyLinkedList llist2 = new SinglyLinkedList();

            int llist2Count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llist2Count; i++)
            {
                int llist2Item = Convert.ToInt32(Console.ReadLine());
                llist2.InsertNode(llist2Item);
            }

            SinglyLinkedListNode llist3 = mergeLists(llist1.head, llist2.head);

            PrintSinglyLinkedList(llist3, " ");
            Console.WriteLine();
        }
    }
}
