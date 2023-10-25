using Graphs.Directed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.WordNet
{
    internal class ShortestAncestralPath
    {
        private Digraph graph;
        public ShortestAncestralPath(Digraph G)
        {
            graph = G;
        }
        public int Length(int v, int w)
        {
            var bfsV = new BreadthFirstPaths(graph, v);
            var bfsW = new BreadthFirstPaths(graph, w);
            var commonAncestor = Ancestor(v, w);
            var path = bfsV.GetPathTo(commonAncestor);
            var pathW = bfsW.GetPathTo(commonAncestor);
            var res = path?.Count() - 1 + pathW?.Count() -1 ;
            if (res == null) return -1;
            else return (int)res;

        }
        public int Ancestor(int v, int w) {

            var bfsV = new BreadthFirstPaths(graph, v);
            var bfsW = new BreadthFirstPaths(graph, w);
            Stack<int>? pathV = bfsV.GetPathTo(0) as Stack<int>;
            while(pathV?.Count > 0)
            {
                var item = pathV.Pop();
                if (bfsW.HasPathTo(item))
                {
                    return item; 
                }
            }
            return -1;
        }

        //public int Length(IEnumerable<int> v, IEnumerable<int> w) { }
        //public int Ancestor(IEnumerable<int> v, IEnumerable<int> w) { }
        
    }


}
