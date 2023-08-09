using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Elementary
{
    internal class SchuffleSort<T> : SortBase<T> where T : IComparable<T>
    {
        public override void Sort(T[] items)
        {
            Random random = new Random();
            for (int i = 0; i < items.Length; i++)
            {
                var rnd = random.Next(0, i);
                if (Less(items[i], items[rnd]))
                    Exchange(items, rnd, i);
            }
        }

        public override void Sort(T[] items, IComparer<T>? comparer)
        {
            base.comparer = comparer;
            Sort(items);
        }
    }
}
