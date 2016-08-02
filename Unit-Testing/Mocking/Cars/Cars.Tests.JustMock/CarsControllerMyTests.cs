namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;

    using Contracts;
    using Controllers;
    using Models;

    [TestFixture]
    public class CarsControllerMyTests
    {
        private readonly ICollection<Car> fakeData = new List<Car>
        {
            new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
            new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
            new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
            new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
        };
        private readonly Car ValidCar = new Car()
        {
            Id = 10,
            Make = "Audi",
            Model = "RS",
            Year = 2010
        };

        [Test]
        public void Index_ShouldNotReturnNull()
        {
            var carsRepoMock = new Mock<ICarsRepository>();
            var controller = new CarsController(carsRepoMock.Object);

            Assert.IsNotNull(controller.Index());
        }

        [Test]
        public void Index_ShouldReturnAllData()
        {
            var carsRepoMock = new Mock<ICarsRepository>();
            carsRepoMock.Setup(x => x.All()).Returns(fakeData);
            var controller = new CarsController(carsRepoMock.Object);

            var result = (ICollection<Car>)controller.Index().Model;

            Assert.AreEqual(fakeData.Count, result.Count);
        }

        [Test]
        public void Add_NullCarPassed_ThrowsException()
        {
            var carsRepoMock = new Mock<ICarsRepository>();
            var controller = new CarsController(carsRepoMock.Object);

            Assert.Throws<ArgumentNullException>(() => controller.Add(null));
        }

        [Test]
        public void Add_CarMakeIsNull_ThrowsException()
        {
            var carsRepoMock = new Mock<ICarsRepository>();
            var controller = new CarsController(carsRepoMock.Object);
            var car = new Car()
            {
                Id = 10,
                Make = null,
                Model = "RS",
                Year = 2010
            };

            Assert.Throws<ArgumentNullException>(() => controller.Add(car));
        }

        [Test]
        public void Add_CarMakeIsEmpty_ThrowsException()
        {
            var carsRepoMock = new Mock<ICarsRepository>();
            var controller = new CarsController(carsRepoMock.Object);
            var car = new Car()
            {
                Id = 10,
                Make = "",
                Model = "RS",
                Year = 2010
            };

            Assert.Throws<ArgumentNullException>(() => controller.Add(car));
        }

        [Test]
        public void Add_CarModelIsNull_ThrowsException()
        {
            var carsRepoMock = new Mock<ICarsRepository>();
            var controller = new CarsController(carsRepoMock.Object);
            var car = new Car()
            {
                Id = 10,
                Make = "Audi",
                Model = null,
                Year = 2010
            };

            Assert.Throws<ArgumentNullException>(() => controller.Add(car));
        }
        [Test]
        public void Add_CarModelIsEmpty_ThrowsException()
        {
            var carsRepoMock = new Mock<ICarsRepository>();
            var controller = new CarsController(carsRepoMock.Object);
            var car = new Car()
            {
                Id = 10,
                Make = "Audi",
                Model = "",
                Year = 2010
            };

            Assert.Throws<ArgumentNullException>(() => controller.Add(car));
        }

        [Test]
        public void Add_ValidCarPassed_ShouldAddToRepository()
        {
            var carsRepoMock = new Mock<ICarsRepository>();
            carsRepoMock.Setup(x => x.Add(It.IsAny<Car>())).Verifiable();
            var controller = new CarsController(carsRepoMock.Object);
            carsRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(ValidCar);

            controller.Add(ValidCar);

            carsRepoMock.Verify(x => x.Add(ValidCar));
        }

        [Test]
        public void Detail_CarNotFoundById_ThrowsException()
        {
            var carsRepoMock = new Mock<ICarsRepository>();
            var controller = new CarsController(carsRepoMock.Object);
            Car car = null;
            carsRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(car);

            Assert.Throws<ArgumentNullException>(() => controller.Details(1));
        }

        [Test]
        public void Detail_ValidId_ShouldReturnAView()
        {
            var carsRepoMock = new Mock<ICarsRepository>();
            var controller = new CarsController(carsRepoMock.Object);
            carsRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(ValidCar);

            var model = (Car)controller.Details(1);
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Id, ValidCar.Id);
            Assert.AreEqual(model.Make, ValidCar.Make);
            Assert.AreEqual(model.Model, ValidCar.Model);
            Assert.AreEqual(model.Year, ValidCar.Year);
        }
        
                
    }
}
