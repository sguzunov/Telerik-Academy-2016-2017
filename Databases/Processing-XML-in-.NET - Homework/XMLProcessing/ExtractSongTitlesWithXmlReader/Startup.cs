using System;
using System.Collections.Generic;
using System.Xml;

namespace ExtractSongTitlesWithXmlReader
{
    public class Startup
    {
        private static void Main()
        {
            var catalogUrl = "../../Files/catalog.xml";
            var titles = GetAllSongsTitls(catalogUrl);

            Console.WriteLine(string.Join(", ", titles));
        }

        private static IEnumerable<string> GetAllSongsTitls(string filePath)
        {
            var titles = new List<string>();
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                while (reader.Read() != false)
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                    {
                        string title = reader.ReadElementContentAsString();
                        titles.Add(title);
                    }
                }
            }

            return titles;
        }
    }
}
