using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Models
{
    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [Index("U_Number", IsUnique = true)]
        public int Number { get; set; }

        public StudentInfo Info { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                var today = DateTime.Now;
                int age = today.Year - this.Info.Birthday.Year;
                if (today.AddYears(-age) < this.Info.Birthday)
                {
                    age--;
                }

                return age;
            }
        }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }
    }
}
