using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Searching.SymbolTables
{
    internal class LinearProbingHashST<TKey, TValue>
    {
        private int N;
        private int M = 16;
        private TKey[] keys;
        private TValue[] values;
        public LinearProbingHashST()
        {
            keys = new TKey[M];
            values = new TValue[M];
        }
        private int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % M;
        }

        public void Add(TKey key, TValue value)
        {
            //if N >= M/2 => resize(2*M)
            int i;
            for (i = Hash(key); keys[i] != null; i = (i + 1) % M)
            {
                if (keys[i].Equals(key)) { values[i] = value; }
            }
            keys[i] = key;
            values[i] = value;
        }

        public TValue? Get(TKey key)
        {
            for(int i = Hash(key); keys[i] !=null; i = (i + 1) % M)
            {
                if (keys[i].Equals(key)) { return values[i]; }
            }
            return default;
        }
    }
}
