namespace School.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SchoolSystem;

    [TestClass]
    public class StudentTests
    {
        private const string ValidStudentFirstName = "John";
        private const string ValidStudentLastName = "Snow";
        private const int StudentIdInRange = 55555;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentFirstName_WhenPassedEmptyString_Throws()
        {
            string name = "";
            var student = new Student(name, ValidStudentLastName, StudentIdInRange);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentFirstName_WhenPassedNull_Throws()
        {
            string name = null;
            var student = new Student(name, ValidStudentLastName, StudentIdInRange);
        }

        [TestMethod]
        public void StudentFirstName_WhenPassedNonEmptyString_ShouldSetTheValue()
        {
            string expectedFirstName = ValidStudentFirstName;
            var student = new Student(expectedFirstName, ValidStudentLastName, StudentIdInRange);

            string actualFirstName = student.FirstName;

            Assert.AreEqual(expectedFirstName, actualFirstName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentLastName_WhenPassedEmptyString_Throws()
        {
            string name = "";

            var student = new Student(ValidStudentFirstName, name, StudentIdInRange);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentLastName_WhenPassedNull_Throws()
        {
            string name = null;
            var student = new Student(ValidStudentFirstName, name, StudentIdInRange);
        }

        [TestMethod]
        public void StudentLastName_WhenPassedNonEmptyString_ShouldSetTheValue()
        {
            string expectedLastName = ValidStudentFirstName;
            var student = new Student(ValidStudentFirstName, expectedLastName, StudentIdInRange);

            string actualLastName = student.FirstName;

            Assert.AreEqual(expectedLastName, actualLastName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentId_LessThan10000_Throws()
        {
            int invalidId = 10;

            var student = new Student(ValidStudentFirstName, ValidStudentLastName, invalidId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentId_MoreThan99999_Throws()
        {
            int invalidId = 1000000;

            var student = new Student(ValidStudentFirstName, ValidStudentLastName, invalidId);
        }

        [TestMethod]
        public void StudentId_PassedValueIs10000_SetsTheId()
        {
            var expectedId = 10000;
            var student = new Student(ValidStudentFirstName, ValidStudentLastName, expectedId);

            int actualId = student.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [TestMethod]
        public void StudentId_PassedValueIs99999_SetsTheId()
        {
            var expectedId = 99999;
            var student = new Student(ValidStudentFirstName, ValidStudentLastName, expectedId);

            int actualId = student.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [TestMethod]
        public void StudentId_PassedValueIsBetween10000And99999_SetsTheId()
        {
            var expectedId = 55555;
            var student = new Student(ValidStudentFirstName, ValidStudentLastName, expectedId);

            int actualId = student.Id;

            Assert.AreEqual(expectedId, actualId);
        }
    }
}
