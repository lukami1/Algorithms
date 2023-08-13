using Searching.SymbolTables;

namespace Searching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sst = new SequentialSearchST<int,int>();

            sst.Add(1, 2);
            sst.Add(3, 4);
            sst.Add(5, 6);
            sst.Add(6, 7);
            sst.Add(7, 8);
            sst.Add(8, 9);


            foreach (int i in sst)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}