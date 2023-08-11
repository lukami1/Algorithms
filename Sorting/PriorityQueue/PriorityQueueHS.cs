using Sorting.HeapSort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.PriorityQueue
{
    internal class PriorityQueueHS<T> : HeapSortBase<T> where T : IComparable<T>
    {
        int N = 1;
        private T[] _queue;

        public PriorityQueueHS(int size)
        {
            _queue = new T[size];
        }
        public void Insert(T key)
        {
            _queue[N++] = key;
            base.Swim(_queue, N);
        }

        public T RemoveMaxElement()
        {
            T key = _queue[1];
            base.Swap(_queue, 1, N);
            base.Sink(_queue, 1);
            N--;
            return key;
        }
    }
}
