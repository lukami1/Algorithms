using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Undirected
{
    internal class Graph
    {
        private int V;
        private int E;
        private ConcurrentBag<int>[] adj;

        public Graph(int V)
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
            adj[w].Add(v);
            E++;
        }

        public IEnumerable<int> GetEnumerator(int v)
        {
            return adj[v];
        }

    }
}
