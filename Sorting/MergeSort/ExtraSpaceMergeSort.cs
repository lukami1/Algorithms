using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.MergeSort
{
    internal class ExtraSpaceMergeSort<T> : MergeSortBase<T> where T : IComparable<T>
    {
        public override void Sort(T[] a)
        {
            base.copy = new T[a.Length];
            int M = a.Length / 2;

            for (int i = 0; i < a.Length; i+=M)
            {
                
                for(int j =i; j < i + M + 1 && j<a.Length; j++)
                {
                    var min = j;

                    for (int k =j+1;k < i+M+1 && k<a.Length; k++)
                    {
                        if (Less(a[k], a[min]))
                            min = k;
                    }
                    Swap(a,j, min);
                }
                if (i > 0)
                    Merge(a, 0, i + (M - i) / 2 , Math.Min(i + M -1, a.Length-1));
            }
        }

        public override void Sort(T[] a, IComparer<T>? comparer)
        {
            base.comparer = comparer;
            Sort(a);
        }
    }
}
