using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ExtractSongTitlesWithXDocument
{
    public class Startup
    {
        private static void Main()
        {
            string catalogUrl = "../../Files/catalog.xml";
            var titles = GetAllTitles(catalogUrl);

            Console.WriteLine(string.Join(", ", titles));
        }

        private static IEnumerable<string> GetAllTitles(string fileUrl)
        {
            var document = XDocument.Load(fileUrl);

            var songs = document.Descendants("song");
            var titles = from song in songs
                         select song.Element("title").Value;

            return titles;
        }
    }
}
