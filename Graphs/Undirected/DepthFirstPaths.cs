using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Undirected
{
    internal class DepthFirstPaths
    {
        bool[] marked;
        int[] edgeTo;
        int s;

        public DepthFirstPaths(Graph G, int s)
        {
            this.s = s;
            marked = new bool[G.GetVerticies()];
            edgeTo = new int[G.GetVerticies()];
            DFS(G, s);
        }

        public void DFS(Graph G, int v)
        {
            marked[v] = true;
            foreach (var w in G.GetEnumerator(v))
            {
                if (!marked[w])
                {
                    marked[w] = true;
                    edgeTo[w] = v;
                }
            }

        }

        public bool HasPathTo(int v)
        {
            return marked[v];
        }

        private IEnumerable<int>? PathTo(int v)
        {
            if (!HasPathTo(v)) return null;

            Stack<int> stack = new Stack<int>();
            for(int x = v; x != s; x = edgeTo[x])
            {
                stack.Push(x);
            }
            stack.Push(s);
            return stack;
        }
    }
}
