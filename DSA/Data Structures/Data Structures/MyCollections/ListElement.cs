namespace MyCollections
{
    public class ListElement<T>
    {
        public ListElement()
        {
        }

        public ListElement(T key)
        {
            this.Key = key;
        }

        public T Key { get; set; }

        public ListElement<T> NextElement { get; set; }
    }
}
