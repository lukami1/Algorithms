using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.MergeSort
{
    public abstract class MergeSortBase<T> where T : IComparable<T>
    {
        protected IComparer<T>? comparer;
        protected T[] copy;
        public abstract void Sort(T[] a);
        public abstract void Sort(T[] a, IComparer<T>? comparer);

        public bool Less(T a, T b)
        {
            if(comparer != null)
                return comparer.Compare(a, b) < 0;
            return a.CompareTo(b) < 0;
        }

        public void Swap(T[] i, int a, int b)
        {
            var swap = i[a];
            i[a] = i[b];
            i[b] = swap;
        }

        public void Merge(T[] a, int lo, int mid, int hi)
        {
            int i = lo;
            int j = mid + 1;
            Array.Copy(a, copy, copy.Length);

            for(int k =lo; k <= hi; k++)
            {
                if (i > mid) a[k] = copy[j++];
                else if (j > hi) a[k] = copy[i++];
                else if (Less(copy[j], copy[i])) a[k] = copy[j++];
                else a[k] = copy[i++];
            }
        }
    }
}
