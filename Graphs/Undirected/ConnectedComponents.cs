using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Undirected
{
    internal class ConnectedComponents
    {
        bool[] marked;
        int[] ids;
        int count;

        public ConnectedComponents(Graph G)
        {
            marked = new bool[G.GetVerticies()];
            ids = new int[G.GetVerticies()];
            count = 0;
            for (int i = 0; i < G.GetVerticies(); i++)
            {
                if (!marked[i])
                {
                    DFS(G, i);
                    count++;
                }
            }
        }

        private void DFS(Graph G, int v)
        {
            marked[v] = true;
            ids[v] = count;
            foreach (int w in G.GetEnumerator(v))
            {
                if (!marked[w])
                    DFS(G, w);
            }
        }
    }
}
