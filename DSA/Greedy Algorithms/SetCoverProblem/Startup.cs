using System;
using System.Collections.Generic;
using System.Linq;

namespace SetCoverProblem
{
    public class Startup
    {
        public static void Main()
        {
            var universe = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int numberOfSets = int.Parse(Console.ReadLine());

            var sets = new List<int[]>();
            for (int i = 0; i < numberOfSets; i++)
            {
                var inputSet = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                sets.Add(inputSet);
            }

            var result = new List<int[]>();
            while (0 < universe.Count)
            {
                int setIndex = ChooseSetIndex(universe, sets);
                if (setIndex < 0) break;

                var set = sets[setIndex];
                result.Add(set);
                sets.RemoveAt(setIndex);
                CoverItemInUniverse(universe, set);
            }

            if (universe.Count < 0)
            {
                Console.WriteLine("No solution");
            }

            Console.WriteLine();
            foreach (var set in result)
            {
                Console.WriteLine(string.Join(" ", set));
            }

        }

        private static void CoverItemInUniverse(List<int> universe, int[] set)
        {
            foreach (var item in set)
            {
                universe.Remove(item);
            }
        }

        private static int ChooseSetIndex(List<int> universe, List<int[]> sets)
        {
            int bestIndex = -1;
            int bestNumberOfUncovered = 0;
            for (int i = 0; i < sets.Count; i++)
            {
                var set = sets[i];
                int numberOfUncoveredItems = 0;
                foreach (var item in set)
                {
                    if (universe.Contains(item)) numberOfUncoveredItems++;
                }

                if (bestNumberOfUncovered < numberOfUncoveredItems)
                {
                    bestIndex = i;
                    bestNumberOfUncovered = numberOfUncoveredItems;
                }
            }

            return bestIndex;
        }
    }
}
