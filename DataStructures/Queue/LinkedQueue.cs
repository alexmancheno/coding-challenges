using System;

namespace coding_challenges.DataStructures
{
    public class LinkedQueue<E> : Queue<E> where E : IComparable
    {
        private SinglyLinkedList<E> list = new SinglyLinkedList<E>();
        public LinkedQueue(){}

        public int Size() 
        {
            return list.Size();
        }

        public bool IsEmpty() 
        {
            return list.IsEmpty();
        }

        public void Enqueue(E element) 
        {
            list.AddLast(element);
        }

        public E First() 
        {
            return list.First();
        }

        public E Dequeue() 
        {
            return list.RemoveFirst();
        }
    }
}