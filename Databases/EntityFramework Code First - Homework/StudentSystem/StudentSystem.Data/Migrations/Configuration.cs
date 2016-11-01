using System;
using System.Data.Entity.Migrations;
using StudentSystem.Models;

namespace StudentSystem.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemContext context)
        {
            var peshoStudent = new Student
            {
                FirstName = "Pesho",
                LastName = "Peshev",
                Number = 1,
                Info = new StudentInfo { Birthday = new DateTime(1990, 01, 5) }
            };
            var goshoStudent = new Student
            {
                FirstName = "Gosho",
                LastName = "Goshov",
                Number = 2,
                Info = new StudentInfo { Birthday = new DateTime(1993, 01, 5) }
            };

            peshoStudent.Homeworks.Add(new Homework
            {
                Content = "EF - Homework",
                TimeSent = DateTime.Now
            });
            goshoStudent.Homeworks.Add(new Homework
            {
                Content = "EF - Homework",
                TimeSent = DateTime.Now
            });

            context.Students.AddOrUpdate(peshoStudent);
            context.Students.AddOrUpdate(goshoStudent);

            var dbCourse = new Course
            {
                Name = "Databases",
                Description = "EF, SQL, MySQL, SQLite"
            };

            dbCourse.Students.Add(peshoStudent);
        }
    }
}
