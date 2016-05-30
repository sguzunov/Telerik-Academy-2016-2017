using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

class DownloadFileFromNet
{
    private const string NullStringMessageTemplate = "{0} cannot be null or empty string!";

    private static void DownloadFile(string url, string path)
    {
        if (string.IsNullOrEmpty(url))
        {
            throw new ArgumentException(string.Format(NullStringMessageTemplate, "Url"));
        }

        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentException(string.Format(NullStringMessageTemplate, "Path"));
        }

        using (WebClient client = new WebClient())
        {
            client.DownloadFile(url, path);
        }
    }

    static void Main()
    {
        Console.WriteLine("Enter url: ");
        string url = Console.ReadLine();
        Console.WriteLine("Enter path: ");
        string path = Console.ReadLine();

        try
        {
            DownloadFile(url, path);
        }
        catch (WebException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
    }
}
