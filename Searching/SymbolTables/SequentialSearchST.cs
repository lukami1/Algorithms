using System.Collections;

namespace Searching.SymbolTables
{
    public class SequentialSearchST<TKey, TValue> : IEnumerable<TKey>
    {
        Node first;
        int size;

        private class Node
        {
            public TKey key;
            public TValue value;
            public Node next;
            public Node(TKey key, TValue value)
            {
                this.key = key;
                this.value = value;
            }
        }

        public int Size()
        {
            return size;
        }
        public void Add(TKey key, TValue value)
        {
            for (Node x = first; x != null; x = x.next)
            {
                if (x.key.Equals(key))
                {
                    x.value = value;
                    return;
                }
            }
            var newNode = new Node(key, value);
            newNode.next = first;
            first = newNode;
            size++;
        }
        public void Delete(TKey key)
        {
            if (first == null)
                return;
            if (first.key.Equals(key))
            {
                first = first.next;
                return;
            }

            var prev = first;
            var current = prev.next;

            while (current != null)
            {
                if (current.key.Equals(key))
                {
                    prev.next = current.next;
                    size--;
                    return;
                }
                prev = current;
                current = current.next;
            }
        }

        public TValue Get(TKey key)
        {
            for (Node x = first; x != null; x = x.next)
            {
                if (x.key.Equals(key))
                {
                    return x.value;
                }
            }
            return default;
        }

        public IEnumerator<TKey> GetEnumerator()
        {
            return new SequentialSearchEnumerator(first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class SequentialSearchEnumerator : IEnumerator<TKey>
        {
            public SequentialSearchEnumerator(Node first)
            {
                current = first;
            }
            private Node current;
            public TKey Current => current.key;

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                //nothing to dispose
            }

            public bool MoveNext()
            {
                if (current == null) return false;
                current = current.next;
                return (current != null);
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
