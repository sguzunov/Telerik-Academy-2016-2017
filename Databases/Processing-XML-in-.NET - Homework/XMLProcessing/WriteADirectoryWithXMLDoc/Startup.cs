using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WriteADirectoryWithXMLDoc
{
    public class Startup
    {
        private static void Main()
        {
            using (XmlTextWriter writer = new XmlTextWriter())
            {

            }
        }

        private static XElement WriteDirectoryToXMl(string directoryPath)
        {

        }

        private static string ExtractNameFromPath(string path)
        {
            var pathSplitted = path.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            string name = pathSplitted[pathSplitted.Length - 1];

            return name;
        }
    }
}
