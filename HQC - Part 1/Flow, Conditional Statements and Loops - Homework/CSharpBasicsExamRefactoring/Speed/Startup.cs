namespace Speed
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());

            int lastSpeed = int.Parse(Console.ReadLine());
            int groupLength = 1;
            int longestGroupLength = 1;
            int sumOfSpeeds = lastSpeed;
            int longestGroupSumOfSpeeds = lastSpeed;

            // Loop to carsCount - 1, because we have already read the first speed.
            for (int i = 0; i < carsCount - 1; i++)
            {
                bool isLastSpeed = i == carsCount - 2 ? true : false;
                int speed = int.Parse(Console.ReadLine());
                if (speed > lastSpeed)
                {
                    groupLength++;
                    sumOfSpeeds += speed;
                    if (!isLastSpeed)
                    {
                        continue;
                    }
                }

                if (groupLength > longestGroupLength)
                {
                    longestGroupLength = groupLength;
                    longestGroupSumOfSpeeds = sumOfSpeeds;
                }
                else if (groupLength == longestGroupLength && longestGroupSumOfSpeeds < sumOfSpeeds)
                {
                    longestGroupSumOfSpeeds = sumOfSpeeds;
                }

                if (lastSpeed > speed)
                {
                    // Current car starts a new group.
                    groupLength = 1;

                    // The new group speed is the first car's speed.
                    sumOfSpeeds = speed;

                    lastSpeed = speed;
                }
            }

            Console.WriteLine(longestGroupSumOfSpeeds);
        }
    }
}
