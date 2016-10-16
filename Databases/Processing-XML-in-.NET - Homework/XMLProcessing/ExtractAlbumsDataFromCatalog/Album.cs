namespace ExtractAlbumsDataFromCatalog
{
    public class Album : IAlbum
    {
        public Album(string author, string name)
        {
            this.Author = author;
            this.Name = name;
        }

        public string Author { get; private set; }

        public string Name { get; private set; }
    }
}
