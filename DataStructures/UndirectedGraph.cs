using System;
using System.Text;
using System.Collections.Generic;

namespace coding_challenges.DataStructures
{
    public class UndirectedGraph<E> : Graph<E> where E : IComparable 
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

        // Add edge from v to w
        // Runtime: O(n); not good enough
        public void AddEdge(E v, E w)
        {
            AddVertex(v);
            AddVertex(w);

            // if (!Adjacent(v).Contains(w)) Adjacent(v).Add(w);
            Edges++;
        }

        // Remove edge from v to w
        // Runtime: O(4n) -> O(n); baddd
        
        public void RemoveEdge(E v, E w)
        {
            if (!Adj.ContainsKey(v) || !Adj.ContainsKey(w)) return;

            if (v.Equals(w))
            {
                
            }
            // Adjacent(v).Remove(w);
            // Adjacent(w).Remove(v);
        }

        // Return adjacency SinglyLinkedList of v
        // Runtime: O(1)
        public SinglyLinkedList<E> Adjacent(E v)
        {
            return Adj[v];
        }

        // Return degree of v
        // Runtime: O(1)
        public int Degree(E v)
        {
            return Adjacent(v).Count;
        }

        // Return the degree of the vertext with most neighbors
        // Runtime: O(n)
        public int MaxDegree()
        {
            int max = -1;
            foreach (E key in Adj.Keys)
            {
                if (Adj[key].Count > max) max = Adj[key].Count; 
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
                foreach (E neighbor in Adj[vertex])
                {
                    sb.Append(neighbor.ToString());
                }
                sb.Append("\n");
            }
            
            return sb.ToString();
        }
    }
}