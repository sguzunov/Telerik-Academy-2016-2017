namespace CoordinateSystem.Utils
{
    using CoordinateSystem.Serialization;

    public class PathStorage
    {
        public static void SavePath(Path path, IPathSerializer serializer, string directory)
        {
            serializer.Serialize(path, directory);
        }

        public static Path LoadPath(IPathSerializer deSerializer, string directory)
        {
            var path = deSerializer.Deserialize(directory);
            return path;
        }
    }
}
