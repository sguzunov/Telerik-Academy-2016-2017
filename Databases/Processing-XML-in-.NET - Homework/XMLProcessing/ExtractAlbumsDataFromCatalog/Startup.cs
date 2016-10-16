using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ExtractAlbumsDataFromCatalog
{
    public class Startup
    {
        private static void Main()
        {
            var dataFromUrl = "../../Files/catalog.xml";
            var albums = ReadAlbumsData(dataFromUrl);

            var dataToUrl = "../../Files/album.xml";
            WriteAlbumsData(dataToUrl, albums);

            Console.WriteLine("Done");
        }

        private static void WriteAlbumsData(string fileUrl, IEnumerable<IAlbum> albums)
        {
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(fileUrl, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 1;
                writer.IndentChar = '\t';
                writer.WriteStartDocument();

                writer.WriteStartElement("albums");
                foreach (var album in albums)
                {
                    WriteAlbum(writer, album);
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static void WriteAlbum(XmlTextWriter writer, IAlbum album)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("name", album.Name);
            writer.WriteElementString("author", album.Author);
            writer.WriteEndElement();
        }

        private static IEnumerable<IAlbum> ReadAlbumsData(string fileUrl)
        {
            var albums = new List<IAlbum>();
            using (XmlReader reader = XmlReader.Create(fileUrl))
            {
                while (reader.Read() != false)
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "album")
                    {
                        string albumName = reader.GetAttribute("name").Trim();
                        reader.ReadToDescendant("artist");
                        string albumAuthor = reader.ReadInnerXml();

                        var album = new Album(albumAuthor, albumName);
                        albums.Add(album);
                    }
                }
            }

            return albums;
        }
    }
}
