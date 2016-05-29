// Write a program that parses an URL address given in the format: [protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.

using System;

class ParseURL
{
    private static string ParseProtocol(string url)
    {
        string protocol = url.Substring(0, url.IndexOf(':'));
        return protocol;
    }

    private static string ParseServerName(string url)
    {
        int serverNameStartIndex = url.IndexOf("//") + "//".Length;
        int serverNameLenght = url.IndexOf('/', serverNameStartIndex) - serverNameStartIndex;
        string serverName = url.Substring(serverNameStartIndex, serverNameLenght);
        return serverName;
    }

    private static string ParseResource(string url, string serverName)
    {
        int serverNameIndex = url.IndexOf(serverName);
        int resourceStartIndex = url.IndexOf('/', serverNameIndex);
        string resource = url.Substring(resourceStartIndex);
        return resource;
    }

    static void Main()
    {
        string url = Console.ReadLine();

        string protocol = ParseProtocol(url);
        string serverName = ParseServerName(url);
        string resource = ParseResource(url, serverName);

        Console.WriteLine("[protocol] = {0}", protocol);
        Console.WriteLine("[server] = {0}", serverName);
        Console.WriteLine("[resource] = {0}", resource);
    }
}
