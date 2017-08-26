using System;
using System.Collections.Generic;

namespace coding_challenges.DataStructures
{
    public interface IGraph<E> where E : IComparable
    {
        void AddVertex(E v);

        void RemoveVertex(E v);

        void AddEdge(E v, E W);
        
        void RemoveEdge(E v, E w);

        SinglyLinkedList<E> Adjacent(E v);

        int MaxDegree();

        int VerticesCount();
    }
}