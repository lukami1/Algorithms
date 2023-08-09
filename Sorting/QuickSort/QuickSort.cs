using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.QuickSort
{
    internal class QuickSort<T> : QuickSortBase<T> where T : IComparable<T>
    {
        protected override int Partition(T[] c, int lo, int hi)
        {
            int i = lo; int j = hi;
            var k = c[lo];
            while (true)
            {
                while (Less(c[i++], k)) if (i == hi) break; // scan left to right
                while (Less(c[j--], k)) if (j == lo) break; // scan right to left
                if (i >= j) break; // scan complete
                Swap(c, i, j);
            }
            Swap(c, lo, j);
            return j;
        }

        protected override void Sort(T[] c)
        {
            new Elementary.SchuffleSort<T>().Sort(c);
            Sort(c, 0, c.Length - 1);
        }

        private void Sort(T[] c, int lo, int hi)
        {
            if (lo >= hi) { return; }

            int j = Partition(c, lo, hi);
            Sort(c, lo, j - 1);
            Sort(c, j + 1, hi);
        }
    }
}
