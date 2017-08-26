using System;
using System.Collections;
using System.Collections.Generic;

namespace coding_challenges.DataStructures
{
    public class BinarySearchTree<K, V> where K : IComparable<K>
    {
        private Node Root;
        private class Node
        {
            public K Key { get; }
            public V Value { get; set; }
            public Node Left, Right;
            public int N { get; set; }

            public Node(K key, V val, int n)
            {
                Key = key; Value = val; N = n;
            }
        }

        public int Size() { return Root.N; }

        public V Get(K key) 
        {
            return Get(Root, key);
        }

        private V Get(Node x, K key)
        {
            // Return value associated with key in the subtree Rooted at x
            // Return null if key is not present in subtree Rooted at x
            if (x == null) return default(V);
            int compare = key.CompareTo(x.Key);
            if (compare < 0) return Get(x.Left, key);
            else if (compare > 0) return Get(x.Right, key);
            else return x.Value;
        }

        public void Insert(K key, V val)
        {
            // Search for key. Update valie if found, grow table if new
            Root = Insert(Root, key, val);
        }

        private Node Insert(Node x, K key, V val)
        {
            // Change key's value to val if key is in subtree rooted at x
            // Otherwise, add new node to subtree associating key with val
            if (x == null) return new Node(key, val, 1);
            int compare = key.CompareTo(x.Key);
            if (compare < 0)        x.Left = Insert(x.Left, key, val);
            else if (compare > 0)   x.Right = Insert(x.Right, key, val);
            else                    x.Value = val;
            x.N = x.Left.N + x.Right.N + 1;
            return x;
        }
    }
}