using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Elementary
{
    internal class SchellSort<T> : SortBase<T> where T : IComparable<T>
    {
        public override void Sort(T[] items)
        {
            int h = 0;
            while (h <= items.Length / 3)
            {
                h = h * 3 + 1;
            }
            while (h >= 1)
            {
                for(int i =h; i < items.Length; i++)
                    for(int j = i; j >= h && Less(items[j], items[j-h]); j-=h)
                        Exchange(items, j, j-h);

                h = h / 3;
            }
        }

        public override void Sort(T[] items, IComparer<T>? comparer)
        {
            base.comparer = comparer;
            Sort(items);
        }
    }
}
