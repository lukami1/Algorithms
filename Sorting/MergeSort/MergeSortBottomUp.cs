using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.MergeSort
{
    internal class MergeSortBottomUp<T> : MergeSortBase<T> where T : IComparable<T>
    {
        public override void Sort(T[] a)
        {
            base.copy = new T[a.Length];

            for (int h = 1; h < a.Length; h = h+h)
            {
                for (int i = 0; i < a.Length-h; i+=h+h)
                {
                    Merge(a, i, i + h - 1, Math.Min(i + h + h - 1, a.Length - 1));
                }
            }

        }

        public override void Sort(T[] a, IComparer<T>? comparer)
        {
            base.comparer = comparer;
            Sort(a);
        }
    }
}
