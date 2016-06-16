namespace CoordinateSystem.Serialization
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    public class XmlPathSerializer : IPathSerializer
    {
        private const string BullOrEmptyDirectoryErrorMessage = "Directory cannot be null!";
        private const string NullPathErrorMessage = "Path cannot be null!";

        public CoordinateSystem.Path Deserialize(string directory)
        {
            if (string.IsNullOrEmpty(directory))
            {
                throw new ArgumentNullException(BullOrEmptyDirectoryErrorMessage);
            }

            TextReader reader = null;
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(CoordinateSystem.Path));
                reader = new StreamReader(directory);
                object obj = deserializer.Deserialize(reader);
                CoordinateSystem.Path path = (CoordinateSystem.Path)obj;
                return path;
            }
            finally
            {
                reader.Close();
            }
        }

        public void Serialize(CoordinateSystem.Path path, string directory)
        {
            if (string.IsNullOrEmpty(directory))
            {
                throw new ArgumentNullException(BullOrEmptyDirectoryErrorMessage);
            }

            if (path == null)
            {
                throw new ArgumentNullException(NullPathErrorMessage);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(CoordinateSystem.Path));
            using (TextWriter writer = new StreamWriter(directory))
            {
                serializer.Serialize(writer, path);
            }
        }
    }
}
