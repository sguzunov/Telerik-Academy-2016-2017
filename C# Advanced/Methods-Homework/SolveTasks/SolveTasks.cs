using System;
using System.Linq;

class SolveTasks
{
    private static int ReverseDigits(int number)
    {
        char sign = '+';
        if (number < 0)
        {
            sign = '-';
            number *= (-1);
        }

        int reversedNumber = int.Parse(string.Join("", number.ToString().ToArray().Reverse().ToArray()));
        if (sign == '-')
        {
            reversedNumber *= (-1);
        }

        return reversedNumber;
    }

    private static long SumIntegers(int[] numbers)
    {
        long sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        return sum;
    }

    private static double GetAverage(int[] numbers)
    {
        long sum = SumIntegers(numbers);
        double count = numbers.Length;
        double avr = sum / count;
        return avr;
    }

    private static double SolveALineareEquation(int a, int b)
    {
        return -b / (double)a;
    }

    private static void ShowMenu()
    {
        const string ReverseTask = "reverse";
        const string CalculateTask = "calculate";
        const string SolveTask = "solve";
        const string StopTask = "stop";

        while (true)
        {
            Console.WriteLine("Choose a task to perform (\"reverse\" | \"calculate\" | \"solve\") or \"stop\" to exit.");
            ShowTasks();
            string task = Console.ReadLine();
            switch (task)
            {
                case ReverseTask:
                    {
                        Console.WriteLine("Enter a number in range [{0}, {1}]", int.MinValue, int.MaxValue);
                        int number = int.Parse(Console.ReadLine());
                        int reversedNumber = ReverseDigits(number);
                        PrintResult(reversedNumber.ToString());
                        break;
                    }
                case CalculateTask:
                    {
                        Console.WriteLine("Enter a sequence of numbers in range [{0}, {1}] on one line separate by one space.", int.MinValue, int.MaxValue);
                        int[] numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                        double avr = GetAverage(numbers);
                        PrintResult(avr.ToString());
                        break;
                    }
                case SolveTask:
                    {
                        Console.Write("a= ");
                        int a = int.Parse(Console.ReadLine());
                        Console.Write("b= ");
                        int b = int.Parse(Console.ReadLine());
                        double result = SolveALineareEquation(a, b);
                        PrintResult(result.ToString());
                        break;
                    }
                case StopTask:
                    {
                        return;
                    }
                default:
                    {
                        Console.WriteLine("Invalid command!");
                        break;
                    }
            }
        }
    }

    private static void PrintResult(string result)
    {
        Console.WriteLine(result);
    }

    private static void ShowTasks()
    {
        Console.WriteLine("-- Reverses the digits of a number.");
        Console.WriteLine("-- Calculates the average of a sequence of integers.");
        Console.WriteLine("-- Solves a linear equation a * x + b = 0.");
    }

    static void Main()
    {
        ShowMenu();
    }
}
