using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passwords
{
    public class Startup
    {
        private static int total = 0;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string relations = Console.ReadLine();
            int k = int.Parse(Console.ReadLine());

            int[] password = new int[n];
            Next(0, n, k, password, relations.ToCharArray());
        }

        private static void Next(int index, int n, int k, int[] password, char[] relations)
        {
            if (n <= index)
            {
                total++;
                if (total == k)
                {
                    Console.WriteLine(string.Join("", password));
                    Environment.Exit(0);
                }

                return;
            }

            if (index == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    password[index] = i;
                    Next(index + 1, n, k, password, relations);
                }
            }
            else
            {
                char rel = relations[index - 1];
                if (rel == '>')
                {
                    if (password[index - 1] != 0)
                    {
                        password[index] = 0;
                        Next(index + 1, n, k, password, relations);
                        for (int i = password[index - 1] + 1; i < 10; i++)
                        {
                            password[index] = i;
                            Next(index + 1, n, k, password, relations);
                        }
                    }
                }
                else if (rel == '<')
                {
                    int end = password[index - 1];
                    if (password[index - 1] == 0)
                    {
                        end = 10;
                    }

                    for (int i = 1; i < end; i++)
                    {
                        password[index] = i;
                        Next(index + 1, n, k, password, relations);
                    }
                }
                else
                {
                    password[index] = password[index - 1];
                    Next(index + 1, n, k, password, relations);
                }
            }
        }
    }
}
