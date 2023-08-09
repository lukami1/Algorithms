using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals
{
    public static class EuclidsAlghorithm
    {
        public static int GCD(int p, int q)
        {
            if (q == 0) return p;
            int remainder = p % q;
            return GCD(q, remainder);
        }
    }
}
