using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyptianFractions
{
    public class Startup
    {
        public static void Main()
        {
            int p = int.Parse(Console.ReadLine());
            int q = int.Parse(Console.ReadLine());

        }

        private static void Solve(int p, int q)
        {

        }

        private static void Cancel(ref int p, ref int q)
        {
            if (q % p == 0)
            {
                q = q / p;
            }
        }
    }
}
