using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alograms
{
    public class Startup
    {
        public static void Main()
        {
            var words = new List<string>();
            string input = Console.ReadLine();
            while (input != "-1")
            {
                var inputAsArray = input.ToArray();
                Sort(inputAsArray);
                words.Add(string.Join("", inputAsArray));

                input = Console.ReadLine();
            }

            var orderedWords = words.OrderBy(x => x);
            string comparer = "";

            int result = 0;
            foreach (var word in orderedWords)
            {
                if (comparer != word)
                {
                    result++;
                }

                comparer = word;
            }

            Console.WriteLine(result);
        }

        private static void Sort(char[] value)
        {
            for (int i = 1; i < value.Length; i++)
            {
                int j = i;
                while (j > 0 && value[j - 1] > value[j])
                {
                    Swap(value, j, j - 1);
                    j--;
                }
            }
        }

        private static void Swap(char[] value, int from, int to)
        {
            var oldValue = value[from];
            value[from] = value[to];
            value[to] = oldValue;
        }
    }
}
