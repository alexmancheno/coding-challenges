using System;
using System.Text;
using System.Collections.Generic;

namespace coding_challenges.DataStructures
{
    public class UndirectedGraph<E> : IGraph<E> where E : IComparable 
    {
        private int Vertices;
        private int Edges;
        
        private Dictionary<E, SinglyLinkedList<E>> Adj;

        public UndirectedGraph(int v = 100)
        {
            Vertices = v;
            Edges = 0;
            Adj = new Dictionary<E, SinglyLinkedList<E>>(Vertices);
        }

        // Add vertex to graph
        // Runtime: O(1)
        public void AddVertex(E v)
        {
            if (!Adj.ContainsKey(v))
            {
                Adj[v] = new SinglyLinkedList<E>();
                Vertices++;
            }
        }

        public void RemoveVertex(E v)
        {

        }

        // Add edge from v to w
        // Runtime: O(1)
        public void AddEdge(E v, E w)
        {
            AddVertex(v);
            AddVertex(w);

            Edges++;
        }

        // Remove edge from v to w
        // Runtime: O(n)
        
        public void RemoveEdge(E v, E w)
        {
            if (v.Equals(w)) 
                Adj[v].Remove(v);   // Remove loop
            else
            {
                Adj[v].Remove(w);   
                Adj[w].Remove(v);
            }
        }

        // Return adjacency list of v
        // Runtime: O(1)
        public SinglyLinkedList<E> Adjacent(E v)
        {
            return Adj[v];
        }

        // Return the reverse of the digraph; useful to find edges that point to a vertex,
        // whereas Adjacent() gives just the vertices connected by edges that point from
        // each vertex.
        // Runtime: O(?)
        public DirectedGraph<E> Reverse()
        {
            DirectedGraph<E> Reversed = new DirectedGraph<E>(Vertices);
            foreach (E vertex in Adj.Keys)
            {
                for (Node<E> neighbor = Adj[vertex].Head; neighbor != null; neighbor = neighbor.GetNext())
                {
                    Reversed.AddEdge(neighbor.GetData(), vertex);
                }
            }
            return Reversed;
        }

        // Return degree of v
        // Runtime: O(1)
        public int Degree(E v)
        {
            return Adjacent(v).Size();
        }

        // Return the degree of the vertex with most neighbors
        // Runtime: O(n)
        public int MaxDegree()
        {
            int max = 0;
            foreach (E vertex in Adj.Keys)
            {
                if (Adjacent(vertex).Size() > max) max = Adjacent(vertex).Size(); 
            }
            return max;
        }

        // Return the number of vertices in the graph
        // Runtime: O(1)
        public int VerticesCount()
        {
            return Vertices;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (E vertex in Adj.Keys)
            {
                sb.Append($"{vertex.ToString()}: ");
                for (Node<E> neighbor = Adj[vertex].Head; neighbor != null; neighbor = neighbor.GetNext())
                {
                    sb.Append(neighbor.GetData().ToString());
                }
                sb.Append("\n");
            }
            
            return sb.ToString();
        }
    }
}