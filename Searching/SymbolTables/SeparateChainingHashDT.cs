using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.SymbolTables
{
    public class SeparateChainingHashDT<TKey,TValue> 
    {
        private int M; // size

        private SequentialSearchST<TKey, TValue>[] st;

        public SeparateChainingHashDT(int size)
        {
            this.M = size;
            st = new SequentialSearchST<TKey, TValue>[M];
            for (int i = 0; i < M; i++)
            {
                st[i] = new SequentialSearchST<TKey, TValue>();
            }
        }

        private int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % M;
        }

        public TValue Get(TKey key)
        {
            return st[Hash(key)].Get(key);
        }

        public void Set(TKey key, TValue value)
        {
            st[Hash(key)].Add(key,value);
        }

        public void Delete(TKey key)
        {
            st[Hash(key)].Delete(key);
        }

    }
}
