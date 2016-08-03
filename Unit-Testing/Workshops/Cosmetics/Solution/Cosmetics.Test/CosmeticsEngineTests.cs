namespace Cosmetics.Test
{
    using System;
    using System.IO;
    using Engine;
    using Moq;
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using Contracts;
    using Mocks;
    using Products;
    using Common;
    using System.Collections.Generic;
    using MSTest = Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestFixture]
    public class CosmeticsEngineTests
    {
        private Mock<ICosmeticsFactory> factoryMock;
        private Mock<IShoppingCart> cartMock;

        [SetUp]
        public void TestsIni()
        {
            factoryMock = new Mock<ICosmeticsFactory>();
            cartMock = new Mock<IShoppingCart>();
        }

        [Test]
        public void Start_InvalidCommandIsRead_ShouldThrows()
        {
            string command = "command   ";
            var engine = new CosmeticsEngine(factoryMock.Object, cartMock.Object);

            Console.SetIn(new StringReader(command));
            Assert.Throws<ArgumentNullException>(() => engine.Start());
        }

        [Test]
        public void Start_CreateCategoryRead_ShouldAddToCategoriesSet()
        {
            factoryMock.Setup(x => x.CreateCategory(It.IsAny<string>())).Returns(It.IsAny<ICategory>());
            var engine = new EngineMock(factoryMock.Object, cartMock.Object);
            string command = "CreateCategory ForMale";

            Console.SetIn(new StringReader(command));
            engine.Start();

            Assert.AreEqual(1, engine.Categories.Count);
        }

        [Test]
        public void Start_AddToCategory_ShouldAddAProductToTheRespectiveCategory()
        {
            string categoryName = "ForMale";
            string shampooName = "Cool";
            string command = "AddToCategory ForMale Cool";
            var category = new Category(categoryName);
            var shampoo = new Shampoo(shampooName, "Brand", 50M, GenderType.Men, 50, UsageType.EveryDay);
            var engine = new EngineMock(factoryMock.Object, cartMock.Object);
            engine.Categories.Add(categoryName, category);
            engine.Products.Add(shampooName, shampoo);

            Console.SetIn(new StringReader(command));
            engine.Start();
            MSTest.PrivateObject privateCategory =
                new MSTest.PrivateObject(engine.Categories[categoryName]);
            var products = (IList<IProduct>)privateCategory.GetField("products");

            Assert.AreEqual(1, products.Count);
        }

        [Test]
        public void Start_RemoveFromCategory_ShouldRemoveAProductToTheRespectiveCategory()
        {
            string categoryName = "ForMale";
            string shampooName = "Cool";
            string command = "RemoveFromCategory ForMale Cool";
            var category = new Category(categoryName);
            var shampoo = new Shampoo(shampooName, "Brand", 50M, GenderType.Men, 50, UsageType.EveryDay);
            var engine = new EngineMock(factoryMock.Object, cartMock.Object);
            engine.Categories.Add(categoryName, category);
            engine.Products.Add(shampooName, shampoo);

            Console.SetIn(new StringReader(command));
            engine.Start();
            MSTest.PrivateObject privateCategory =
                new MSTest.PrivateObject(engine.Categories[categoryName]);
            var products = (IList<IProduct>)privateCategory.GetField("products");

            Assert.AreEqual(0, products.Count);
        }

        [Test]
        public void Start_ShowCategory_CategorySouldPrintItself()
        {
            var engine = new EngineMock(factoryMock.Object, cartMock.Object);
        }
    }
}
