using System;
using System.Collections.Generic;

namespace coding_challenges.DataStructures
{
    public class BreadthFirstPaths<E> where E : IComparable
    {
        private bool[] Marked;        // Is a shortest path to this vetex known?
        private E[] EdgeTo;           // Last vertex on known path to this vertex
        private readonly E Source;    // Source

        public BreadthFirstPaths(DirectedGraph<E> G, E s)
        {
            Marked = new bool[G.VerticesCount()];
            EdgeTo = new E[G.VerticesCount()];
            Source = s;
        }

        private void bfs(DirectedGraph<E> G, E s)
        {
            LinkedQueue<E> queue = new LinkedQueue<E>();
            // Marked[s] =
        }
    }
}