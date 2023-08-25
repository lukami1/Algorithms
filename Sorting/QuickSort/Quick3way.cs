using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.QuickSort
{
    internal class Quick3way<T> : QuickSortBase<T> where T : IComparable<T>
    {
        protected override int Partition(T[] c, int lo, int hi)
        {
            throw new NotImplementedException();
        }

        protected override void Sort(T[] c)
        {
            new Elementary.SchuffleSort<T>().Sort(c);
            Sort(c, 0, c.Length - 1);
        }

        private void Sort(T[] c, int lo, int hi)
        {
            if (hi <= lo) return;
            int lt = lo; int i = lo + 1; int gt = hi;
            var v = c[lo];
            while (i <= gt)
            {
                int cmp = c[i].CompareTo(v);
                if (cmp < 0) Swap(c, i++, lt++);
                else if (cmp > 0) Swap(c, i, gt--);
                else i++;
            }
            // now a[lo..lt-1] < v = a[lt..gt] < a[gt+1 .. hi]
            //sort left and right side since we know middle is sorted by v
            Sort(c, lo, lt-1);
            Sort(c, gt+1, hi);
        }



        //Select kth smallest element
        public T Select(T[] c, int k)
        {
            int lo = 0; int hi = c.Length - 1;

            while (lo < hi)
            {
                int j = Partition(c, lo, hi);
                if (k < j) { hi = j - 1; }
                else if (k > j) { hi = j + 1; }
                else return c[k];
            }
            return c[k];
        }
    }
}
