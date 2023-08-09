using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Helpers
{
    class Node<T> where T : IComparable<T>
    {
        public T Item;
        public Node<T> Next;
        public Node()
        {

        }
        public Node(T item)
        {
            this.Item = item;
        }
    }
    class GenericLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {

        Node<T> head;

        private int size;
        public int Size()
        {
            return size;
        }
        public void Add(T item)
        {
            var newNode = new Node<T>(item);

            if (head == null)
            {
                head = newNode;
                return;
            }
            newNode.Next = head;
            head = newNode;
            size++;
        }

        public void Sort()
        {
            head = Sort(head);
        }

        public void Shuffle()
        {
            head = Shuffle(head);
        }

        private Node<T> Shuffle(Node<T> _head)
        {
            Random random = new Random();
            T[] result = new T[size];
            int i = 0;
            foreach (var item in this)
            {
                var r = random.Next(0, i);
                result[i] = item;
                var swap = result[i];
                result[i] = result[r];
                result[r] = swap;
                i++;
            }
            Node<T> resultNode = new Node<T>();
            foreach (var item in result)
            {
                var newNode = new Node<T>(item);
                newNode.Next = resultNode;
                resultNode = newNode;
            }
            return resultNode;
        }

        private Node<T> Sort(Node<T> _head)
        {
            if (_head == null || _head.Next == null)
                return _head;
            var seekerNode = _head;
            var midNode = seekerNode;
            while (seekerNode.Next != null && seekerNode.Next.Next != null)
            {
                midNode = midNode.Next;
                seekerNode = seekerNode.Next.Next;
            }

            var midNext = midNode.Next; // set low point for right side of list
            midNode.Next = null;  // set hight point for left side of list

            var leftN = Sort(_head); // sort left side
            var rightN = Sort(midNext); // sort right side
            var resultNode = new Node<T>();
            var currentNode = resultNode;
            //merge left and right
            while (rightN != null && leftN != null)
            {
                if (rightN.Item.CompareTo(leftN.Item) < 0)
                {
                    currentNode.Next = rightN;
                    rightN = rightN.Next;
                }
                else
                {
                    currentNode.Next = leftN;
                    leftN = leftN.Next;
                }
                currentNode = currentNode.Next; // move node to the right
            }
            currentNode.Next = (rightN == null) ? leftN : rightN;


            return resultNode.Next; // return murged
        }


        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedEnumerator(head);
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class LinkedEnumerator : IEnumerator<T>
        {
            private Node<T> _current;
            public LinkedEnumerator(Node<T> current)
            {
                this._current = current;
            }
            public T Current
            {
                get
                {
                    return _current.Item;
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                //nothing to dispose
            }

            public bool MoveNext()
            {
                if (_current == null) return false;
                _current = _current.Next;
                return _current != null;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
