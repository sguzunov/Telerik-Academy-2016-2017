using System;
using System.IO;
using System.Xml.Linq;

namespace WriteADirectoryToXMLWithXDocument
{
    public class Startup
    {
        private static void Main()
        {

            var directory = WriteDirectoryToXMl(@"..\..\");
            directory.Save(@"..\..\Files\directory.xml");
        }

        private static XElement WriteDirectoryToXMl(string directoryPath)
        {
            XElement dirElement = new XElement("dir");

            string dirName = ExtractNameFromPath(directoryPath);
            XAttribute nameAttr = new XAttribute("name", dirName);
            dirElement.Add(nameAttr);

            var files = Directory.GetFiles(directoryPath);
            foreach (var filePath in files)
            {
                string fileName = ExtractNameFromPath(filePath);
                XElement filElement = new XElement("file", fileName);
                dirElement.Add(filElement);
            }

            var folders = Directory.GetDirectories(directoryPath);
            foreach (var folder in folders)
            {
                dirElement.Add(WriteDirectoryToXMl(folder));
            }

            return dirElement;
        }

        private static string ExtractNameFromPath(string path)
        {
            var pathSplitted = path.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            string name = pathSplitted[pathSplitted.Length - 1];

            return name;
        }
    }
}
