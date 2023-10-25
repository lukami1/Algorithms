using Graphs.Directed;
using Graphs.WordNet;
namespace Graphs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"C:\repos\Algorithms\Graphs\WordNet\digraph25.txt");

            var dig = new Digraph(lines.Count() + 1);
            foreach (var line in lines)
            {
                dig.AddEdge(int.Parse(line.Split(' ')[0]), int.Parse(line.Split(" ")[1]));
            }
            var sap = new ShortestAncestralPath(dig);
            sap.Length(16,13);
            //var w = new WordNet.WordNet(@"C:\repos\Algorithms\Graphs\WordNet\synsets.txt", @"C:\repos\Algorithms\Graphs\WordNet\hypernyms.txt");
            //w.ShortestAncestralPath("AND_circuit", "logic_gate");
        }
    }
}