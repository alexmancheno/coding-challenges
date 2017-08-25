using System;
using System.Collections.Generic;

namespace coding_challenges.DataStructures
{
    public interface Graph<E>
    {
        void AddVertex(E v);

        void AddEdge(E v, E W);
        
        void RemoveEdge(E v, E w);

        List<E> Adjacent(E v);

        int MaxDegree();

        int VerticesCount();
    }
}