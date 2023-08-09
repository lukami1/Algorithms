using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Elementary
{
    class InsertionSort<T> : SortBase<T> where T : IComparable<T>
    {
        public override void Sort(T[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                for (int j=i;j>0 && Less(items[j], items[j-1]); j--) 
                {
                    Exchange(items,j,j-1);
                }   

            }
        }

        public override void Sort(T[] items, IComparer<T>? comparer)
        {
            base.comparer = comparer;
            Sort(items);
        }
    }
}
