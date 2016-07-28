namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SchoolSystem;
    using SchoolSystem.Contracts;

    [TestClass]
    public class CourseTests
    {
        private const string ValidCourseName = "JS UI & DOM";
        private IStudent student = new Student("John", "Snow", 20000);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Course_WhenNameIsEmptyString_Throws()
        {
            string name = "";

            var course = new Course(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Course_WhenNameIsNull_Throws()
        {
            string name = null;

            var course = new Course(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStudent_WhenStudentIsNull_Throws()
        {
            IStudent student = null;
            var course = new Course(ValidCourseName);

            course.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddStudent_MoreThanOnceInACourse_Throws()
        {
            var course = new Course(ValidCourseName);

            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddStudent_MoreThanCapacityOf29_Throws()
        {
            var course = new Course(ValidCourseName);

            for (int i = 0; i < 29; i++)
            {
                course.AddStudent(new Student("John", "Snow", 33333 + 1));
            }

            course.AddStudent(new Student("John", "Snow", 44444));
        }

        [TestMethod]
        public void AddStudent_Exactly29_WorksCorrectly()
        {
            var course = new Course(ValidCourseName);

            try
            {
                for (int i = 0; i < 29; i++)
                {
                    course.AddStudent(new Student("John", "Snow", 33333 + 1));
                }
            }
            catch (InvalidOperationException)
            {
                Assert.Fail("Adding max capacity of students should not throw exception!");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveStudent_WhenStudentIsNull_Throws()
        {
            IStudent student = null;
            var course = new Course(ValidCourseName);

            course.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveStudent_WhenCourseIsEmpty_Throws()
        {
            var course = new Course(ValidCourseName);

            course.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveStudent_WhenSuchStudentDoesKnowAttendTheCourse_ReturnFalse()
        {
            var course = new Course(ValidCourseName);
            var attendingStudent = new Student("John", "Doe", 11111);

            bool actual = course.RemoveStudent(student);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void RemoveStudent_WhenStudentAttendsTheCourse_ReturnsTrue()
        {
            var course = new Course(ValidCourseName);
            course.AddStudent(student);

            bool actual = course.RemoveStudent(student);

            Assert.IsTrue(actual);
        }
    }
}