using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals
{
    public class RecursiveBinarySearch
    {

        public static int IndexOf(int[] array, int n)
        {
            return IndexOf(array, n, 0, array.Length - 1);
        }

        private static int IndexOf(int[] array, int n, int lo, int hi)
        {
            if (lo > hi)
                return -1;
            int mid = lo + (hi - lo) / 2;

            if (n > array[mid])
            {
                return IndexOf(array, n, mid + 1, hi);
            }
            else if (n < array[mid])
            {
                return IndexOf(array, n, lo, mid - 1);
            }
            else
            {
                return mid;
            }
        }
    }
}
