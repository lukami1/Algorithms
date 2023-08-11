using Sorting.Elementary;
using Sorting.Helpers;
using Sorting.Helpers.CustomComparers;
using Sorting.MergeSort;

namespace Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int[] unsorted = new int[] { 1, 4, 52, 21, 3, 62, 2, 1, 3, 4, 11 };
            //var mergeSortTest = new MergeSortTopDown<int>();
            //mergeSortTest.Sort(unsorted, new DescendingIntegerComparison());

            //var selectionSortTest = new SelectiveSort<int>();
            //selectionSortTest.Sort(unsorted);
            //selectionSortTest.Sort(unsorted, new DescendingIntegerComparison());

            //var insertionSortTest = new InsertionSort<int>();
            //insertionSortTest.Sort(unsorted);
            //insertionSortTest.Sort(unsorted, new DescendingIntegerComparison());


            //var schellSortTest = new SchellSort<int>();
            //schellSortTest.Sort(unsorted);
            //schellSortTest.Sort(unsorted, new DescendingIntegerComparison());
            var a = new GenericLinkedList<int>();
            a.Add(1);
            a.Add(8);
            a.Add(9);
            a.Add(7);
            a.Add(2);
            a.Add(5);
            a.Add(11);
            a.Add(6);
            a.Add(10);
            foreach (int v in a)
            {
                Console.Write($" {v}");
            }
            a.Shuffle();
            Console.WriteLine();
            foreach (int v in a)
            {
                Console.Write($" {v}");
            }
            a.Sort();
            Console.WriteLine();
            foreach (int v in a)
            {
                Console.Write($" {v}");
            }


            BottomUpQueueMerge(unsorted);
            var test = new ExtraSpaceMergeSort<int>();
            test.Sort(unsorted);
            test.Sort(unsorted, new DescendingIntegerComparison());

            Console.ReadLine();
        }

        /*
         
         Nuts and bolts. (G. J. E. Rawlins) You have a mixed pile of N nuts and N bolts
and need to quickly find the corresponding pairs of nuts and bolts. Each nut matches
exactly one bolt, and each bolt matches exactly one nut. By fitting a nut and bolt to-
gether, you can see which is bigger, but it is not possible to directly compare two nuts or
two bolts. Give an efficient method for solving the problem
         */


        private void MatchNutAndBolt(int[] nuts, int[] bolts)
        {
        }

        private void MatchNutAndBolt(int[] nuts, int[] bolts, int lo, int hi)
        {
            if (lo > hi) return;
            var j = Partition(nuts, bolts[hi], lo, hi);
            Partition(bolts, nuts[j], lo, hi);
            MatchNutAndBolt(nuts, bolts, lo, j - 1);
            MatchNutAndBolt(nuts, bolts, j + 1, hi);
        }

        private int Partition(int[] a, int key, int lo, int hi)
        {
            int i = lo + 1; int j = hi;
            int v = key;
            while (true)
            {
                while (a[i] < v)
                {
                    if (i >= hi)
                        break;
                    i++;
                }
                while (a[j] > v)
                {
                    if (j <= lo)
                    {
                        break;
                    }
                    i--;
                }
                if (i >= j) break;
                var swap = a[i];
                a[i] = a[j];
                a[j] = swap;
            }
            var swap1 = a[lo];
            a[lo] = a[j];
            a[j] = swap1;
            return j;
        }

        /*
         Merging sorted queues. Develop a static method that takes two queues of sorted
items as arguments and returns a queue that results from merging the queues into
sorted order.
         */
        public static Queue<int> MergeTwoSortedQueues(Queue<int> pq, Queue<int> qq)
        {
            var newQueue = new Queue<int>();
            var count = pq.Count + qq.Count;
            while (newQueue.Count < count)
            {
                var p = pq.Count > 0 ? pq.Dequeue() : -1;
                var q = qq.Count > 0 ? qq.Dequeue() : -1;
                if (p > q)
                {
                    if (q > 0)
                        newQueue.Enqueue(q);
                    if (p > 0)
                        newQueue.Enqueue(p);
                }
                else
                {
                    if (p > 0)
                        newQueue.Enqueue(p);
                    if (q > 0)
                        newQueue.Enqueue(q);
                }
            }
            return newQueue;
        }

        private static void MergeQueues(Queue<int> newQueue, Queue<int> p)
        {

            while (p.Count > 0)
            {
                newQueue.Enqueue(p.Dequeue());
            }
        }

        /*
         Bottom-up queue mergesort. Develop a bottom-up mergesort implementation
based on the following approach: Given N items, create N queues, each containing one
of the items. Create a queue of the N queues. Then repeatedly apply the merging opera-
tion of Exercise 2.2.14 to the first two queues and reinsert the merged queue at the end.
Repeat until the queue of queues contains only one queue.
         */

        private static void BottomUpQueueMerge(int[] N)
        {
            Queue<Queue<int>> queueOfQueues = new Queue<Queue<int>>();

            for (int i = 0; i < N.Length; i++)
            {
                var q = new Queue<int>();
                q.Enqueue(N[i]);
                queueOfQueues.Enqueue(q);
            }
            while (queueOfQueues.Count > 1)
            {
                var p1 = queueOfQueues.Dequeue();
                var p2 = queueOfQueues.Dequeue();
                queueOfQueues.Enqueue(MergeTwoSortedQueues(p1, p2));
            }
        }
    }
}