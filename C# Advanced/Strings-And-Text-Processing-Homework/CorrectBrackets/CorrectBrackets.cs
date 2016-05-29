// Write a program to check if in a given expression the ( and ) brackets are put correctly.

using System;

class CorrectBrackets
{
    private static bool AreBracketsCorrect(string expression)
    {
        int openBrackets = 0;
        int closeBrackets = 0;
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                openBrackets++;
            }
            else if (expression[i] == ')')
            {
                if (closeBrackets + 1 > openBrackets)
                {
                    return false;
                }

                closeBrackets++;
            }
        }

        bool areCorrect = openBrackets == closeBrackets;
        return areCorrect;
    }

    static void Main()
    {
        string expression = Console.ReadLine();

        bool areBracketsCorrect = AreBracketsCorrect(expression);
        if (areBracketsCorrect)
        {
            Console.WriteLine("Correct");
        }
        else
        {
            Console.WriteLine("Incorrect");
        }
    }
}
