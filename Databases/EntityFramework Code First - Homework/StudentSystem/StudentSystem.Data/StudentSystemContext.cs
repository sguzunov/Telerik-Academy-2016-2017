using System.Data.Entity;
using StudentSystem.Data.Contracts;
using StudentSystem.Models;

namespace StudentSystem.Data
{
    public class StudentSystemContext : DbContext, IStudentSystemContext
    {
        public StudentSystemContext()
            : base("StudentSystemDB")
        {

        }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Material> Materials { get; set; }

        public IDbSet<Student> Students { get; set; }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
