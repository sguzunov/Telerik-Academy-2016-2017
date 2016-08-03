namespace Cosmetics.Test
{
    using System;
    using NUnit.Framework;

    using Common;

    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfNull_NullIsPassed_ThrowsException()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(null));
        }

        [Test]
        public void CheckIfNull_PassedValueIsNotNull_ShouldNotThrowsException()
        {
            var obj = new object();

            Assert.DoesNotThrow(() => Validator.CheckIfNull(obj));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CheckIfStringIsNullOrEmpty_InvalidString_ThrowsException(string text)
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        [TestCase("s")]
        [TestCase("str")]
        public void CheckIfStringIsNullOrEmpty_ValidString_ShouldNotThrows(string text)
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        [Test]
        public void CheckIfStringLengthIsValid_StringLengthIsLessThanMinValue_ThrowsException()
        {
            string text = "strst";
            int min = 6;
            int max = 10;

            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }

        [Test]
        public void CheckIfStringLengthIsValid_StringLengthIsBiggerThanMaxValue_ThrowsException()
        {
            string text = "strstrs";
            int min = 3;
            int max = 6;

            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }

        [TestCase("strstr", 6, 10)]
        [TestCase("strstrstrs", 6, 10)]
        public void CheckIfStringLengthIsValid_StringLengthIsInRange_ShouldNotThrowsException(string text, int min, int max)
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }
    }
}
