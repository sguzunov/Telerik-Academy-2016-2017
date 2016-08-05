namespace Cosmetics.UnitTests
{
    using System;
    using NUnit.Framework;

    using Cosmetics.Engine;
    using Common;
    using Products;
    using System.Collections.Generic;
    using Contracts;

    [TestFixture]
    public class CosmeticsFactoryTests
    {
        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_InvalidName_ThrowsException(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name, "Cool", 20M, GenderType.Men, 50, UsageType.EveryDay));
        }

        public void CreateShampoo_NameLessThanThree_ThrowsException()
        {
            var factory = new CosmeticsFactory();
            string name = "Ac";

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(name, "Cool", 20M, GenderType.Men, 50, UsageType.EveryDay));
        }

        public void CreateShampoo_NameLessBiggerTen_ThrowsException()
        {
            var factory = new CosmeticsFactory();
            string name = "ActiveActive";

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(name, "Cool", 20M, GenderType.Men, 50, UsageType.EveryDay));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_InvalidBrand_ThrowsException(string brand)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo("Nivea", brand, 20M, GenderType.Men, 50, UsageType.EveryDay));
        }

        public void CreateShampoo_BrandLessThanTwo_ThrowsException()
        {
            var factory = new CosmeticsFactory();
            string brand = "B";

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo("Nivea", brand, 20M, GenderType.Men, 50, UsageType.EveryDay));
        }

        public void CreateShampoo_BrandBiggerThanTen_ThrowsException()
        {
            var factory = new CosmeticsFactory();
            string brand = "CoolCoolCool";

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo("Nivea", brand, 20M, GenderType.Men, 50, UsageType.EveryDay));
        }

        public void CreateShampoo_ValidParameters_WorksCorrectly()
        {
            var factory = new CosmeticsFactory();

            var shampoo = factory.CreateShampoo("Nivea", "Cool", 20M, GenderType.Men, 50, UsageType.EveryDay);
            Assert.IsInstanceOf(typeof(Shampoo), shampoo.GetType());
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateCategory_InvalidName_ThrowsException(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateCategory(name));
        }

        [Test]
        public void CreateCategory_NameLessThanTwo_ThrowsException()
        {
            var factory = new CosmeticsFactory();
            string name = "F";

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateCategory(name));
        }

        [Test]
        public void CreateCategory_NameBiggerThan15_ThrowsException()
        {
            var factory = new CosmeticsFactory();
            string name = "ForMaleForMaleForMaleForMaleForMaleForMale";

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateCategory(name));
        }

        public void CreateCategory_ValidParameters_WorksCorrectly()
        {
            var factory = new CosmeticsFactory();

            var category = factory.CreateCategory("Nivea");
            Assert.IsInstanceOf(typeof(Shampoo), category.GetType());
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateToothpaste_InvalidName_ThrowsException(string name)
        {
            var factory = new CosmeticsFactory();
            var ingred = new List<string>
            {
                "i1",
                "i2",
                "i3",
                "i4",
                "i5",
            };

            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(name, "Active", 50M, GenderType.Women, ingred));
        }

        [Test]
        public void CreateToothpaste_NameLessThanThree_ThrowsException()
        {
            var factory = new CosmeticsFactory();
            var ingred = new List<string>
            {
                "i1",
                "i2",
                "i3",
                "i4",
                "i5",
            };
            string name = "A";

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(name, "Active", 50M, GenderType.Women, ingred));
        }

        [Test]
        public void CreateToothpaste_NameBiggerThanTen_ThrowsException()
        {
            var factory = new CosmeticsFactory();
            var ingred = new List<string>
            {
                "i1",
                "i2",
                "i3",
                "i4",
                "i5",
            };
            string name = "ActiveActiveActiveActive";

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(name, "Active", 50M, GenderType.Women, ingred));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateThoothpaste_InvalidBrand_ThrowsException(string brand)
        {
            var factory = new CosmeticsFactory();
            var ingred = new List<string>
            {
                "i1",
                "i2",
                "i3",
                "i4",
                "i5",
            };

            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste("Active", brand, 50M, GenderType.Women, ingred));
        }

        [Test]
        public void CreateThoothpaste_BrandLessThanTwo_ThrowsException()
        {
            var factory = new CosmeticsFactory();
            var ingred = new List<string>
            {
                "i1",
                "i2",
                "i3",
                "i4",
                "i5",
            };
            string brand = "C";

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste("Active", brand, 50M, GenderType.Women, ingred));
        }

        [Test]
        public void CreateThoothpaste_BrandBiggerThanTen_ThrowsException()
        {
            var factory = new CosmeticsFactory();
            var ingred = new List<string>
            {
                "i1",
                "i2",
                "i3",
                "i4",
                "i5",
            };
            string brand = "CoolCoolCoolCoolCoolCoolCool";

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste("Active", brand, 50M, GenderType.Women, ingred));
        }

        [Test]
        public void CreateThoothpaste_IngredientsLessThanFour_ThrowsException()
        {
            var factory = new CosmeticsFactory();
            var ingred = new List<string>
            {
                "i1",
                "i2",
                "i3",
            };

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste("Active", "White++", 50M, GenderType.Women, ingred));
        }

        [Test]
        public void CreateThoothpaste_IngredientsMoreThanTwelve_ThrowsException()
        {
            var factory = new CosmeticsFactory();
            var ingred = new List<string>
            {
                "i1",
                "i2",
                "i3",
                "i4",
                "i5",
                "i6",
                "i7",
                "i8",
                "i9",
                "i10",
                "i11",
                "i12",
                "i13"
            };

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste("Active", "White++", 50M, GenderType.Women, ingred));
        }

        [Test]
        public void CreateShoppingCart_ShouldAlwaysReturnANewCart()
        {
            var factory = new CosmeticsFactory();
            var carts = new List<IShoppingCart>();
            bool areAllDifferent = true;
            for (int i = 0; i < 5; i++)
            {
                var cart = factory.CreateShoppingCart();
                if (carts.Contains(cart))
                {
                    areAllDifferent = false;
                }

                carts.Add(cart);
            }

            Assert.IsTrue(areAllDifferent);
        }
    }
}
