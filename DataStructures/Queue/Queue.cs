using System;

namespace coding_challenges.DataStructures
{
    public interface Queue<E> 
    {
        int Size();

        bool IsEmpty();

        void Enqueue(E e);
    
        E Dequeue();
    }
}