using System;
using System.Collections.Generic;
using System.Linq;

namespace BestLecturesSchedule
{
    public class Startup
    {
        public static void Main()
        {
            Console.Write("Number of Lectures: ");
            int n = int.Parse(Console.ReadLine());

            var lectures = ReadLectures(n);
            var orderedByEndTime = lectures.OrderBy(x => x.EndTime).ToList();

            Console.WriteLine();
            while (orderedByEndTime.Count > 0)
            {
                var nextLecture = orderedByEndTime[0];

                // Remove overlapping
                for (int i = 1; i < orderedByEndTime.Count; i++)
                {
                    if (nextLecture.OverlapWith(orderedByEndTime[i]))
                    {
                        orderedByEndTime.Remove(orderedByEndTime[i]);
                        i--;
                    }
                }

                Console.WriteLine($"{nextLecture.Name}: {nextLecture.StartTime} -> {nextLecture.EndTime}");

                orderedByEndTime.Remove(nextLecture);
            }
        }

        private static LinkedList<Lecture> ReadLectures(int n)
        {
            var lectures = new LinkedList<Lecture>();
            for (int i = 0; i < n; i++)
            {
                var lectureTokens = Console.ReadLine().Split(new char[] { ' ', '-', ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var lecture = new Lecture()
                {
                    Name = lectureTokens[0],
                    StartTime = int.Parse(lectureTokens[1]),
                    EndTime = int.Parse(lectureTokens[2])
                };

                lectures.AddLast(lecture);
            }

            return lectures;
        }
    }

    public class Lecture
    {
        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public string Name { get; set; }

        public bool OverlapWith(Lecture other)
        {
            return this.StartTime >= other.StartTime && this.StartTime < other.EndTime ||
                this.EndTime >= other.StartTime && this.EndTime < other.EndTime ||
                other.StartTime >= this.StartTime && other.StartTime < this.EndTime ||
                other.EndTime >= this.StartTime && other.EndTime < this.EndTime;
        }
    }
}
