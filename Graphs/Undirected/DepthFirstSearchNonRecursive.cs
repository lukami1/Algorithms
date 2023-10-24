using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Undirected
{
    internal class DepthFirstSearchNonRecursive
    {
        private bool[] marked;
        private Stack<int> visited;
        public DepthFirstSearchNonRecursive(Graph G, int s) 
        {
            marked = new bool[G.GetVerticies()];
            visited = new Stack<int>();
            DFS(G, s);
        }
        private void DFS(Graph G, int v)
        {
            marked[v] = true;
            visited.Push(v);
            while(visited.Count > 0)
            {
                var w = visited.Pop();
                marked[w] = true;
                foreach(int vv in G.GetEnumerator(w))
                {
                    if (!marked[vv])
                    {
                        visited.Push(vv);
                    }
                }
            }
        }

    }
}
