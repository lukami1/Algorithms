using System;
using System.Collections.Generic;
using System.Drawing;
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
            if (i < N && key.CompareTo(_keys[i]) == 0)
            {
                _values[i] = value;
            }
            for (int j = N; j > i; j--)
            {
                _keys[j] = _keys[j - 1];
                _values[j] = _values[j - 1];
            }
            _keys[i] = key;
            _values[i] = value;
            N++;
        }

        public TKey Ceiling(TKey key)
        {
            return _keys[Rank(key)];
        }

        public bool Contains(TKey key)
        {
            return _keys[Rank(key)] != null;
        }

        public int Count()
        {
            return N;
        }

        public int Count(TKey lo, TKey hi)
        {
            var hiRank = Rank(hi);
            var loRank = Rank(lo);
            return hiRank - loRank;
        }

        public void Delete(TKey key)
        {
            int i = Rank(key);
            for(int j = i; j < N-1; j++)
            {
                _keys[j] = _keys[j+1];
                _values[j] = _values[j+1];
            }
            N--;
        }

        public void DeleteMax()
        {
            _keys[N - 1] = default;
            _values[N - 1] = default;
            N--;
        }

        public void DeleteMin()
        {
            for (int i = 0; i < N - 1; i++)
            {
                _keys[i] = _keys[i + 1];
                _values[i] = _values[i + 1];
            }
            N--;
        }

        public TKey Floor(TKey key)
        {
            return _keys[Rank(key)-1];
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
            Queue<TKey> queue = new Queue<TKey>();
            if(lo.CompareTo(hi)>0) return queue;
            for(int i = Rank(lo); i< Rank(hi); i++) { queue.Enqueue(_keys[i]); }
            if(Contains(hi)) queue.Enqueue(_keys[Rank(hi)]);
            return queue;
        }

        public IEnumerable<TKey> Keys()
        {
            return Keys(_keys[0], _keys[N - 1]);
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
            int hi = N - 1;
            int lo = 0;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int c = key.CompareTo(_keys[mid]);
                if (c < 0) { hi = mid - 1; }
                else if (c > 0) { lo = mid + 1; }
                else { return mid; }
            }
            return lo;
        }

        public TKey Select(int k)
        {
            return _keys[k];
        }
    }
}
