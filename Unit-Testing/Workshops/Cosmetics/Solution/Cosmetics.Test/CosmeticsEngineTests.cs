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
        public void Start_CorrectCreateCategoryCommandIsPassed_ShouldAddANewCategoryToList()
        {
            // Arrange
            string categoryName = "ForMale";

            var fakeCart = CreateShoppingCartFake();
            var fakeFactory = CreateFactoryFake();
            var fakeCommandProvider = CreateCommandProviderFake();

            var fakeCommand = new Mock<ICommand>();
            var fakeCategory = new Mock<ICategory>();

            fakeCommand.SetupGet(x => x.Name).Returns("CreateCategory");
            fakeCommand.SetupGet(x => x.Parameters).Returns(new List<string> { categoryName });
            fakeCommandProvider.Setup(x => x.ReadCommands()).Returns(new List<ICommand> { fakeCommand.Object });
            fakeCategory.SetupGet(x => x.Name).Returns(categoryName);
            fakeFactory.Setup(x => x.CreateCategory(It.IsAny<string>())).Returns(fakeCategory.Object);

            var fakeEngine = new EngineFake(fakeFactory.Object, fakeCart.Object, fakeCommandProvider.Object);

            // Act
            fakeEngine.Start();

            // Assert
            Assert.AreEqual(1, fakeEngine.Categories.Count);
            Assert.IsTrue(fakeEngine.Categories.ContainsKey(categoryName));
        }

        [Test]
        public void Start_CorrectAddToCategoryCommandIsPassed_ShouldCallCategoryAddCosmeticsMethod()
        {
            string categoryName = "ForMale";
            string productName = "Cool";

            var fakeFactory = CreateFactoryFake();
            var fakeCart = CreateShoppingCartFake();
            var fakeCommandProvier = CreateCommandProviderFake();

            var fakeCommand = new Mock<ICommand>();
            var fakeCategory = new Mock<ICategory>();
            var fakeEngine = new EngineFake(fakeFactory.Object, fakeCart.Object, fakeCommandProvier.Object);

            fakeEngine.Categories.Add(categoryName, fakeCategory.Object);
            fakeEngine.Products.Add(productName, It.IsAny<IProduct>());

            fakeCommand.SetupGet(x => x.Name).Returns("AddToCategory");
            fakeCommand.SetupGet(x => x.Parameters).Returns(new List<string> { categoryName, productName });
            fakeCommandProvier.Setup(x => x.ReadCommands()).Returns(new List<ICommand> { fakeCommand.Object });
            fakeCategory.Setup(x => x.AddCosmetics(It.IsAny<IProduct>())).Verifiable();

            fakeEngine.Start();

            fakeCategory.Verify(x => x.AddCosmetics(It.IsAny<IProduct>()), Times.Once);
        }

        [Test]
        public void Start_CorrectRemoveFromCategoryCommandIsPassed_ShouldCallCategoryRemoveCosmeticsMethod()
        {
            string categoryName = "ForMale";
            string productName = "Cool";

            var fakeFactory = CreateFactoryFake();
            var fakeCart = CreateShoppingCartFake();
            var fakeCommandProvier = CreateCommandProviderFake();

            var fakeCommand = new Mock<ICommand>();
            var fakeCategory = new Mock<ICategory>();
            var fakeEngine = new EngineFake(fakeFactory.Object, fakeCart.Object, fakeCommandProvier.Object);

            fakeEngine.Categories.Add(categoryName, fakeCategory.Object);
            fakeEngine.Products.Add(productName, It.IsAny<IProduct>());

            fakeCommand.SetupGet(x => x.Name).Returns("RemoveFromCategory");
            fakeCommand.SetupGet(x => x.Parameters).Returns(new List<string> { categoryName, productName });
            fakeCommandProvier.Setup(x => x.ReadCommands()).Returns(new List<ICommand> { fakeCommand.Object });
            fakeCategory.Setup(x => x.RemoveCosmetics(It.IsAny<IProduct>())).Verifiable();

            fakeEngine.Start();

            fakeCategory.Verify(x => x.RemoveCosmetics(It.IsAny<IProduct>()), Times.Once);
        }

        [Test]
        public void Start_CorrectShowCategoryCommandIsPassed_ShouldCallTheRespectiveCategoryPrintMethod()
        {
            string categoryName = "ForMale";

            var fakeFactory = CreateFactoryFake();
            var fakeCart = CreateShoppingCartFake();
            var fakeCommandProvier = CreateCommandProviderFake();

            var fakeCommand = new Mock<ICommand>();
            var fakeCategory = new Mock<ICategory>();
            var fakeEngine = new EngineFake(fakeFactory.Object, fakeCart.Object, fakeCommandProvier.Object);

            fakeEngine.Categories.Add(categoryName, fakeCategory.Object);

            fakeCategory.Setup(x => x.Print()).Verifiable();
            fakeCommand.SetupGet(x => x.Name).Returns("ShowCategory");
            fakeCommand.SetupGet(x => x.Parameters).Returns(new List<string> { categoryName });
            fakeCommandProvier.Setup(x => x.ReadCommands()).Returns(new List<ICommand> { fakeCommand.Object });

            fakeEngine.Start();

            fakeCategory.Verify(x => x.Print(), Times.Once);
        }

        [Test]
        public void Start_CorrectCreateShampooCommandIsPassed_ShouldAddANewShampooToList()
        {
            string shampooName = "Cool";

            var fakeFactory = CreateFactoryFake();
            var fakeCart = CreateShoppingCartFake();
            var fakeCommandProvier = CreateCommandProviderFake();

            var fakeCommand = new Mock<ICommand>();
            var fakeShampoo = new Mock<IShampoo>();
            var fakeEngine = new EngineFake(fakeFactory.Object, fakeCart.Object, fakeCommandProvier.Object);

            fakeFactory.Setup(x => x.CreateShampoo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<GenderType>(), It.IsAny<uint>(), It.IsAny<UsageType>()))
                       .Returns(fakeShampoo.Object);

            fakeCommand.SetupGet(x => x.Name).Returns("CreateShampoo");
            fakeCommand.SetupGet(x => x.Parameters).Returns(new List<string> { "Cool", "Nivea", "0,50", "men", "500", "everyday" });
            fakeCommandProvier.Setup(x => x.ReadCommands()).Returns(new List<ICommand> { fakeCommand.Object });

            fakeEngine.Start();

            Assert.AreEqual(1, fakeEngine.Products.Count);
            Assert.IsTrue(fakeEngine.Products.ContainsKey(shampooName));
        }

        [Test]
        public void Start_CorrectCreateToothpasteCommandIsPassed_ShouldAddANewToothpasteToList()
        {
            // Arrange
            string toothpasteName = "White+";

            var fakeFactory = CreateFactoryFake();
            var fakeCart = CreateShoppingCartFake();
            var fakeCommandProvier = CreateCommandProviderFake();

            var fakeCommand = new Mock<ICommand>();
            var fakeToothpaste = new Mock<IToothpaste>();
            var fakeEngine = new EngineFake(fakeFactory.Object, fakeCart.Object, fakeCommandProvier.Object);

            fakeFactory.Setup(x => x.CreateToothpaste(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<GenderType>(), It.IsAny<IList<string>>()))
                       .Returns(fakeToothpaste.Object);

            fakeCommand.SetupGet(x => x.Name).Returns("CreateToothpaste");
            fakeCommand.SetupGet(x => x.Parameters).Returns(new List<string> { "White+", "Colgate", "15,50", "men", "fluor,bqla,golqma" });
            fakeCommandProvier.Setup(x => x.ReadCommands()).Returns(new List<ICommand> { fakeCommand.Object });

            // Act
            fakeEngine.Start();

            // Assert
            Assert.AreEqual(1, fakeEngine.Products.Count);
            Assert.IsTrue(fakeEngine.Products.ContainsKey(toothpasteName));
        }

        [Test]
        public void Start_CorrectAddToShoppingCartCommand_ShouldCallShoppingCartAddProductMethod()
        {
            string productName = "Cool";

            var fakeFactory = CreateFactoryFake();
            var fakeCart = CreateShoppingCartFake();
            var fakeCommandProvier = CreateCommandProviderFake();

            var fakeCommand = new Mock<ICommand>();
            var fakeEngine = new EngineFake(fakeFactory.Object, fakeCart.Object, fakeCommandProvier.Object);

            fakeCommand.SetupGet(x => x.Name).Returns("AddToShoppingCart");
            fakeCommand.SetupGet(x => x.Parameters).Returns(new List<string> { productName });
            fakeCommandProvier.Setup(x => x.ReadCommands()).Returns(new List<ICommand> { fakeCommand.Object });
            fakeCart.Setup(x => x.AddProduct(It.IsAny<IProduct>())).Verifiable();

            fakeEngine.Products.Add(productName, It.IsAny<IProduct>());

            fakeEngine.Start();

            fakeCart.Verify(x => x.AddProduct(It.IsAny<IProduct>()));
        }

        [Test]
        public void Start_CorrectRemoveFromShoppingCartCommand_ShouldCallShoppingCartRemoveProductMethod()
        {
            string productName = "Cool";

            var fakeFactory = CreateFactoryFake();
            var fakeCart = CreateShoppingCartFake();
            var fakeCommandProvier = CreateCommandProviderFake();

            var fakeCommand = new Mock<ICommand>();
            var fakeEngine = new EngineFake(fakeFactory.Object, fakeCart.Object, fakeCommandProvier.Object);

            fakeCommand.SetupGet(x => x.Name).Returns("RemoveFromShoppingCart");
            fakeCommand.SetupGet(x => x.Parameters).Returns(new List<string> { productName });
            fakeCommandProvier.Setup(x => x.ReadCommands()).Returns(new List<ICommand> { fakeCommand.Object });
            fakeCart.Setup(x => x.RemoveProduct(It.IsAny<IProduct>())).Verifiable();
            fakeCart.Setup(x => x.ContainsProduct(It.IsAny<IProduct>())).Returns(true);

            fakeEngine.Products.Add(productName, It.IsAny<IProduct>());

            fakeEngine.Start();

            fakeCart.Verify(x => x.RemoveProduct(It.IsAny<IProduct>()));
        }

        // Factories
        private Mock<ICosmeticsFactory> CreateFactoryFake()
        {
            return new Mock<ICosmeticsFactory>();
        }

        private Mock<IShoppingCart> CreateShoppingCartFake()
        {
            return new Mock<IShoppingCart>();
        }

        private Mock<ICommandProvider> CreateCommandProviderFake()
        {
            return new Mock<ICommandProvider>();
        }
    }
}
