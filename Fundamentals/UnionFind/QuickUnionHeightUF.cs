using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.UnionFind
{
    internal class QuickUnionHeightUF
    {
        int[] items;
        int[] height;
        public QuickUnionHeightUF(int N)
        {
            items = new int[N];
            height = new int[N];
            for (int i = 0; i < N; i++)
            {
                items[i] = i;
                height[i] = 1;
            }
        }
        public int Find(int p)
        {
            var h = 0;
            while (items[p] != p)
            {   
                h++;
                p = items[p];
            }
            height[p] = Math.Max(h,height[p]);
            return p;
        }
        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public void Union(int p , int q)
        {
            var pId  = Find(p);
            var qId = Find(q);
            if (qId == pId)
                return;
            if (height[pId] < height[qId])
            {
                items[pId] = qId;
            }
            else
            {
                items[qId] = pId;
            }
        }
    }
}
