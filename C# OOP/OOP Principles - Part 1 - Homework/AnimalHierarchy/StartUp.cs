namespace AnimalHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    internal class StartUp
    {
        static void Main()
        {
            var animals = new List<Animal>()
            {
                new Frog("Danny", 2, Gender.Male),
                new Frog("Nanny", 7, Gender.Female),
                new Tomcat("Tom", 3),
                new Tomcat("Jerry", 4),
                new Tomcat("Jerry", 5),
                new Kitty("Kitty", 1),
                new Kitty("Zara", 2),
                new Kitty("Andy", 9)
            };

            var groups = animals.GroupBy(a => a.GetType());
            foreach (var group in groups)
            {
                var groupName = group.Key.Name;
                int count = group.Count();
                int sumOfAge = group.Sum(a => a.Age);
                Console.WriteLine(groupName + " " + sumOfAge / (double)count);
            }
        }
    }
}
