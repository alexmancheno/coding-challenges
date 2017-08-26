using System;

namespace coding_challenges.DataStructures
{
    public class LinkedStack<E> : Stack<E> where E : IComparable
    {

        private SinglyLinkedList<E> list = new SinglyLinkedList<E>();

        public LinkedStack() {}

        public int Size() 
        {
            return list.Size();
        }

        public bool IsEmpty() 
        {
            return list.IsEmpty();
        }

        public void Push(E element) 
        {
            list.AddFirst(element);
        }

        public E Top() 
        {
            return list.First();
        }

        public E Pop() 
        {
            return list.RemoveFirst();
        }
    }
}