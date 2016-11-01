using System.Data.Entity;
using StudentSystem.Models;

namespace StudentSystem.Data.Contracts
{
    public interface IStudentSystemContext
    {
        IDbSet<Student> Students { get; set; }

        IDbSet<Material> Materials { get; set; }

        IDbSet<Homework> Homeworks { get; set; }

        IDbSet<Course> Courses { get; set; }

        int SaveChanges();
    }
}
