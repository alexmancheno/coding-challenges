using System;
using System.Text;
using System.Collections.Generic;

namespace coding_challenges.DataStructures
{
    public class Graph<E> where E : IComparable
    {
        private int Vertices;
        private int Edges;
        
        private Dictionary<E, List<E>> Adj;

        public Graph(int v = 100)
        {
            Vertices = v;
            Edges = 0;
            Adj = new Dictionary<E, List<E>>(Vertices);
        }

        // Add vertex to graph
        public void AddVertex(E v)
        {
            if (Adj[v] == null)
            {
                Adj[v] = new List<E>();
            }
        }

        // Add edge from v to w
        public void AddEdge(E v, E w)
        {
            AddVertex(v);
            AddVertex(w);

            if (!Adjacent(v).Contains(w)) Adjacent(v).Add(w);
            Edges++;
        }

        // Remove edge from v to w
        public void RemoveEdge(E v, E w)
        {
            if (!Adj.ContainsKey(v) || !Adj.ContainsKey(w)) return;

            Adjacent(v).Remove(w);
        }

        // Return adjacency list of v
        public List<E> Adjacent(E v)
        {
            return Adj[v];
        }

        // Return degree of v
        public int Degree(E v)
        {
            return Adjacent(v).Count;
        }

        // Return the degree of the vertext with most neighbors
        public int MaxDegree()
        {
            int max = -1;
            foreach (E key in Adj.Keys)
            {
                if (Adj[key].Count > max) max = Adj[key].Count; 
            }
            return max;
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