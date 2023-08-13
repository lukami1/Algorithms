using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.SymbolTables
{
    internal class BinarySearchST<TKey, TValue> : ISymbolTable<TKey, TValue> where TKey : IComparable<TKey>
    {
        private TKey[] _keys;
        private TValue[] _values;
        private int N;

        public BinarySearchST(int capacity)
        {
            _keys = new TKey[capacity];
            _values = new TValue[capacity];
        }
        public void Add(TKey key, TValue value)
        {
            int i = Rank(key);
            if(i<N && key.CompareTo(_keys[i]) == 0)
            {
                _values[i] = value;

            }

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
            return N;
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
            if (IsEmpty()) return default;
            var rank = Rank(key);

            if (rank < N && key.CompareTo(_keys[rank]) == 0) return _values[rank];
            else return default;
        }

        public bool IsEmpty()
        {
            return N == 0;
        }

        public IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TKey> Keys()
        {
            throw new NotImplementedException();
        }

        public TKey Max()
        {
            return _keys[N];
        }

        public TKey Min()
        {
            return _keys[0];
        }

        public int Rank(TKey key)
        {
            throw new NotImplementedException();
        }

        public TKey Select(int k)
        {
            throw new NotImplementedException();
        }
    }
}
