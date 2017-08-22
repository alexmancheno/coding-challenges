using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace coding_challenges
{
    class LinkedLists
    {
        /* P. 94 (2.1) - Remove Dups:
            Write code to remove duplicates from an unsorted linked list.
            Follow up: How would you solve this problem if a temporary buffer 
            is not allowed?
         */

        public static void removeDups(SinglyLinkedList<string> list)
        {
            HashSet<string> set = new HashSet<string>();
            Node<string> i = list.Head;
            Node<string> prev = null;
            while(i != null)
            {
                if (set.Contains(i.getData()))
                {
                    prev.setNext(i.getNext());
                }
                else 
                {
                    set.Add(i.getData());
                    prev = i;
                }
                i = i.getNext();
            }
        }

        public static void removeDupsNoBuffer(SinglyLinkedList<string> list)
        {
            for (Node<string> i = list.Head; i != null; i = i.getNext())
            {
                Node<string> prev = i;
                for (Node<string> j = i.getNext(); j != null; j = j.getNext())
                {
                    if (j.getData().Equals(i.getData()))
                    {
                        prev.setNext(j.getNext());
                    }
                    else
                    {
                        prev = j;
                    }
                }
            }
        }

        /*  P.94 (2.2) - Return Kth to Last:
            Implement an algorithm to find the kth to last element of a singly linked list.
         */

        public static string returnKthToLast(SinglyLinkedList<string> list, int k)
        {
            Node<string> p1 = list.Head;
            Node<string> p2 = list.Head;

            for (int i = 0; i < k; i++)
            {
                if(p1 == null) return null;
                p1 = p1.getNext();
            }

            if (p1 == null) return null;

            while(p1.getNext() != null)
            {
                p1 = p1.getNext();
                p2 = p2.getNext();
            }

            return p2.getData();
        }

        /* P.94 (2.3) - Delete Middle Node:
            Implement an algorithm to delete a node in the middle (i.e., any node but the first and last
            node, not necessarily the exact middle) of a singly linked list, given only access to that
            node.

            EXAMPLE
            Input: a -> b -> c -> d -> e -> f
            Output a -> b -> d -> e -> f
        */
        public static void deleteMiddleNode(SinglyLinkedList<string> list)
        {
            Node<string> i = list.Head;
            Node<string> j = list.Head;
            Node<string> prev = null;
            while (true)
            {
                j = j.getNext();
                if (j != null) j = j.getNext();

                if (j != null)
                {
                    prev = i;
                    i = i.getNext();
                } 
                else break;
            }

            if (i != list.Head)
            {
                prev.setNext(i.getNext());
            }
        }

        /* P. 94 (2.4) - Partition:
            Write code to partition a linked list around a value x, such that all nodes less than x come
            before all nodes greater than or equal to x. If x is contained within the list, the values of
            x only need to be after the elements less than x (see below). The partition element x can 
            appear anywhere in the "right partition"; if it does not need to appear between the left and 
            right partitions.

            EXAMPLE
            Input: 3 -> 5 -> 8 -> 10 -> 2 -> 1 [partition = 5]
            Output: 3 -> 1 -> 2 -> 10 -> 5 -> 5 -< 8
         */
        public static SinglyLinkedList<int> partition(SinglyLinkedList<int> input, int x)
        {
            SinglyLinkedList<int> result = new SinglyLinkedList<int>();
            Node<int> prev = null;
            Node<int> i = input.Head;
            while (i != null)
            {       
                if (i.getData() < x)
                {
                    if (prev != null) 
                        prev.setNext(i.getNext());
                    else if (i == input.Head) 
                        input.Head = input.Head.getNext();
                    result.addLast(i.getData());
                    if (prev == null) prev = i;
                    i = prev.getNext();
                }
                else
                {
                    prev = i;
                    i = i.getNext();
                }
            }

            result.Tail.setNext(input.Head);
            return result;
        }

        /*  P. 95 (2.5) - Sum Lists:
            You have two numbers represented by a linked list, where each node contains a single digit.
            The digits are stored in reverse order, sucht that the 1's digit is at the head of the list. 
            Write a function that adds the two numbers and returns the sum as a linked list.

            EXAMPLE
            Input: (7 -> 1 -> 6) + (5 -> 9 -> 2) = 617 + 295
            Output: (2 -> 1 -> 9) = 912
            
            FOLLOW UP 
            Suppose the digits are stored in forward order. Repeat the above problem.
            EXAMPLE 
            Input: (6 -> 1 -> 7) + (2 -> 9 -> 5) = 617 + 295
            Output: (9 -> 1 -> ) = 912;
         */

         public static SinglyLinkedList<int> reversedSumLists(SinglyLinkedList<int> a, SinglyLinkedList<int> b)
         {
             SinglyLinkedList<int> result = new SinglyLinkedList<int>();
             Node<int> i = a.Head;
             int power = 0;
             int sum = 0;
             while (i != null)
             {
                 sum += i.getData() * (int)Math.Pow(10, power);
                 i = i.getNext();
                 power++;
             }

            i = b.Head;
            power = 0;

            while (i != null)
            {
                sum += i.getData() * (int)Math.Pow(10, power);
                i = i.getNext();
                power++;
            }

            while (sum > 0)
            {
                result.addLast(sum % 10);
                sum /= 10;
            }
            return result;
         }

         public static SinglyLinkedList<int> forwardSumLists(SinglyLinkedList<int> a, SinglyLinkedList<int> b)
         {
             SinglyLinkedList<int> result = new SinglyLinkedList<int>();
             Node<int> i = a.Head;
             int aLength = a.Size();
             int bLength = b.Size();
             int sum = 0;

             int power = aLength - 1;
             while (i != null)
             {
                 sum += i.getData() * (int)Math.Pow(10, power);
                 i = i.getNext();
                 power--;
             }

            i = b.Head;
            power = bLength - 1;

            while (i != null)
            {
                sum += i.getData() * (int)Math.Pow(10, power);
                i = i.getNext();
                power--;
            }

            while (sum > 0)
            {
                result.addFirst(sum % 10);
                sum /= 10;
            }
            return result;
         }

         /* P.95 (2.6) - Palindrome:
            Implement a function to check if a linked list is a palindrome.
         */

        public static bool palindrome(SinglyLinkedList<string> list)
        {
            SinglyLinkedList<string> stack = new SinglyLinkedList<string>();
            Node<string> i = list.Head;
            Node<string> j = list.Head;
            while(j != null && j.getNext() != null)
            {
                stack.addFirst(i.getData());
                i = i.getNext();
                j = j.getNext().getNext();
            }

            if (j != null) i.getNext();

            Node<string> k = stack.Head;
            while (i != null && k != null)
            {
                if (!i.getData().Equals(k.getData())) return false;
                i = i.getNext();
                k = k.getNext();
            }

            return true;
        }  

        // Etc. methods
        public static string returnString(SinglyLinkedList<string> list)
        {
            StringBuilder results = new StringBuilder("");
            
            for (Node<string> i = list.Head;i != null; i = i.getNext())
            {   
                results.Append(i.getData().ToString());
            }

            return results.ToString();
        } 
    }
}