using System;
using System.Collections.Generic;

namespace ColoredBunnies
{
    public class Startup
    {
        public static void Main()
        {
            int numberOfBunnies = int.Parse(Console.ReadLine());

            var answers = new Dictionary<int, int>();
            for (int i = 0; i < numberOfBunnies; i++)
            {
                int answer = int.Parse(Console.ReadLine());
                answer++;
                if (!answers.ContainsKey(answer))
                {
                    answers.Add(answer, 1);
                }
                else
                {
                    answers[answer]++;
                }
            }

            long result = 0L;
            foreach (var item in answers)
            {
                int askedBunnies = item.Value;
                int bunnyAnswer = item.Key;
                int groups = (int)Math.Ceiling(askedBunnies / (double)bunnyAnswer);
                result += (long)(groups * bunnyAnswer);
            }

            Console.WriteLine(result);
        }
    }
}
