namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;

    using Contracts;
    using Controllers;
    using Models;
    using System.Linq;

    [TestFixture]
    public class CarsControllerMyTests
    {
        private readonly ICollection<Car> fakeData = new List<Car>
        {
            new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
            new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
            new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
            new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 }
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

            Assert.AreEqual(this.fakeData.Count, result.Count);
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
            int validId = 1;

            var model = (Car)controller.Details(validId).Model;
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Id, ValidCar.Id);
            Assert.AreEqual(model.Make, ValidCar.Make);
            Assert.AreEqual(model.Model, ValidCar.Model);
            Assert.AreEqual(model.Year, ValidCar.Year);
        }

        [Test]
        public void Search_ValidCondition_ShouldReturnAViewWithData()
        {
            var carsRepoMock = new Mock<ICarsRepository>();
            var controller = new CarsController(carsRepoMock.Object);
            ICollection<Car> data = fakeData.Where(d => d.Make == "Audi").ToList();
            carsRepoMock.Setup(x => x.Search(It.IsAny<string>())).Returns(data);

            var foundData = (ICollection<Car>)controller.Search("condition").Model;
            Assert.AreEqual(data.Count, foundData.Count);
            Assert.AreEqual(1, foundData.First().Id);
            Assert.AreEqual("Audi", foundData.First().Make);
            Assert.AreEqual("A5", foundData.First().Model);
            Assert.AreEqual(2005, foundData.First().Year);
        }

        [Test]
        public void Sort_InvalidParameterPassed_ThrowsException()
        {
            var carsRepoMock = new Mock<ICarsRepository>();
            var controller = new CarsController(carsRepoMock.Object);

            Assert.Throws<ArgumentException>(() => controller.Sort("some param"));
        }

        [Test]
        public void Sort_ByMake_ReturnsAViewWithAllData()
        {
            var carsRepoMock = new Mock<ICarsRepository>();
            var controller = new CarsController(carsRepoMock.Object);
            carsRepoMock.Setup(x => x.SortedByMake()).Returns(fakeData);

            var result = controller.Sort("make").Model as ICollection<Car>;

            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public void Sort_ByYear_ReturnsAViewWithAllData()
        {
            var carsRepoMock = new Mock<ICarsRepository>();
            var controller = new CarsController(carsRepoMock.Object);
            carsRepoMock.Setup(x => x.SortedByYear()).Returns(fakeData);

            var result = controller.Sort("year").Model as ICollection<Car>;

            Assert.AreEqual(4, result.Count);
        }
    }
}
