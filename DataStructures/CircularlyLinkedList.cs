using System;
using System.Text;

namespace coding_challenges.DataStructures
{
    public class CircularlyLinkedList<E>
    {
        private Node<E> Tail = null;
        private int size = 0;

        public CircularlyLinkedList() {}

        //access methods
        public int Size() { return size; }

        public bool IsEmpty() { return size == 0; }

        public E First() 
        {
            if (IsEmpty())
                return default(E);
            return Tail.GetNext().GetData();
        }

        public E Last() 
        {
            if (IsEmpty())
                return default(E);
            return Tail.GetData();
        }

        //update methods
        public void Rotate() 
        {
            if (Tail != null)
                Tail = Tail.GetNext();
        }

        public void AddFirst(E e) 
        {
            if (size == 0) {
                Tail = new Node<E>(e, null);
                Tail.SetNext(Tail);
            } else {
                Node<E> newest = new Node<E>(e, Tail.GetNext());
                Tail.SetNext(newest);
            }
            size++;
        }

        public void addLast(E e)
        {
            AddFirst(e);
            Tail = Tail.GetNext(); //Tail becomes head
        }

    //    public void RemoveFirst() {
    //        if (size > 1) {
    //            Tail.next = Tail.next.GetNext();
    //            size--;
    //        } else if (size == 1) {
    //            Tail.next = null;
    //            size--;
    //        }
    //    }

        public E RemoveFirst() 
        {
            if (IsEmpty()) return default(E);
            Node<E> head = Tail.GetNext();

            if (head == Tail) {
                Tail.SetNext(null);
                Tail = null;
            } else {
                Tail.SetNext(Tail.GetNext().GetNext());
            }
            size--;
            return head.GetData();
        }

        //etc. methods
        public override String ToString() 
        {
            StringBuilder results = new StringBuilder("");

            if (Tail != null) {
                Node<E> iterator = Tail.GetNext();
                for (int i = 0; i < size; i++) {
                    results.Append(iterator.GetData());
                    results.Append(" ");
                    iterator = iterator.GetNext();
                }
            }

            return results.ToString();
        }

        public int CountList() 
        {
            int count = 0;
            if (Tail != null) {

                Node<E> iterator = Tail.GetNext();

                do {
                    count++;
                    iterator = iterator.GetNext();
                } while (iterator != Tail.GetNext());
            }

            return count;
        }

        public void MakeEmpty() {
            Tail.SetNext(null);
            Tail = null;
            size = 0;
        }

        public E GetTail() 
        {
            return Tail.GetData();
        }        
    }
}