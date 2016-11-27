using System;
using System.Text;

namespace Pattern
{
    class MainClass
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string currentFigure = "urd";
            var result = new StringBuilder(currentFigure);
            for (int i = 2; i <= n; i++)
            {
                result.Clear();
                result.Append(RotateRight(currentFigure));
                result.Append("u");
                result.Append(currentFigure);
                result.Append("r");
                result.Append(currentFigure);
                result.Append("d");
                result.Append(RotateLeft(currentFigure));

                currentFigure = result.ToString();
            }

            Console.WriteLine(result.ToString());

            //// comment before submitting
            //Svg.WriteToFile("output.svg", figure);
        }

        private static string RotateRight(string figure)
        {
            var result = new StringBuilder();
            for (int i = figure.Length - 1; i >= 0; i--)
            {
                char dir = figure[i];
                result.Append(GetNext(dir));
            }

            return result.ToString();
        }

        private static string RotateLeft(string figure)
        {
            var result = new StringBuilder();
            for (int i = figure.Length - 1; i >= 0; i--)
            {
                char dir = figure[i];
                result.Append(GetPrev(dir));
            }

            return result.ToString();
        }

        private static char GetNext(char dir)
        {
            switch (dir)
            {
                case 'u': return 'l';
                case 'r': return 'u';
                case 'd': return 'r';
                case 'l': return 'd';
                default:
                    throw new InvalidOperationException("Invalid operation");
            }
        }

        private static char GetPrev(char dir)
        {
            switch (dir)
            {
                case 'd': return 'l';
                case 'r': return 'd';
                case 'u': return 'r';
                case 'l': return 'u';
                default:
                    throw new InvalidOperationException("Invalid operation");
            }
        }
    }
}
