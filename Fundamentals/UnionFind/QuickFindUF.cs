using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.UnionFind
{
    internal class QuickFindUF
    {
        int[] items;
        public QuickFindUF(int N)
        {
            items = new int[N];
            for (int i = 0; i < N; i++)
            {
                items[i] = i;
            }
        }

        private int count;
        public int Count()
        {
            return count;
        }
        public int Find(int p)
        {
            return items[p];
        }
        public void Union(int p, int q)
        {
            int pId = items[p];
            int qId = items[q];
            if (pId == qId) return;
            for(int i =0; i < items.Length; i++)
            {
                if (items[i] == pId)
                    items[i] = qId;
            }
        }

        public bool Connected(int p, int q)
        {
            return items[p] == items[q];
        }
    }
}
