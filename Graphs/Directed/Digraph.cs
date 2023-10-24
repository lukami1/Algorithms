using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Directed
{
    internal class Digraph
    {
        private int V;
        private int E;
        private ConcurrentBag<int>[] adj;

        public Digraph(int V)
        {
            this.V = V;
            this.E = 0;
            adj = new ConcurrentBag<int>[V];
            for (int i = 0; i < V; i++)
            {
                adj[i] = new ConcurrentBag<int>();
            }
        }

        public int GetVerticies() { return V; }
        public int GetEdges() { return E; }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            E++;
        }

        public IEnumerable<int> GetEnumerator(int v)
        {
            return adj[v];
        }


        public Digraph Reverse()
        {
            var R = new Digraph(V);
            for(int i = 0; i < V; i++)
            {
                foreach(int y in GetEnumerator(i))
                {
                    R.AddEdge(y, i);
                }
            }
            return R;
        }
    }
}
