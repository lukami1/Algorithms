using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals
{
    public static class BinominalDistribution
    {
        public static double Binomial(int n, int k, double p)
        {


            double[,] memo = new double[n + 1, k + 1];

            return CalculateBinomial(n, k, p, memo);
        }

        private static double CalculateBinomial(int n, int k, double p, double[,] memo)
        {
            if (n == 0 && k == 0) return 1.0;
            if (n < 0 || k < 0) return 0.0;

            if (memo[n, k] != 0) return memo[n, k];

            memo[n, k] = (1 - p) * CalculateBinomial(n - 1, k, p, memo) + p * CalculateBinomial(n - 1, k - 1, p, memo);

            return memo[n, k];
        }

    }
}
