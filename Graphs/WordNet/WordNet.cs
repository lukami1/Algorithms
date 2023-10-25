using Graphs.Directed;
using Graphs.Undirected;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.WordNet
{
    public class WordNet
    {
        List<string> nouns = new List<string>();
        private Synset[] adj;
        private Digraph wordNetDigraph;
        public WordNet(string synsets, string hypernyms)
        {

            var syns = File.ReadAllLines(synsets);
            var hypers = File.ReadAllLines(hypernyms);
            adj = new Synset[syns.Length];
            wordNetDigraph = new Digraph(syns.Length);
            for(int i = 0; i < syns.Length; i++)
            {
                var synsParts = syns[i].Split(",");
                var hyperParts = hypers[i].Split(",");
                var synset = new Synset() { Id = i };
                foreach(var s in synsParts[1].Split(" ")) 
                {
                    synset.Nouns.Add(s);
                    nouns.Add(s);
                }
                adj[int.Parse(synsParts[0])] = synset;
                for(int y = 1; y < hyperParts.Length; y++)
                {
                    wordNetDigraph.AddEdge(int.Parse(hyperParts[y]), int.Parse(hyperParts[0]));
                    adj[int.Parse(hyperParts[0])].Hypernyms.Add(int.Parse(hyperParts[y]));
                }
            }
        }
        public IEnumerable<string> Nouns()
        {
            return nouns;
        }
        public bool IsNoun(string word)
        {
            return nouns.Contains(word);
        }//contains?
        public int Distance(string nounA, string nounB)
        {
            if (!IsNoun(nounA) || !IsNoun(nounB)) throw new ArgumentException();
            var v = adj.Where(x => x.Nouns.Contains(nounA)).FirstOrDefault().Id;
            var w = adj.Where(x => x.Nouns.Contains(nounB)).FirstOrDefault().Id;
            var bfs = new Directed.BreadthFirstPaths(wordNetDigraph, w);
            if (bfs.HasPathTo(v)) { 
                var s = bfs.GetPathTo(v);
                return s.Count() - 1 ;
            };
            return 0;
        }
        public int ShortestAncestralPath(string nounA, string nounB)
        {
            var sap = new ShortestAncestralPath(wordNetDigraph);
            var v = adj.Where(x => x.Nouns.Contains(nounA)).FirstOrDefault().Id;
            var w = adj.Where(x => x.Nouns.Contains(nounB)).FirstOrDefault().Id;
            return sap.Length(v, w);
        }


    }
    public class Synset
    {
        public int Id;
        public List<string> Nouns = new List<string>();
        public List<int> Hypernyms = new List<int>();
    }

}
