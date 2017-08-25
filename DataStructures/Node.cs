using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace coding_challenges.DataStructures
{
    public class Node<E> where E : IComparable
    {
        private E Data;
        private Node<E> Next;
        public Node(E e, Node<E> n) 
        {
            Data = e;
            Next = n;
        }

        public E GetData() { return Data; }

        public Node<E> GetNext() { return Next; }

        public void SetNext(Node<E> n) { Next = n; }

        public override string ToString() { return Data.ToString(); }
    }
    
}