using Fundamentals;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Security.Policy;
using System.Diagnostics.Eventing.Reader;
using System.Collections;
using Fundamentals.UnionFind;

namespace Exercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TwoDimensionalBooleanArray(new bool[,] { { true, true, false }, { false, true, false }, {true,true,true } });
            //TranspositionArray(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } });

            ////Histogram
            //int[] array = { 1, 2, 0, 1, 2, 1, 0, 1, 2 };
            //int M = 3;

            //int[] result = Histogram(array, M);

            //Console.WriteLine("Histogram:");
            //for (int i = 0; i < M; i++)
            //{
            //    Console.WriteLine($"{i}: {result[i]}");
            //}

            ////FactorialLn

            //int number = 5;
            //double result = FactorialLn(number);
            //Console.WriteLine($"ln({number}!) = {result}");

            ////Fibonacci
            //Fibonacci.Run();



            ////Practice score card program
            //while (true)
            //{
            //    Console.WriteLine("Enter 'Name' 'int' 'int' to keep score . Type exit to exit");
            //    string line = Console.ReadLine();
            //    if (line.Equals("exit"))
            //    {

            //        return; 
            //    }
            //    Console.WriteLine("Name       Integer1   Integer2   Division");
            //    string[] scoreCard = line.Split(" ");
            //    KeepScore(scoreCard[0], int.Parse(scoreCard[1]), int.Parse(scoreCard[2]));

            //}

            ////Random Connections
            //RandomConnections(50, 0.2);


            ////Binomial
            //Console.WriteLine(BinominalDistribution.Binomial(100, 50, 0.25));


            ////Histogram2
            //Histogram2(5, 0.0, 1.0);

            //Console.WriteLine(Expression("1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )"));
            //var j = new Josephus(8, 7);
            //j.Initialize();
            //j.RemoveItems();

            //RingBuffer<int> ringBuffer = new RingBuffer<int>(5);
            //ringBuffer.Enqueue(1);
            //ringBuffer.Enqueue(2);
            //ringBuffer.Enqueue(3);
            //ringBuffer.Enqueue(4);
            //ringBuffer.Enqueue(5);

            //Console.WriteLine(ringBuffer.Dequeue());

            //ringBuffer .Enqueue(6);

            //Console.WriteLine(ringBuffer.Dequeue());
            //ListDirectoriesAndSubdirectories(@"C:\Users\miske\Documents\Learning\C#");

            //var a = new QuickUnionUFImprovedI(10);
            //a.Union(6, 0);
            //a.Union(1, 0);
            //a.Union(3, 0);
            //var s = a.Connected(1, 6);
            //int[] N  = { 12, 4, 3, 15, 14,14,22,44,12,56 };
            //Console.WriteLine(LocalMinimum(N));

            //    int[,] arr = {
            //    { 9,  7,   8,  5 },
            //    { 6,  4,   3,  4 },
            //    { 12, 10, 11, 15 },
            //    { 14, 18, 16, 17 }
            //};

            //    Console.WriteLine(LocalMinimumMatrix(arr));

            Console.ReadLine();
        }


        public class QuickUnionDynamic
        {
            public class Site
            {
                public int Size;
                public int Parent;
                public Site Next;

                public Site(int id)
                {
                    Parent = id;
                    Size = 1;
                    Next = null;
                }
            }

            Site firstSite;
            int count;

            public int NewSite()
            {
                Site site = new Site(count);
                site.Next = firstSite;
                firstSite = site;
                count++;
                return site.Parent;
            }


            public QuickUnionDynamic()
            {
                firstSite = null;
                count = 0;
            }

            private Site Root(Site p)
            {
                return p;
            }

            public bool IsConnected(int p, int q)
            {
                Site rp = Root(GetSite(p));
                Site rq = Root(GetSite(q));
                return rp == rq;
            }

            private Site GetSite(int p)
            {
                Site current = firstSite;
                while (current.Next != null)
                {
                    current = current.Next;
                    if(current.Parent == p)
                        return current;
                }
                throw new InvalidOperationException();
            }
        }


        interface IDeque<T>
        {
            bool IsEmpty();
            int Size();
            void PushLeft(T item);
            void PushRight(T item);
            T PopLeft();
            T PopRight();

        }


        public class DequeLinked<T> : IDeque<T>
        {
            int size = 0;
            Node tail;
            Node head;

            public DequeLinked() { }

            private class Node
            {
                public T Item;
                public Node Previous;
                public Node Next;
            }


            public bool IsEmpty()
            {
                return Size() == 0;
            }

            public T PopLeft()
            {
                if (IsEmpty())
                    throw new InvalidOperationException("Deque is empty!");
                var item = head.Item;
                head = head.Next;
                size--;
                return item;
            }

            public T PopRight()
            {
                if (IsEmpty())
                    throw new InvalidOperationException("Deque is empty!");

                var item = tail.Item;
                tail = tail.Previous;
                size--;
                return item;
            }

            public void PushLeft(T item)
            {
                Node newNode = new Node() { Item = item };
                if (IsEmpty())
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    head.Previous = newNode;
                    newNode.Next = head;
                    head = newNode;
                }
                size++;
            }

            public void PushRight(T item)
            {
                Node newNode = new Node() { Item = item };
                if (IsEmpty())
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    tail.Next = newNode;
                    newNode.Previous = tail;
                    tail = newNode;
                }
                size++;
            }

            public int Size()
            {
                return size;
            }
        }

        public class DequeResizinArray<T> : IDeque<T>
        {
            int size = 0;
            T[] items;
            int current = 0;
            public DequeResizinArray(int N)
            {
                items = new T[N];
            }

            public bool IsEmpty()
            {
                return Size() == 0;
            }

            public T PopLeft()
            {
                T item = items[0];
                for (int i = 1; i < current - 1; i++)
                {
                    items[i] = items[i + 1];
                }
                current--;
                return item;
            }

            public T PopRight()
            {
                T item = items[current];
                items[current] = default;
                current--;
                return item;

            }

            private void ResizeArray(int size)
            {
                var newArray = new T[size];
                for (int i = 0; i < items.Length; i++)
                {
                    newArray[i] = items[i];
                }
                items = newArray;
            }
            public void PushLeft(T item)
            {
                if (Size() == 0)
                {
                    items[0] = item;
                }
                if (Size() + 1 >= items.Length)
                    ResizeArray(items.Length * 2);
                for (int i = current; i > 0; i--)
                {
                    items[i + 1] = items[i];
                }
                items[0] = item;
                current++;
            }

            public void PushRight(T item)
            {
                if (Size() == 0)
                {
                    items[0] = item;
                }
                if (Size() + 1 >= items.Length)
                    ResizeArray(items.Length * 2);
                items[current++] = item;
            }

            public int Size()
            {
                return size;
            }
        }
        public class StaqueTwoStacku<T> : IStaque<T>
        {
            int count = 0;
            Stack<T> enqueueStack = new Stack<T>();
            Stack<T> dequeueStack = new Stack<T>();

            public int Count()
            {
                return count;
            }

            public void Enqueue(T item)
            {
                while (enqueueStack.Count > 0)
                {
                    dequeueStack.Push(enqueueStack.Pop());
                }
                enqueueStack.Push(item);
                while (dequeueStack.Count > 0)
                {
                    enqueueStack.Push(dequeueStack.Pop());
                }
                count++;
            }

            public bool IsEmpty()
            {
                return Count() == 0;
            }

            public T Pop()
            {
                var item = enqueueStack.Pop();
                count--;
                return item;
            }

            public void Push(T item)
            {
                count++;
                enqueueStack.Push(item);
            }
        }

        public class Staqueu<T> : IStaque<T>
        {
            int count = 0;
            Node head;
            Node tail;
            private class Node
            {
                public T Item;
                public Node Next;
            }
            public int Count()
            {
                return count;
            }

            public void Enqueue(T item)
            {
                Node newNode = new Node() { Item = item };
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    newNode.Next = head;
                    head = newNode;
                }
            }

            public bool IsEmpty()
            {
                return Count() == 0;
            }

            public T Pop()
            {
                var item = head;
                if (IsEmpty())
                    throw new InvalidOperationException();
                if (head.Next == null)
                {
                    head = null;
                }
                else
                {
                    while (item.Next.Next != null)
                    {
                        item = item.Next;
                    }
                    var res = item.Next.Item;
                    item.Next = tail;
                    return res;

                }
                return item.Item;

            }

            public void Push(T item)
            {
                Node newNode = new Node() { Item = item };
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    tail.Next = newNode;
                    tail = newNode;
                }
            }
        }

        interface IStaque<T>
        {
            //returns true if staque is empty, otherwise false.
            bool IsEmpty();

            //returns the size of the staque.
            int Count();

            //add element to top of the staque.
            void Push(T item);

            //add element to bottom of the staque.
            void Enqueue(T item);

            //removes an element from the top of the staque.
            T Pop();
        }

        public class StackQueue<T>
        {
            private Queue<T> queue = new Queue<T>();

            public void Push(T item)
            {
                queue.Enqueue(item);
            }
            public T Pop()
            {
                if (queue.Count > 0)
                    RotateQueue();
                if (queue.Count != 0)
                    return queue.Dequeue();
                throw new InvalidOperationException("Stack is empty!");
            }

            private void RotateQueue()
            {
                for (int i = 0; i < queue.Count - 1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
            }
        }

        public class QueueTwoStack<T>
        {
            private Stack<T> enqueueStack = new Stack<T>();
            private Stack<T> dequeueStack = new Stack<T>();

            public void Enqueue(T item)
            {
                enqueueStack
                    .Push(item);
            }

            public T Dequeue()
            {
                if (dequeueStack.Count == 0)
                    TransferStacks();
                if (dequeueStack.Count > 0)
                    return dequeueStack.Pop();
                throw new InvalidOperationException("Queue is empty!!");
            }

            private void TransferStacks()
            {
                while (enqueueStack.Count != 0)
                {
                    dequeueStack.Push(enqueueStack.Pop());
                }

            }
        }


        public static int LocalMinimumMatrix(int[,] N)
        {
            int length = N.GetLength(0);
            int lo = 0;
            int hi = length - 1;

            while (lo <= hi)
            {
                int minColumn = lo + (hi - lo) / 2;
                int minRow = 0;
                int minValue = int.MaxValue;
                for (int i = 0; i < length; i++)
                {
                    if (N[i, minColumn] < minValue)
                    {
                        minValue = N[i, minColumn];
                        minRow = i;
                    }
                }

                bool localMinumum = true;

                if (minColumn > 0 && minValue > N[minRow, minColumn - 1])
                    localMinumum = false;
                if (minColumn < length - 1 && minValue > N[minRow, minColumn + 1])
                    localMinumum = false;
                if (minRow > 0 && minValue > N[minRow - 1, minColumn])
                    localMinumum = false;
                if (minRow < length - 1 && minValue < N[minRow + 1, minColumn])
                    localMinumum = false;

                if (localMinumum)
                    return minValue;

                if (minColumn > 0 && N[minRow, minColumn - 1] < N[minRow, minColumn])
                {
                    hi = minColumn - 1;
                }
                else if (minColumn < length - 1 && N[minRow, minColumn + 1] < N[minRow, minColumn])
                {
                    lo = minColumn + 1;
                }
                else
                {
                    return N[minRow, minColumn];
                }



            }
            return -1;
        }
        public static int LocalMinimum(int[] N)
        {
            int lo = 0, hi = N.Length - 1;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (N[mid - 1] > N[mid] && N[mid] < N[mid + 1])
                {
                    return N[mid];
                }
                else if (N[mid - 1] < N[mid + 1])
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }
            return N[lo];
        }


        public static void ListDirectoriesAndSubdirectories(string dirpath)
        {
            Queue<string> path = new Queue<string>();
            Queue<string> filesQ = new Queue<string>();
            path.Enqueue(dirpath);
            while (path.Count > 0)
            {
                var dir = path.Dequeue();
                var subDirs = Directory.GetDirectories(dir);
                foreach (var subDir in subDirs)
                {
                    path.Enqueue($"{subDir}");
                }

                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    filesQ.Enqueue(file);
                }
            }
        }

        public class MoveToFront
        {
            public class Node
            {
                public char item;
                public Node next;
            }
            private string itemSequence;
            public MoveToFront(string sequence)
            {
                itemSequence = sequence;
            }

            private Node first;
            private int size;

            public void ReadSequence()
            {
                for (int i = 0; i < itemSequence.Length; i++)
                {
                    Node newNode = new Node()
                    {
                        item = itemSequence[i]
                    };
                    if (first == null)
                    {
                        first = newNode;
                    }
                    else
                    {
                        first.next = newNode;
                        first = newNode;
                    }
                }
            }
        }

        public class RingBuffer<T>
        {
            public RingBuffer(int capacity)
            {
                items = new T[capacity];
            }

            T[] items;
            int size = 0;
            int left = 0;
            int right = -1;

            public int Size()
            {
                return size;
            }
            public bool IsEmpty()
            {
                return size == 0;
            }

            public bool IsFull()
            {
                return size == items.Length;
            }

            public void Enqueue(T item)
            {
                right = (right + 1) % items.Length;
                items[right] = item;
                size++;
            }
            public T Dequeue()
            {
                T item = items[left];
                left = (left + 1) % items.Length;
                size--;
                return item;
            }



        }

        public class GeneralizedQueue<T>
        {
            int size = 0;
            bool IsEmpty()
            {
                return size == 0;
            }
            T[] items;
            public GeneralizedQueue(int max)
            {
                items = new T[max];
            }

            public void Add(T item)
            {
                items[size] = item;
                size++;
            }

            public T Delete(int k)
            {
                T item = items[k];

                for (int i = k; i < items.Length - 1; i++)
                {
                    items[i] = items[i + 1];
                }

                return item;
            }
        }

        public class GeneralizedQueueLinked<T>
        {
            private class Node
            {
                public T item;
                public Node next;
            }
            private Node first;
            int size = 0;
            public bool IsEmpty()
            {
                return size == 0;
            }

            public void Insert(T item)
            {
                Node newNode = new Node()
                {
                    item = item
                };

                if (IsEmpty())
                {
                    first = newNode;
                }
                else
                {
                    newNode.next = first;
                    first = newNode;
                }
                size++;
            }

            public T Delete(int k)
            {
                if (k == 0)
                {
                    T item = first.item;
                    first = first.next;
                    size--;
                    return item;
                }
                Node current = first;
                for (int i = 0; i < k - 1; i++)
                {
                    current = current.next;
                }
                T del = current.next.item;
                current.next = current.next.next;
                size--;
                return del;
            }







        }

        public class Josephus
        {
            int N;
            int M;
            Queue<int> q;
            public Josephus(int m, int n)
            {
                this.N = n;
                this.M = m;
            }

            public void Initialize()
            {
                q = new Queue<int>();
                for (int i = 0; i < N; i++)
                {
                    q.Enqueue(i);
                }
            }

            public void RemoveItems()
            {
                while (q.Count > 1)
                {
                    for (int i = 0; i < M - 1; i++)
                    {
                        int item = q.Dequeue();
                        q.Enqueue((int)item);
                    }
                    Console.WriteLine(q.Dequeue());
                }
                Console.WriteLine("Sit at:" + q.Dequeue());
            }
        }

        public class RandomBag<T> : IEnumerable<T>
        {
            private int size = 0;
            public int Size()
            {
                return size;
            }
            public bool IsEmpty()
            {
                return size == 0;
            }
            private T[] items;
            public RandomBag(int s)
            {
                items = new T[s];
            }

            public void Add(T item)
            {
                items[size] = item;
                size++;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new RandomBagEnumerator(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private class RandomBagEnumerator : IEnumerator<T>
            {
                private readonly RandomBag<T> bag;
                private int currentIndex;
                private T[] shuffeledItems;

                public RandomBagEnumerator(RandomBag<T> bag)
                {
                    this.bag = bag;
                    currentIndex = -1;
                    shuffeledItems = new T[bag.Size()];
                    Array.Copy(bag.items, shuffeledItems, bag.size);
                    ShuffleItems();
                }

                private void ShuffleItems()
                {
                    Random rng = new Random();
                    int n = bag.size;
                    while (n > 1)
                    {
                        n--;
                        int k = rng.Next(n + 1);
                        T temp = shuffeledItems[k];
                        shuffeledItems[k] = shuffeledItems[n];
                        shuffeledItems[n] = temp;
                    }
                }

                public T Current
                {
                    get
                    {
                        if (currentIndex >= 0 && currentIndex < bag.size)
                        {
                            return shuffeledItems[currentIndex];
                        }
                        throw new InvalidOperationException();
                    }
                }

                object IEnumerator.Current => Current;

                public void Dispose()
                {
                    // Nothing to dispose
                }

                public bool MoveNext()
                {
                    currentIndex++;
                    return currentIndex < bag.size;
                }

                public void Reset()
                {
                    currentIndex = -1;
                }
            }
        }

        public class Deque<T>
        {
            public Deque()
            {

            }

            private class Node
            {
                public T item;
                public Node previous;
                public Node next;
            }
            private Node head;
            private Node tail;
            private int size = 0;

            public int Size()
            {
                return size;
            }
            bool IsEmpty()
            {
                return size == 0;
            }

            public void PushLeft(T item)
            {
                Node newNode = new Node()
                {
                    item = item,

                };
                if (IsEmpty())
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    head.previous = newNode;
                    newNode.next = head;
                    head = newNode;

                }
                size++;
            }
            public void PushRight(T item)
            {
                Node newNode = new Node()
                {
                    item = item,

                };
                if (IsEmpty())
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    tail.next = newNode;
                    newNode.previous = tail;
                    tail = newNode;
                }
                size++;
            }
            public T PopLeft()
            {
                T item = head.item;
                head = head.next;
                size--;
                return item;
            }
            public T PopRight()
            {
                T item = tail.item;
                tail = tail.previous;
                size--;
                return item;
            }
        }


        public class Staque<T>
        {
            private class Node
            {
                public T item;
                public Node next;
            }
            private Node first;
            private Node last;
            private int N = 0;
            private bool IsEmpty()
            {
                return N == 0;
            }
            public void push(T item)
            {
                Node oldFirst = first;

                if (IsEmpty())
                {
                    first = new Node()
                    {
                        item = item,
                        next = oldFirst
                    };
                    last = first;
                }
                else
                {
                    first = new Node()
                    {
                        item = item,
                        next = oldFirst
                    };
                }
                N++;
            }
            public T pop()
            {
                if (IsEmpty())
                    throw new InvalidOperationException("Steque is empty");
                T item = first.item;
                first = first.next;
                N--;
                if (IsEmpty())
                    last = null;
                return item;
            }
            public void enqueue(T item)
            {

            }
        }


        /*
            Write an iterable Stack client that has a static method copy() that takes a stack
            of strings as argument and returns a copy of the stack. Note : This ability is a prime
            example of the value of having an iterator, because it allows development of such func-
            tionality without changing the basic API.
         */
        public class MyStack<T>
        {
            private class Node
            {
                public T Item;
                public Node Next;
            }
            private Node first;
            private int N;

            private bool IsEmpty() { return first == null; }
            public int Size()
            {
                return N;
            }
            public void Push(T item)
            {
                Node old = first;
                first = new Node()
                {
                    Item = item,
                    Next = old
                };
                N++;
            }
            public T Pop()
            {
                T item = first.Item;
                first = first.Next;
                N--;
                return item;
            }


        }

        /*
         * Develop a class ResizingArrayQueueOfStrings that implements the queue
            abstraction with a fixed-size array, and then extend your implementation to use array
            resizing to remove the size restriction.
         */

        public class ResizingArrayQueueOfStrings
        {
            public ResizingArrayQueueOfStrings(int size)
            {
                queue = new string[size];
            }
            int N = 0;
            int first = 0;
            string[] queue;

            public string Dequeue()
            {
                string item = queue[first];
                if (first == N / 2)
                {
                    Resize(N / 2);
                }
                first++;
                return item;
            }
            public void Enqueue(string item)
            {
                if (N == queue.Length)
                    Resize(queue.Length * 2);
                queue[N++] = item;

            }

            private void Resize(int v)
            {
                string[] resized = new string[v];
                for (int i = first; i < N; i++)
                {
                    resized[i] = queue[i];
                }
                first = 0;
                queue = resized;
            }

        }

        /*        
                Write a program that takes from standard input an expression without left pa-
                rentheses and prints the equivalent infix expression with the parentheses inserted.For
                example, given the input:
                1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )
                your program should print
                (( 1 + 2 ) * (( 3 - 4 ) * ( 5 - 6 ) ) )
        */
        private static string Expression(string expression)
        {
            Stack<string> output = new Stack<string>();
            Stack<string> ops = new Stack<string>();

            foreach (char s in expression)
            {
                if (s.Equals(' '))
                    continue;
                if (char.IsDigit(s))
                {
                    output.Push(s.ToString());
                }
                else if (IsOperator(s))
                {
                    ops.Push(s.ToString());
                }
                else if (s == ')')
                {
                    var right = output.Pop();
                    var left = output.Pop();
                    string op = ops.Pop();
                    output.Push("(" + left + op + right + ")");
                }
            }
            string outs = output.Pop().ToString();
            return outs;
        }

        private static bool IsOperator(char c)
        {
            if (c.Equals('*') || c.Equals('-') || c.Equals('+') || c.Equals('/'))
                return true;
            return false;
        }

        /* 
           Write a static method histogram() that takes an array a[] of int values and
           an integer M as arguments and returns an array of length M whose ith entry is the num-
           ber of times the integer i appeared in the argument array. If the values in a[] are all
           between 0 and M–1, the sum of the values in the returned array should be equal to
           a.length.
        */

        private static int[] Histogram(int[] a, int m)
        {
            int[] counts = new int[m];

            foreach (int value in a)
            {
                if (value < 0 && value >= m)
                {
                    throw new ArgumentException("Invalid argument given in array a");
                }

                counts[value]++;
            }

            return counts;
        }

        /* 
           Write a code fragment to print the transposition (rows and columns changed)
           of a two-dimensional array with M rows and N columns.
        */
        private static void TranspositionArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            int[,] transposedArray = new int[cols, rows];

            for (int m = 0; m < rows; m++)
            {
                for (int n = 0; n < cols; n++)
                {
                    transposedArray[n, m] = array[m, n];
                }
            }

            for (int m = 0; m < cols; m++)
            {
                for (int n = 0; n < rows; n++)
                {
                    Console.Write(transposedArray[m, n]);
                }
                Console.WriteLine();
            }
        }

        /* 
           Write a code fragment that prints the contents of a two-dimensional boolean
           array, using * to represent true and a space to represent false. Include row and column
           numbers.
        */
        private static void TwoDimensionalBooleanArray(bool[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            Console.Write("  ");

            for (int col = 0; col < cols; col++)
            {
                Console.Write($"{col} ");
            }

            Console.WriteLine();

            for (int row = 0; row < rows; row++)
            {
                Console.Write($"{row} ");

                for (int col = 0; col < cols; col++)
                {
                    char value = array[row, col] ? '*' : ' ';
                    Console.Write($"{value} ");
                }

                Console.WriteLine();
            }

        }


        /* 
            Write a recursive static method that computes the value of ln (N !).
        */
        private static double FactorialLn(int N)
        {
            if (N < 0)
                throw new ArgumentException("Invalid argument!");
            if (N <= 0)
                return 0;
            return Math.Log(N) + FactorialLn(N - 1);
        }

        /* 
            Write a program that reads in lines from standard input with each line contain-
            ing a name and two integers and then uses printf() to print a table with a column of
            the names, the integers, and the result of dividing the first by the second, accurate to
            three decimal places. You could use a program like this to tabulate batting averages for
            baseball players or grades for students.
         */

        private static string[,] resultTable = new string[10, 10];
        private static int inputCount = 0;
        private static void KeepScore(string name, int a, int b)
        {
            inputCount++;
            double _result = (double)a / b;
            string[] cols = new string[] { name, a.ToString(), b.ToString(), _result.ToString("F3") };
            for (int i = 0; i < cols.Length; i++)
            {
                resultTable[inputCount, i] = cols[i];
            }


            var rowCount = resultTable.GetLength(0);
            var colCount = resultTable.GetLength(1);

            for (int y = 0; y < rowCount; y++)
            {
                for (int z = 0; z < colCount; z++)
                {
                    Console.Write($"{resultTable[y, z]}       ");
                }
                Console.WriteLine();
            }
        }


        /*
            Random connections. Write a program that takes as command-line arguments
            an integer N and a double value p (between 0 and 1), plots N equally spaced dots of size
            .05 on the circumference of a circle, and then, with probability p for each pair of points,
            draws a gray line connecting them
         */

        private static void RandomConnections(int N, double p)
        {
            if (p < 0 || p > 1)
                throw new ArgumentException("Argument p must have a value between 0 and 1");

            Application.Run(new CirclePlot(N, p));
        }

        /*
            Histogram. Suppose that the standard input stream is a sequence of double
            values. Write a program that takes an integer N and two double values l and r from the
            command line and uses StdDraw to plot a histogram of the count of the numbers in the
            standard input stream that fall in each of the N intervals defined by dividing (l , r) into
            N equal-sized intervals
         */

        private static void Histogram2(int N, double l, double r)
        {

            List<int> counts = new List<int>(N);
            for (int i = 0; i < N; i++)
            {
                counts.Add(0);
            }

            double intervalSize = (r - l) / N;

            string line;
            while (!String.IsNullOrEmpty(line = Console.ReadLine()))
            {
                if (double.TryParse(line, out double value))
                {
                    int index = (int)((value - l) / intervalSize);
                    if (index >= 0 && index < N)
                    {
                        counts[index]++;
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                double intervalStart = l + intervalSize * i;
                double intervalEnd = intervalStart + intervalSize;
                Console.WriteLine($"Interval [{intervalStart.ToString("F2")},{intervalEnd.ToString("F2")},{counts[i]}]");
            }

        }

    }
}