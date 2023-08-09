using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Elementary
{
    abstract class SortBase<T> where T : IComparable<T>
    {
        protected IComparer<T>? comparer;
        protected void Exchange(T[] items, int a, int b)
        {
            var swap = items[a];
            items[a] = items[b];
            items[b] = swap;
        }

        protected bool IsSorted(T[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (!Less(items[i], items[i + 1]))
                    return false;
            }
            return true;
        }

        public bool Less(T a, T b)
        {
            if (comparer != null)
                return comparer.Compare(a, b) < 0;
            return a.CompareTo(b) < 0;
        }
        public abstract void Sort(T[] items);
        public abstract void Sort(T[] items, IComparer<T>? comparer);
    }
}
