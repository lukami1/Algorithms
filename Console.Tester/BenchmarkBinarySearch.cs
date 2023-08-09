using BenchmarkDotNet.Attributes;
using Fundamentals;

namespace Tests
{
    public class BenchmarkBinarySearch
    {
        private int[] array;
        private int key;

        [Params(1000000)] // Adjust the parameter values as needed
        public int ArraySize { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            array = GenerateRandomArray(ArraySize);
            key = array[ArraySize - 1]; // Set key to the last element for searching
        }
        private int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(); // Generate a random integer
            }

            return array;
        }


        [Benchmark]
        public void BenchmarkDistinctSortAndIndexOf()
        {
            BinarySearch.DistinctSortAndIndexOf(array, key);
        }

        [Benchmark]
        public void BenchmarkDistinctHashSortAndIndexOf()
        {
            BinarySearch.DistinctHashSortAndIndexOf(array, key);
        }
    }
}
