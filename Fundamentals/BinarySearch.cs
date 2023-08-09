namespace Fundamentals
{
    public class BinarySearch
    {
        public static int IndexOf(int[] a, int key)
        {
            int low = 0;
            int high = a.Count() - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (key > a[mid]) { low = mid + 1; }
                else if (key < a[mid]) { high = mid - 1; }
                else return mid;
            }
            return -1;
        }

        public static int DistinctHashSortAndIndexOf(int[] a, int key)
        {
            return IndexOf(new SortedSet<int>(a).ToArray(), key);
        }

        public static int DistinctSortAndIndexOf(int[] a, int key)
        {
            return IndexOf(a.Distinct().OrderBy(x => x).ToArray(), key);
        }
    }
}