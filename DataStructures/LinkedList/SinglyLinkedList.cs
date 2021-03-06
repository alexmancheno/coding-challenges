using System;
using System.Text;

namespace coding_challenges.DataStructures
{

    public class SinglyLinkedList<E> where E : IComparable
    {
        public Node<E> Head = null;
        public Node<E> Tail = null;
        private int size = 0;

        public SinglyLinkedList() {}

        public int Size() { return size; }
        public bool IsEmpty() { return size == 0; }

        public E First() { return Head.GetData(); }

        //update methods
        public void AddFirst(E e) 
        {
            Head = new Node<E>(e, Head);
            if (size == 0)
                Tail = Head;

            size++;
        }

        public void AddLast(E e) 
        {
            Node<E> newLast = new Node<E>(e, null);
            if (size == 0)
                Head = newLast;
            else
                Tail.SetNext(newLast);

            Tail = newLast;
            size++;
        }

        public E RemoveFirst() 
        {
            if (size == 0)
            {
                return default(E);
            } 
            else 
            {
                E temp = Head.GetData();
                Head = Head.GetNext();
                size--;

                if (size == 0) 
                {
                    Tail = null;
                }

                return temp;
            }
        }

        public bool Contains(E e)
        {
            for (Node<E> i = Head; i != null; i = i.GetNext())
            {
                if (i.GetData().Equals(e)) return true;
            }
            return false;
        }

        public void Remove(E e)
        {
            Node<E> prev = null;
            for (Node<E> i = Head; i != null; i = i.GetNext())
            {
                if (i.GetData().Equals(e))
                {
                    if (prev != null)
                    {
                        i = i.GetNext();
                        prev.SetNext(i);
                    }
                    else
                    {
                        i = i.GetNext();
                        Head = i;
                    }
                }
                else
                {
                    prev = i;
                    i = i.GetNext();
                }
            }
        }

        public void MakeEmpty() 
        {
            Head = null;
            size = 0;
        }

        //etc methods
        public override String ToString() 
        {
            StringBuilder results = new StringBuilder("");
            Node<E> iterator = Head;

            while (iterator != null) {
                results.Append(iterator.GetData());
                results.Append(" ");
                iterator = iterator.GetNext();
            }

            return results.ToString();
        }

        public int CountList() 
        {
            Node<E> iterator = Head;
            int count = 0;

            while (iterator != null) {
                count++;
                iterator = iterator.GetNext();
            }

            return count;
        }                
    }
}