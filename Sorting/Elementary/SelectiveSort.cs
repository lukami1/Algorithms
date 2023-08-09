using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Elementary
{
    class SelectiveSort<T> : SortBase<T> where T : IComparable<T>
    {
        public override void Sort(T[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                int min = i;
                for (int j = i; j < items.Length; j++)
                {
                    if (Less(items[j], items[min]))
                        min = j;
                }
                Exchange(items,i,min);
            }
        }

        public override void Sort(T[] items, IComparer<T>? comparer)
        {
            base.comparer = comparer;
            Sort(items);
        }
    }
}
