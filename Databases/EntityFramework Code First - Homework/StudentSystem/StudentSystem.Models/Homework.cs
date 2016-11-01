using System;

namespace StudentSystem.Models
{
    public class Homework
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime? TimeSent { get; set; }

        public int? StudentId { get; set; }

        public Student Student { get; set; }

        public int? CourseId { get; set; }

        public Course Course { get; set; }
    }
}
