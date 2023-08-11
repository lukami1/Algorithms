namespace Sorting.HeapSort
{
    internal class HeapSort<T> : HeapSortBase<T> where T : IComparable<T>
    {
        public void Sort(T[] a)
        {
            int N = a.Length;
            for(int k = N/2; k>=1; k--)
            {
                Sink(a, k, N);
            }
            while (N > 1)
            {
                Swap(a,1,N--);
                Sink(a,1, N);
            }
        }
    }
}
