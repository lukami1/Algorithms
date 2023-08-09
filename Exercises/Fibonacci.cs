using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class Fibonacci
    {
        private static long[] memo;
        public static long F(int N)
        {
            memo = new long[N + 1];

            return CalculateF(N);

        }
        public static long CalculateF(int N)
        {
            if (N == 0) return 0;
            if (N == 1) return 1;

            if (memo[N] !=0)
                return memo[N];

            memo[N] = CalculateF(N-1) + CalculateF(N-2);
            return memo[N];
        }
        public static void Run()
        {
            for (int N = 0; N < 2000; N++)
                Console.WriteLine(N + " " + F(N));
        }
    }
}
