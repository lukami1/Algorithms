using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.QuickSort
{
    abstract class QuickSortBase<T> where T : IComparable<T>
    {
        protected abstract void Sort(T[] c);

        protected abstract int Partition(T[] c, int lo, int hi);

        protected bool Less(T a, T b)
        {
            return a.CompareTo(b) < 0;
        }

        protected void Swap(T[] c, int p, int q)
        {
            var swap = c[p];
            c[p] = c[q];
            c[q] = swap;
        }
    }
}
