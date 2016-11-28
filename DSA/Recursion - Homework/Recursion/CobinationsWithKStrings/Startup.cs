using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobinationsWithKStrings
{
    public class Startup
    {
        public static void Main()
        {
            Console.Write("Enater set of strings separate with spaces: ");
            var set = new string[] { "test", "rock", "fun" }; // Console.ReadLine().Split(new char[' '], StringSplitOptions.RemoveEmptyEntries);

            int k = 2;
            //do
            //{
            //    Console.Write("K = ");
            //    k = int.Parse(Console.ReadLine());
            //} while (k >= set.Length);

            Console.WriteLine();
            GenerateCombinations(0, 0, k, set, new string[k]);
        }

        private static void GenerateCombinations(int index, int start, int k, string[] set, string[] combinations)
        {
            if (k <= index)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = start; i < set.Length; i++)
            {
                combinations[index] = set[i];
                GenerateCombinations(index + 1, i + 1, k, set, combinations);
            }
        }
    }
}
