using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedPolishNotation
{
    public class Startup
    {
        public static void Main()
        {
            string expression = Console.ReadLine();
            var splittedExpression = expression.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var numbers = new Stack<int>();

            foreach (var item in splittedExpression)
            {
                int number;
                if (int.TryParse(item, out number))
                {
                    numbers.Push(number);
                }
                else
                {
                    int right = numbers.Pop();
                    int left = numbers.Pop();
                    int result = Calculate(item, left, right);

                    numbers.Push(result);
                }
            }

            Console.WriteLine(numbers.Pop());
        }

        private static int Calculate(string op, int left, int right)
        {
            if (op == "+") return left + right;
            else if (op == "-") return left - right;
            else if (op == "*") return left * right;
            else if (op == "/") return left / right;
            else if (op == "|") return left | right;
            else if (op == "&") return left & right;
            else return left ^ right;
        }
    }
}
