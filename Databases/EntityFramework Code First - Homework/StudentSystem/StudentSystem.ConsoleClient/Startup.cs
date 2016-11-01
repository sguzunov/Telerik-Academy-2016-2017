using System;
using System.Data.Entity;
using System.Linq;

using StudentSystem.Data;
using StudentSystem.Data.Contracts;
using StudentSystem.Data.Migrations;

namespace StudentSystem.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());

            IStudentSystemContext db = new StudentSystemContext();

            Console.WriteLine(db.Students.Count());
        }
    }
}
