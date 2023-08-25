using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.SymbolTables
{
    internal class BinarySearchTree<TKey, TValue> : ISymbolTable<TKey, TValue> where TKey : IComparable<TKey>
    {
        private Node root;
        private class Node
        {
            public TKey Key;
            public TValue Value;
            public Node left, right;
            public int N;
            public Node(TKey key, TValue value, int count)
            {
                this.Key = key;
                this.Value = value;
                this.N = count;
            }
        }
        public void Add(TKey key, TValue value)
        {
            root = Add(root, key, value);
        }
        private Node Add(Node node, TKey key, TValue value)
        {
            if (node == null) return new Node(key, value, 1);
            var cmp = key.CompareTo(node.Key);
            if (cmp > 0) node.right = Add(node.right, key, value);
            else if (cmp < 0) node.left = Add(node.left, key, value);
            else node.Value = value;
            node.N = Count(node.left) + Count(node.right) + 1;
            return node;
        }

        public TKey Ceiling(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Contains(TKey key)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            return Count(root);
        }
        private int Count(Node x)
        {
            if (x == null) return 0;
            return x.N;
        }

        public int Count(TKey lo, TKey hi)
        {
            throw new NotImplementedException();
        }

        public void Delete(TKey key)
        {
            throw new NotImplementedException();
        }

        public void DeleteMax()
        {
            throw new NotImplementedException();
        }

        public void DeleteMin()
        {
            throw new NotImplementedException();
        }

        public TKey Floor(TKey key)
        {
            throw new NotImplementedException();
        }

        public TValue GetValue(TKey key)
        {
            return GetValue(root, key);
        }

        private TValue GetValue(Node node, TKey key)
        {
            if (node == null) return default;
            var cmp = key.CompareTo(node.Key);
            if (cmp > 0) return GetValue(node.right, key);
            else if (cmp < 0) return GetValue(node.left, key);
            else return node.Value;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        private void Keys(Queue<TKey> queue, Node node, TKey lo, TKey hi)
        {
            if(node == null) return;
            var locmp = lo.CompareTo(node.Key);
            var hicmp = hi.CompareTo(node.Key);

            if(locmp < 0) Keys(queue, node.left, lo, hi);
            if(hicmp <= 0 && hicmp >= 0 ) queue.Enqueue(node.Key);
            if(hicmp > 0) Keys(queue, node.right, lo, hi);

        }
        public IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            Queue<TKey> queue = new Queue<TKey>();
            Keys(queue, root, lo, hi);
            return queue;
        }

        public IEnumerable<TKey> Keys()
        {
            return Keys(Min(), Max());
        }

        public TKey Max()
        {
            return Max(root).Key;
        }
        private Node Max(Node node)
        {
            if (node.right == null) return node;
            return Max(node.right);
        }

        public TKey Min()
        {
            return Min(root).Key;
        }
        private Node Min(Node node)
        {
            if (node.left == null) return node;
            return Min(node.left);
        }

        public int Rank(TKey key)
        {
            return Rank(root, key);
        }

        private int Rank(Node node, TKey key)
        {
            if (node == null) return 0;
            var cmp = key.CompareTo(root.Key);
            if (cmp < 0) return Rank(node.left, key);
            else if (cmp > 0) return 1 + Count(node.left) + Rank(node.right, key);
            return Count(node.left);
        }

        public TKey Select(int k)
        {
            return Select(root, k).Key;
        }

        private Node Select(Node node, int k)
        {
            if (node == null) return null;
            int t = Count(node.left);
            if (t > k) return Select(node.left, k);
            else if (t < k) return Select(node.right, k - t - 1);
            else return node;
        }
    }
}
