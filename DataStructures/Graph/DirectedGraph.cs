using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace coding_challenges.DataStructures
{
    public class DirectedGraph<E> : IGraph<E> where E : IComparable
    {
        private int Vertices;
        private int Edges;
        
        private Dictionary<E, SinglyLinkedList<E>> Adj;

        public DirectedGraph(int v = 100)
        {
            Vertices = v;
            Edges = 0;
            Adj = new Dictionary<E, SinglyLinkedList<E>>(Vertices);
        }

        // Add vertex to graph if it doesn't already exist
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
            if (Adj.ContainsKey(v)) Adj.Remove(v);
        }

        // Add edge from v to w
        // Runtime: O(1)
        public void AddEdge(E v, E w)
        {
            // Only adds vertices if they do not already exist in the graph
            AddVertex(v);
            AddVertex(w);

            Adj[v].AddLast(w);

            Edges++;
        }

        // Remove edge from v to w
        // Runtime: O(deg(v))
        
        public void RemoveEdge(E v, E w)
        {
            if (!Adj.ContainsKey(v)) return; // O(1)

            Adjacent(v).Remove(w);
        }

        // Return adjacency SinglyLinkedList of v
        // Runtime: O(1)
        public SinglyLinkedList<E> Adjacent(E v)
        {
            return Adj[v];
        }

        // Return in-degree of v
        // Runtime:

        // Return out-degree of v
        // Runtime: O(1)
        public int OutDegree(E v)
        {
            return Adjacent(v).Size();
        }

        // Return the degree of the vertex with most neighbors
        // Runtime: O(v)
        public int MaxDegree()
        {
            int max = 0;
            foreach (E key in Adj.Keys)
            {
                if (Adj[key].Size() > max) max = Adj[key].Size(); 
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
                    sb.Append(neighbor.GetData().ToString() + " ");
                }
                sb.Append("\n");
            }
            
            return sb.ToString();
        }        
    }
}