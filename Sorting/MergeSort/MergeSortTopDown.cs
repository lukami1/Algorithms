using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.MergeSort
{
    public class MergeSortTopDown<T> : MergeSortBase<T> where T : IComparable<T>
    {
        public override void Sort(T[] a)
        {
            base.copy = new T[a.Length];
            int lo = 0;
            int hi = a.Length - 1;
            Sort(a, lo, hi);
        }

        public override void Sort(T[] a, IComparer<T>? comparer)
        {
            base.comparer = comparer;
            Sort(a);
        }

        private void Sort(T[] a, int lo, int hi)
        {
            int mid = lo + (hi - lo) / 2;
            if (lo >= hi)
                return;
            Sort(a, lo, mid); // sort left
            Sort(a, mid + 1, hi); // sort right
            Merge(a, lo, mid, hi); // merge left and right
        }
    }
}
