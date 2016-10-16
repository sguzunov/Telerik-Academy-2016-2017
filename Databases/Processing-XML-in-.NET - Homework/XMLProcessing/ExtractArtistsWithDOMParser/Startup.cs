using System;
using System.Collections.Generic;
using System.Xml;

namespace ExtractArtistsWithDOMParser
{
    public class Startup
    {
        private static void Main()
        {
            string catalogUrl = "../../Files/catalog.xml";

            var artists = GetAllArtists(catalogUrl);
            PrintArtists(artists);
        }

        private static void PrintArtists(IDictionary<string, int> artists)
        {
            foreach (var artist in artists)
            {
                Console.WriteLine($"{artist.Key} has {artist.Value} songs");
            }
        }

        private static IDictionary<string, int> GetAllArtists(string fileUrl)
        {
            XmlDocument document = new XmlDocument();
            document.Load(fileUrl);

            var catalogNode = document.DocumentElement;

            var artists = new Dictionary<string, int>();
            var albumsNodes = catalogNode.ChildNodes;
            foreach (XmlNode album in albumsNodes)
            {
                string artistName = album["artist"].InnerText;
                if (!artists.ContainsKey(artistName))
                {
                    artists.Add(artistName, 0);
                }

                artists[artistName]++;
            }

            return artists;
        }
    }
}
