namespace CoordinateSystem
{
    using System;
    using System.Collections.Generic;

    using CoordinateSystem.Serialization;
    using Utils;

    public class Test
    {
        static void Main()
        {
            Console.WriteLine("Enter a directory (use an xml file extension for saving object): ");
            string dir = Console.ReadLine();

            var points = new List<Point3D>()
            {
                new Point3D(1, 1, 1),
                new Point3D(2, 2, 2),
                new Point3D(3, 3, 3)
            };
            var path = new Path(points);

            var serializer = new XmlPathSerializer();
            PathStorage.SavePath(path, serializer, dir);
            Console.WriteLine("Serialized");

            var desPath = PathStorage.LoadPath(serializer, dir);
            Console.WriteLine("Deserialized");

            foreach (var item in desPath.Points)
            {
                Console.WriteLine(item);
            }
        }
    }
}
