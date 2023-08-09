﻿namespace Sorting.Helpers.CustomComparers
{
    public class DescendingIntegerComparison : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y) return -1;
            if (x < y) return 1;
            return 0;
        }
    }
}
