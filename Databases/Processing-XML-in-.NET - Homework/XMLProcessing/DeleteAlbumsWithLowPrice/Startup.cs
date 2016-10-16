using System.Globalization;
using System.Threading;
using System.Xml;

namespace DeleteAlbumsWithLowPrice
{
    public class Startup
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string catalogUrl = "../../Files/catalog.xml";

            DeleteAlbumsWithPriceLowerThan(20M, catalogUrl);
        }

        private static void DeleteAlbumsWithPriceLowerThan(decimal price, string filePath)
        {
            var document = new XmlDocument();

            document.Load(filePath);

            var rootNode = document.DocumentElement;
            var albumsNodes = rootNode.ChildNodes;
            foreach (XmlElement album in albumsNodes)
            {
                decimal albumPrice = decimal.Parse(album["price"].InnerText);
                if (albumPrice < price)
                {
                    album.ParentNode.RemoveChild(album);
                }
            }

            document.Save(filePath + ".removed");
        }
    }
}
