using System;

namespace coding_challenges.DataStructures
{
    public interface Stack <E>
    {
        int Size ();

        bool IsEmpty();

        void Push(E e);

        E Top();

        E Pop();
        
    }    
}