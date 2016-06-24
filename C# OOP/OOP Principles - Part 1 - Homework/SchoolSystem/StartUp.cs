namespace SchoolSystem
{
    using System.Collections.Generic;

    using SchoolSystem.Models;
    using SchoolSystem.Models.Contracts;

    internal class StartUp
    {
        private static void Main()
        {
            var disciplinesDoncho = new List<IDiscipline>()
            {
                new Discipline("C#", 5, 2),
                new Discipline("Objective C", 3, 2),
                new Discipline("JS", 5, 2),
                new Discipline("DB", 5, 2)
            };

            var disciplinesNiki = new List<IDiscipline>()
            {
                new Discipline("C#", 5, 2),
                new Discipline("DSA", 3, 2),
                new Discipline("DB", 5, 2),
                new Discipline("KPK", 5, 2)
            };

            var disciplinesEvlogi = new List<IDiscipline>()
            {
                new Discipline("Java", 5, 2),
                new Discipline("JS", 3, 2),
                new Discipline("HTML", 5, 2),
                new Discipline("CSS", 5, 2)
            };

            var disciplinesKoce = new List<IDiscipline>()
            {
                new Discipline("C#", 5, 2),
                new Discipline("ASP.NET", 3, 2),
                new Discipline("DB", 5, 2)
            };

            var disciplinesCuki = new List<IDiscipline>()
            {
                new Discipline("C++", 5, 2),
                new Discipline("DSA", 4, 1),
                new Discipline("C", 3, 2),
                new Discipline("DB", 5, 2)
            };

            var disciplinesIvan = new List<IDiscipline>()
            {
                new Discipline("JavaScript", 4, 1),
                new Discipline("HTML", 5, 1),
                new Discipline("CSS", 2, 2),
                new Discipline("DB", 5, 2)
            };

            var teacherDoncho = new Teacher("Doncho", "Minkov", disciplinesDoncho);
            var teacherNiki = new Teacher("Niki", "Kostov", disciplinesNiki);
            var teacherEvlogi = new Teacher("Evlogi", "Hristov", disciplinesEvlogi);
            var teacherKoce = new Teacher("Konstantin", "Simeonov", disciplinesKoce);
            var teacherCuki = new Teacher("Kristian", "Cuklev", disciplinesCuki);
            var teacherIvan = new Teacher("Ivan", "Kolev", disciplinesIvan);

            var season2015 = new SchoolClass("2015", teacherDoncho, teacherNiki, teacherEvlogi);
            var season2016 = new SchoolClass("2016", teacherKoce, teacherCuki, teacherIvan);

            var academy = new TelerikAcademy();
            academy.AddClass(season2015);
            academy.AddClass(season2016);
        }
    }
}
