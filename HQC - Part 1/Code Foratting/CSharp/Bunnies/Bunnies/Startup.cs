namespace Bunnies
{
    using System.Collections.Generic;
    using System.IO;

    using Contracts;

    public class Bunnies
    {
        public static void Main()
        {
            IEnumerable<IBunny> bunnies = Bunnies.CreateBunnies();

            IWriter consoleWriter = new ConsoleWriter();
            foreach (var bunny in bunnies)
            {
                bunny.Introduce(consoleWriter);
            }

            var bunniesFilePath = @"..\..\bunnies.txt";
            using (var streamWriter = new StreamWriter(bunniesFilePath))
            {
                foreach (var bunny in bunnies)
                {
                    streamWriter.WriteLine(bunny.ToString());
                }
            }
        }

        private static IEnumerable<IBunny> CreateBunnies()
        {
            var bunnies = new List<IBunny>
            {
                new Bunny
                {
                    Name = "Leonid",
                    Age = 1,
                    FurType = FurType.NotFluffy
                },
                new Bunny
                {
                    Name = "Rasputin",
                    Age = 2,
                    FurType = FurType.ALittleFluffy
                },
                new Bunny
                {
                    Name = "Tiberii",
                    Age = 3,
                    FurType = FurType.ALittleFluffy
                },
                new Bunny
                {
                    Name = "Neron",
                    Age = 1,
                    FurType = FurType.ALittleFluffy
                },
                new Bunny
                {
                    Name = "Klavdii",
                    Age = 3,
                    FurType = FurType.Fluffy
                },
                new Bunny
                {
                    Name = "Vespasian",
                    Age = 3,
                    FurType = FurType.Fluffy
                },
                new Bunny
                {
                    Name = "Domician",
                    Age = 4,
                    FurType = FurType.FluffyToTheLimit
                },
                new Bunny
                {
                    Name = "Tit",
                    Age = 2,
                    FurType = FurType.FluffyToTheLimit
                }
            };

            return bunnies;
        }
    }
}
