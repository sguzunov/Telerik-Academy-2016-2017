namespace GenericsCollection
{
    using System;
    using VersionAttributeImplementation;

    public class Test
    {
        static void Main()
        {
            // Uncomment to check the tests.

            var genericList = new GenericList<int>();

            // Adding 100 items to GenericList should has count == 100.
            for (int i = 1; i <= 100; i++)
            {
                genericList.Add(i);
            }

            //Console.WriteLine("Has 100 elements: {0}", genericList.Count == 100);

            // Removing 100 elements from GenericList beginning should has count == 0.
            //for (int i = 0; i < 100; i++)
            //{
            //    genericList.RemoveAt(0);
            //}

            // Removing 100 elements from GenericList end should has count == 0.
            //for (int i = 0; i < 100; i++)
            //{
            //    genericList.RemoveAt(genericList.Count - 1);
            //}

            //Console.WriteLine("Removing 100 elements should has 0 elements: {0}", genericList.Count == 0);

            // When cleared list should has 0 elements.
            //genericList.Clear();
            //Console.WriteLine("Cleared list has no elements: {0}", genericList.Count == 0);

            // Element 1000 should not be found.
            //Console.WriteLine("Has element {0}: {1}", 1000, genericList.Find(1000));

            // Element 1 should be found.
            //Console.WriteLine("Has element {0}: {1}", 1, genericList.Find(1));

            // Element 100 should be MAX.
            //Console.WriteLine("Element {0} should be MAX: {1}", 1000, genericList.Max() == 100);

            // Element 1 should be MIN.
            //Console.WriteLine("Element {0} should be MIN: {1}", 1, genericList.Min() == 1);

            // Inserting element 1000 at position 1 should change the value and increase count
            //genericList.InsertAt(1, 1000);
            //Console.WriteLine("Inserting element {0} at position {1} should change its value to {2}", 1000, 1, 1000, genericList[1]);
            //Console.WriteLine("Changed count: {0}", genericList.Count);

            // Test ToString();
            //Console.WriteLine(genericList);

            // Test Version Attribute.
            //Type genericListType = typeof(GenericList<>);
            //var allAttributes = genericListType.GetCustomAttributes(true);
            //Console.WriteLine(allAttributes[1]);
        }
    }
}
