// Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console. 
// Find in MSDN how to use System.IO.File.ReadAllText(...). Be sure to catch all possible exceptions and print user-friendly error messages.

using System;
using System.IO;
using System.Text;

class Program
{
    private static string ReadAllFile(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException("File path cannot be null!");
        }

        if (!File.Exists(path))
        {
            throw new FileNotFoundException("File path not found!");
        }

        string text = File.ReadAllText(path);
        return text;
    }

    static void Main()
    {
        try
        {
            string path = Console.ReadLine();
            string text = ReadAllFile(path);
            Console.WriteLine(text);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (IOException)
        {
            Console.WriteLine("Error occured opeing file!");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine(ex);
        }
    }
}
