using System;
using System.Collections;
using System.Collections.Generic;
using coding_challenges.DataStructures;

namespace coding_challenges
{
    public class TreesAndGraphs
    {
        /*  P. 109 (4.1) - Route Between Nodes:
            Given a directed graph, design an algorithm to find out where there is
            a route between two nodes.
         */
        public static bool routeBetweenNodes(DirectedGraph<string> graph, string a, string b)
        {
            HashSet<string> visited = new HashSet<string>();
            dfs(graph, visited, a, b);
            return visited.Contains(b);
        }

        // Dept first search 
        public static void dfs(DirectedGraph<string> graph, HashSet<string> visited, string a, string b)
        {
            visited.Add(a);
            Console.WriteLine("Visited: " + a);

            for (Node<string> neighbor = graph.Adjacent(a).Head; neighbor != null; neighbor = neighbor.GetNext())
            {
                Console.WriteLine("Neighbhor: " + neighbor.GetData());

                if (!visited.Contains(neighbor.GetData()))
                {
                    visited.Add(neighbor.GetData());
                    dfs(graph, visited, neighbor.GetData(), b);
                }
            }
        }

        /* P. 109 (4.2) - Minimal Tree:
            Given a sorted (increasing order) array with unique integer elements, write an algorithm
            to create a binary search tree with minimal height.
         */
        public static BinarySearchTree<int, int> minimalTree(int[] a)
        {

        }
    }
}