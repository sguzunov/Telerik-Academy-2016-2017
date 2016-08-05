namespace Cosmetics.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using NUnit.Framework;
    using NUnit.Framework.Internal;

    using Common;
    using Contracts;
    using Engine;
    using Mocks;
    using Moq;

    [TestFixture]
    public class CosmeticsEngineTests
    {
        [Test]
        public void Start_InvalidCommandIsRead_ShouldThrows()
        {
            var factoryMock = CreateFactoryMock();
            var cartMock = CreateShoppingCartMock();
            var engine = new CosmeticsEngine(factoryMock.Object, cartMock.Object);
            string command = "command   ";

            Console.SetIn(new StringReader(command));
            Assert.Throws<ArgumentNullException>(() => engine.Start());
        }

        [Test]
        public void Start_CreateCategoryCommand_ShouldAddToCategoriesSet()
        {
            var factoryMock = CreateFactoryMock();
            var cartMock = CreateShoppingCartMock();
            factoryMock.Setup(x => x.CreateCategory(It.IsAny<string>())).Returns(It.IsAny<ICategory>());
            var engineFake = new EngineFake(factoryMock.Object, cartMock.Object);
            string command = "CreateCategory ForMale";

            Console.SetIn(new StringReader(command));
            engineFake.Start();

            Assert.AreEqual(1, engineFake.Categories.Count);
        }

        [Test]
        public void Start_AddToCategoryCommand_ShouldAddSelectedProductToRespectiveCategory()
        {
            var factoryMock = CreateFactoryMock();
            var cartMock = CreateShoppingCartMock();
            var categoryFake = new Mock<ICategory>();
            categoryFake.Setup(x => x.AddCosmetics(It.IsAny<IProduct>())).Verifiable();
            var engineFake = new EngineFake(factoryMock.Object, cartMock.Object);
            engineFake.Categories.Add("ForMale", categoryFake.Object);
            engineFake.Products.Add("White+", It.IsAny<IProduct>());
            string command = "AddToCategory ForMale White+";

            Console.SetIn(new StringReader(command));
            engineFake.Start();

            categoryFake.Verify(x => x.AddCosmetics(It.IsAny<IProduct>()));
        }

        [Test]
        public void Start_RemoveFromCategoryCommand_ShouldAddSelectedProductToRespectiveCategory()
        {
            var factoryMock = CreateFactoryMock();
            var cartMock = CreateShoppingCartMock();
            var categoryFake = new Mock<ICategory>();
            categoryFake.Setup(x => x.RemoveCosmetics(It.IsAny<IProduct>())).Verifiable();
            var engineFake = new EngineFake(factoryMock.Object, cartMock.Object);
            engineFake.Categories.Add("ForMale", categoryFake.Object);
            engineFake.Products.Add("White+", It.IsAny<IProduct>());
            string command = "RemoveFromCategory ForMale White+";

            Console.SetIn(new StringReader(command));
            engineFake.Start();

            categoryFake.Verify(x => x.RemoveCosmetics(It.IsAny<IProduct>()));
        }

        [Test]
        public void Start_ShowCategory_CategoryShouldPrintItself()
        {
            var factoryMock = CreateFactoryMock();
            var cartMock = CreateShoppingCartMock();
            var categoryMock = new Mock<ICategory>();
            categoryMock.Setup(x => x.Print()).Verifiable();
            var mockEngine = new EngineFake(factoryMock.Object, cartMock.Object);
            mockEngine.Categories.Add("ForMale", categoryMock.Object);
            string command = "ShowCategory ForMale";

            Console.SetIn(new StringReader(command));
            mockEngine.Start();

            categoryMock.Verify(x => x.Print(), Times.AtLeastOnce);
        }

        [Test]
        public void Start_CreateShampoo_AddsTheProduct()
        {
            var factoryMock = CreateFactoryMock();
            var cartMock = CreateShoppingCartMock();
            factoryMock.Setup(x => x.CreateShampoo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(),
                It.IsAny<GenderType>(), It.IsAny<uint>(), It.IsAny<UsageType>()));
            var mockEngine = new EngineFake(factoryMock.Object, cartMock.Object);
            string command = "CreateShampoo Cool Nivea 0,50 men 500 everyday";

            Console.SetIn(new StringReader(command));
            mockEngine.Start();

            Assert.AreEqual(1, mockEngine.Products.Count);
            Assert.IsTrue(mockEngine.Products.ContainsKey("Cool"));
        }

        [Test]
        public void Start_CreateToothPaste_AddsTheProduct()
        {
            var factoryMock = CreateFactoryMock();
            var cartMock = CreateShoppingCartMock();
            factoryMock.Setup(x => x.CreateToothpaste(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(),
                It.IsAny<GenderType>(), It.IsAny<IList<string>>()));
            var mockEngine = new EngineFake(factoryMock.Object, cartMock.Object);
            string command = "CreateToothpaste White+++ C 15,50 men fluor,bqla,golqma";

            Console.SetIn(new StringReader(command));
            mockEngine.Start();

            Assert.AreEqual(1, mockEngine.Products.Count);
            Assert.IsTrue(mockEngine.Products.ContainsKey("White+++"));
        }

        [Test]
        public void Start_AddToShoppingCart_ShouldCallShoppingCatAddProduct()
        {
            var factoryMock = CreateFactoryMock();
            var cartMock = CreateShoppingCartMock();
            cartMock.Setup(x => x.AddProduct(It.IsAny<IProduct>())).Verifiable();
            var mockEngine = new EngineFake(factoryMock.Object, cartMock.Object);
            mockEngine.Products.Add("White+", It.IsAny<IProduct>());
            string command = "AddToShoppingCart White+";

            Console.SetIn(new StringReader(command));
            mockEngine.Start();

            cartMock.Verify(x => x.AddProduct(It.IsAny<IProduct>()));
        }

        [Test]
        public void Start_RemoveFromShoppingCart_ShouldCallShoppingCartRemoveProduct()
        {
            var factoryMock = CreateFactoryMock();
            var cartMock = CreateShoppingCartMock();
            cartMock.Setup(x => x.ContainsProduct(It.IsAny<IProduct>())).Returns(true);
            cartMock.Setup(x => x.RemoveProduct(It.IsAny<IProduct>())).Verifiable();
            var mockEngine = new EngineFake(factoryMock.Object, cartMock.Object);
            mockEngine.Products.Add("White+", It.IsAny<IProduct>());
            string command = "RemoveFromShoppingCart White+";

            Console.SetIn(new StringReader(command));
            mockEngine.Start();

            cartMock.Verify(x => x.RemoveProduct(It.IsAny<IProduct>()));
        }

        // Factories
        private Mock<ICosmeticsFactory> CreateFactoryMock()
        {
            return new Mock<ICosmeticsFactory>();
        }

        private Mock<IShoppingCart> CreateShoppingCartMock()
        {
            return new Mock<IShoppingCart>();
        }
    }
}
