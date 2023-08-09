using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fundamentals.UnionFind
{

    /*
        algorithm                           worst-case time
    -------------------------------------------------------------
        quick-find                                M N
        quick-union                               M N
        weighted QU                            N + M log N
        QU + path compression                  N + M log N
        weighted QU + path compression         N + M lg* N
    -------------------------------------------------------------
     M union-find operations on a set of N objects
     
     */
    internal class QuickUnionUF
    {
        int[] items;
        public QuickUnionUF(int N)
        {
            items = new int[N];
            for (int i = 0; i < N; i++)
            {
                items[i] = i;
            }
        }

        private int Root(int i)
        {
            while (i != items[i])
            {
                i = items[i];
            }
            return i;
        }

        public void Union(int p, int q)
        {
            int i = Root(p);
            int j = Root(q);
            items[i] = j;
        }
        public bool Connected(int p, int q)
        {
            return Root(p) == Root(q);
        }
    }

    //    union O(lgN) connected O(lgN)

    //Weighted union find
    internal class QuickUnionUFImproved
    {
        int[] items;
        int[] size;
        public QuickUnionUFImproved(int N)
        {
            items = new int[N];
            size = new int[N];
            for (int i = 0; i < N; i++)
            {
                items[i] = i;
                size[i] = 1;
            }
        }

        private int Root(int i)
        {
            while (i != items[i])
            {
                i = items[i];
            }
            return i;
        }

        public void Union(int p, int q)
        {
            int i = Root(p);
            int j = Root(q);

            //Keep track of size of the tree, and merge only smaller tree to bigger tree.
            if (i == j)
                return;
            if (size[i] < size[j]) { items[i] = j; size[j] += size[i]; }
            else { items[j] = i; size[i] += size[j]; }
        }
        public bool Connected(int p, int q)
        {
            return Root(p) == Root(q);
        }
    }

    //    union ~O(1) connected ~O(1)

    //Weighted union find with path compression
    public class QuickUnionUFImprovedI
    {
        int[] items;
        int[] maxElement;
        int[] size;
        public QuickUnionUFImprovedI(int N)
        {
            items = new int[N];
            maxElement = new int[N];
            size = new int[N];
            for (int i = 0; i < N; i++)
            {
                size[i] = 1;
                items[i] = i;
                maxElement[i] = i;

            }
        }
        public int Find(int p)
        {
            return maxElement[Root(p)];
        }
        private int Root(int i)
        {
            while (i != items[i])
            {
                //Flatten the tree, make each item point to grandparent
                items[i] = items[items[i]];
                i = items[i];
            }
            return i;
        }

        public void Union(int p, int q)
        {
            int i = Root(p);
            int j = Root(q);

            //Keep track of size of the tree, and merge only smaller tree to bigger tree.
            if (i == j)
                return;
            var max = Math.Max(p, q);
            if (size[i] < size[j])
            {
                items[i] = j;
                size[j] += size[i];
                maxElement[j] = Math.Max(maxElement[j],max);
            }
            else
            {
                items[j] = i;
                size[i] += size[j];
                maxElement[i] = Math.Max(maxElement[i], max);
            }
        }

        public bool Connected(int p, int q)
        {
            return Root(p) == Root(q);
        }
    }
}
