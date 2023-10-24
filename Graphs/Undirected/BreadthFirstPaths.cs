using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Graphs.Undirected
{
    internal class BreadthFirstPaths
    {
        bool[] marked;
        int[] edgeTo;
        int s;

        public BreadthFirstPaths(Graph G, int s)
        {
            this.s = s;
            marked = new bool[G.GetVerticies()];
            edgeTo = new int[G.GetVerticies()];
        }

        private void BFS(Graph G, int v)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(v);
            marked[v] = true;

            while (queue.Count > 0)
            {
                int w = queue.Dequeue();
                foreach(int vv in G.GetEnumerator(w))
                {
                    if (!marked[vv])
                    {
                        marked[vv] = true;
                        edgeTo[vv] = w;
                        queue.Enqueue(vv);
                    }
                }
            }

        }

        public bool HasPathTo(int v)
        {
            return marked[v];
        }

        public IEnumerable<int>? GetPathTo(int v)
        {
            if (!HasPathTo(v)) return null;
            Stack<int> stack = new Stack<int>();
            for(int x = v; x != s; x= edgeTo[x])
            {
                stack.Push(x);
            }
            stack.Push(s);
            return stack;
        }
    }
}
