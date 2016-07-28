namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SchoolSystem;
    using SchoolSystem.Contracts;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddCourse_WhenCourseIsNull_Throws()
        {
            ICourse course = null;
            var school = new School();

            school.AddCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddCourse_WhenTheSameCourseIsPassedMoreThanOnce_Throws()
        {
            ICourse course = new Course("JS");
            var school = new School();

            school.AddCourse(course);
            school.AddCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveCourse_WhenCourseIsNull_Throws()
        {
            ICourse course = null;
            var school = new School();

            school.AddCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveCourse_WhenSchoolHasNoCourses_Throws()
        {
            var school = new School();

            school.RemoveCourse(new Course("JS"));
        }

        [TestMethod]
        public void RemoveCourse_WhenSuchACourseDoesNotExistsInList_ReturnsFalse()
        {
            var school = new School();
            var existingCourse = new Course("JS");
            school.AddCourse(existingCourse);

            bool isRemoved = school.RemoveCourse(new Course("C#"));
            Assert.IsFalse(isRemoved);
        }

        [TestMethod]
        public void RemoveCourse_WhenExistingCourseInList_ReturnsTrue()
        {
            var school = new School();
            var existingCourse = new Course("JS");
            school.AddCourse(existingCourse);

            bool isRemoved = school.RemoveCourse(existingCourse);

            Assert.IsTrue(isRemoved);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStudent_WhenStudentIsNull_Throws()
        {
            IStudent student = null;
            var school = new School();

            school.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddStudent_WhenStudentAlreadyExists_Throws()
        {
            IStudent student = new Student("John", "Snow", 55555);
            var school = new School();

            school.AddStudent(student);
            school.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudent_WhenPassedDifferentStudentsWithTheSameId_Throws()
        {
            var school = new School();
            IStudent firstStudent = new Student("John", "Snow", 55555);
            IStudent secondStudent = new Student("John", "Doe", 55555);

            school.AddStudent(firstStudent);
            school.AddStudent(secondStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveStudent_WhenPassedNullStudent_Throws()
        {
            var school = new School();
            IStudent student = null;

            school.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveStudent_WhenSchoolHasNoStudents_Throws()
        {
            var school = new School();
            var student = new Student("John", "Doe", 11111);

            school.RemoveStudent(student);
        }

        [TestMethod]
        public void RemoveStudent_WhenStudentIsMissing_ReturnsFalse()
        {
            var school = new School();
            var existingStudent = new Student("John", "Doe", 11111);
            var nonExistingStudent = new Student("John", "Snow", 22222);
            school.AddStudent(existingStudent);

            bool isRemoved = school.RemoveStudent(nonExistingStudent);

            Assert.IsFalse(isRemoved);
        }

        [TestMethod]
        public void RemoveStudent_WhenStudentExists_ReturnsTrue()
        {
            var school = new School();
            var student = new Student("John", "Snow", 11111);
            school.AddStudent(student);

            var isRemoved = school.RemoveStudent(student);

            Assert.IsTrue(isRemoved);
        }
    }
}