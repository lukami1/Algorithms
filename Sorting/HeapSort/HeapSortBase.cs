using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.HeapSort
{
    abstract class HeapSortBase<T> where T : IComparable<T>
    {
        protected void Swim(T[] a, int k)
        {
            int j = k;
            while (j > 1 && !Less(a, j, j/2))
            {
                Swap(a, j,j/2);
                j = j/2;
            }
        }

        protected void Sink(T[] a, int k)
        {
            int j = k;
            j = j * 2;
            while (j <= a.Length)
            {
                if (j<a.Length && Less(a, j, j + 1)) j++;
                if (Less(a, j, j / 2)) break;
                Swap(a, j, j / 2);
                j *= 2;
            }
        }

        protected bool Less(T[] a, int i, int j)
        {
            return a[i].CompareTo(a[j]) < 0;
        }

        protected void Swap(T[] a, int i, int j)
        {
            var swap = a[i]; a[i] = a[j]; a[j] = swap;
        }





    }
}
