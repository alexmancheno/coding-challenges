using System;
using System.Text;

namespace coding_challenges
{

    public class SinglyLinkedList<E> 
    {
        public Node<E> Head = null;
        public Node<E> Tail = null;
        private int size = 0;

        public SinglyLinkedList() {}

        public int Size() { return size; }
        public bool isEmpty() { return size == 0; }

        public E first() { return Head.getData(); }

        //update methods
        public void addFirst(E e) {
            Head = new Node<E>(e, Head);
            if (size == 0)
                Tail = Head;

            size++;
        }

        public void addLast(E e) {
            Node<E> newLast = new Node<E>(e, null);
            if (size == 0)
                Head = newLast;
            else
                Tail.setNext(newLast);

            Tail = newLast;
            size++;
        }

        public E removeFirst() 
        {
            if (size == 0)
            {
                return default(E);
            } 
            else 
            {
                E temp = Head.getData();
                Head = Head.getNext();
                size--;

                if (size == 0) 
                {
                    Tail = null;
                }

                return temp;
            }
        }

        public void makeEmpty() 
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
                results.Append(iterator.getData());
                results.Append(" ");
                iterator = iterator.getNext();
            }

            return results.ToString();
        }

        public int countList() {
            Node<E> iterator = Head;
            int count = 0;

            while (iterator != null) {
                count++;
                iterator = iterator.getNext();
            }

            return count;
        }                
    }

}