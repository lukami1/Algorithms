using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Undirected
{
    internal class DepthFirstSearch
    {
        private bool[] marked;
        private int count;

        public DepthFirstSearch(Graph G, int s) 
        {
            marked = new bool[G.GetVerticies()];
            DFS(G, s);
        }
        private void DFS(Graph G, int v)
        {
            marked[v] = true;
            count++;
            foreach(int w in G.GetEnumerator(v))
            {
                if (!marked[w])
                    DFS(G, w);
            }
        }
    }
}
