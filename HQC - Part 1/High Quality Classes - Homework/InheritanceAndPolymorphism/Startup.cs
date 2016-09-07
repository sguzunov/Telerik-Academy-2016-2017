namespace InheritanceAndPolymorphism
{
    using System;
    using InheritanceAndPolymorphism.Contracts;

    public class Startup
    {
        public static void Main()
        {
            ILocalCourse localCourseWithoutStudents = new LocalCourse("HQC", "Marto Vesheff", "Ultimate");
            Console.WriteLine(localCourseWithoutStudents);

            ILocalCourse localCourseWithStudents = new LocalCourse("HQC", "Marto Vesheff", "Ultimate");
            localCourseWithStudents.AddStudent(new Student("Pesho"));
            localCourseWithStudents.AddStudent(new Student("Mariika"));

            Console.WriteLine(localCourseWithStudents);

            Console.WriteLine();

            IOffsiteCourse offsiteCourseWithoutStudents = new OffsiteCourse("PHP", "Ivan Kolev", "Horror");
            Console.WriteLine(offsiteCourseWithoutStudents);

            IOffsiteCourse offsiteCourseWithStudents = new OffsiteCourse("PHP", "Ivan Kolev", "Horror");
            offsiteCourseWithStudents.AddStudent(new Student("Milena"));
            offsiteCourseWithStudents.AddStudent(new Student("Todor"));

            Console.WriteLine(offsiteCourseWithStudents);
        }
    }
}
