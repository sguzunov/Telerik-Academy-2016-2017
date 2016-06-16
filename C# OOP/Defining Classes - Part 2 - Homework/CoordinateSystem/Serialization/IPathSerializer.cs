namespace CoordinateSystem.Serialization
{
    public interface IPathSerializer
    {
        void Serialize(Path path, string directory);

        Path Deserialize(string directory);
    }
}
