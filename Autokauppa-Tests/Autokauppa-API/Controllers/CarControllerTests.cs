using Moq;
using NUnit.Framework; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autokauppa_DAL.CarRepository;
using Autokauppa_DAO.Objects;
using static Autokauppa_DAO.Objects.Result;
using Autokauppa_DAO.QueryObjects;
using Autokauppa_API.Controllers;
using Assert = NUnit.Framework.Assert;
using Microsoft.AspNetCore.Mvc;

namespace Autokauppa_Tests.Autokauppa_API.Controllers
{
    [TestFixture]
    public class CarControllerTests
    {
        MockRepository Repository { get; set; }
        Mock<IGet> Get { get; set; }
        Mock<IPost> Post { get; set; }
        Mock<IPut> Put { get; set; }
        Mock<IDelete> Delete { get; set; }


        [SetUp]
        public void Init()
        {
            Repository = new MockRepository(MockBehavior.Strict);
            Get = Repository.Create<IGet>();
            Post = Repository.Create<IPost>();
            Put = Repository.Create<IPut>();
            Delete = Repository.Create<IDelete>();
        }

        private CarController Create()
            => new(Get.Object, Post.Object, Put.Object, Delete.Object);

        [TestCase(Status.OK)]
        [TestCase(Status.NoContent)]
        public void ByQuery(Status status)
        {
            var query = new Query();
            Get.Setup(x => x.ByQuery(query)).Returns(new Result(status));

            var controller = Create();
            var result = controller.ByQuery(query);
            Repository.VerifyAll();
            Assert.That(result, Is.Not.Null);

            if (status == Status.OK)
            {
                Assert.That(result, Is.TypeOf<OkObjectResult>());
            }
            else if (status == Status.NoContent)
            {
                Assert.That(result, Is.TypeOf<NoContentResult>());
            }
        }

        [TestCase(Status.OK)]
        [TestCase(Status.NoContent)]
        public void ByBrand(Status status)
        {
            string brand = "Toyota";
            Get.Setup(x => x.ByBrand(brand)).Returns(new Result(status));

            var controller = Create();
            var result = controller.ByBrand(brand);
            Repository.VerifyAll();
            Assert.That(result, Is.Not.Null);

            if (status == Status.OK)
            {
                Assert.That(result, Is.TypeOf<OkObjectResult>());
            }
            else if (status == Status.NoContent)
            {
                Assert.That(result, Is.TypeOf<NoContentResult>());
            }
        }

        [TestCase(Status.OK)]
        [TestCase(Status.NoContent)]
        public void ByBrandAndModel(Status status)
        {
            string brand = "Toyota";
            string model = "Corolla";
            Get.Setup(x => x.ByBrandAndModel(brand, model)).Returns(new Result(status));

            var controller = Create();
            var result = controller.ByBrandAndModel(brand, model);
            Repository.VerifyAll();
            Assert.That(result, Is.Not.Null);

            if (status == Status.OK)
            {
                Assert.That(result, Is.TypeOf<OkObjectResult>());
            }
            else if (status == Status.NoContent)
            {
                Assert.That(result, Is.TypeOf<NoContentResult>());
            }
        }

        [TestCase(Status.OK)]
        [TestCase(Status.BadRequest)]
        public void AddNewCar(Status status)
        {
            var queryCar = new QueryCar("", "", "", "", "", "", "", [], []);
            Post.Setup(x => x.NewCar(queryCar)).Returns(new Result(status));

            var controller = Create();
            var result = controller.AddNewCar(queryCar);
            Repository.VerifyAll();
            Assert.That(result, Is.Not.Null);

            if (status == Status.OK)
            {
                Assert.That(result, Is.TypeOf<OkResult>());
            }
            else if (status == Status.BadRequest)
            {
                Assert.That(result, Is.TypeOf<BadRequestResult>());
            }
        }

        [TestCase(Status.OK)]
        [TestCase(Status.NoContent)]
        public void UpdateCar(Status status)
        {
            string carId = Guid.NewGuid().ToString();
            var carUpdateInfo = new CarUpdateInfo();
            Put.Setup(x => x.UpdateCar(carId, carUpdateInfo)).Returns(new Result(status));

            var controller = Create();
            var result = controller.UpdateCar(carId, carUpdateInfo);
            Repository.VerifyAll();
            Assert.That(result, Is.Not.Null);

            if (status == Status.OK)
            {
                Assert.That(result, Is.TypeOf<OkObjectResult>());
            }
            else if (status == Status.NoContent)
            {
                Assert.That(result, Is.TypeOf<NoContentResult>());
            }
        }

        [TestCase(Status.OK)]
        [TestCase(Status.NoContent)]
        public void DeleteCarById(Status status)
        {
            string carId = Guid.NewGuid().ToString();
            Delete.Setup(x => x.CarById(carId)).Returns(new Result(status));

            var controller = Create();
            var result = controller.DeleteCarById(carId);
            Repository.VerifyAll();
            Assert.That(result, Is.Not.Null);

            if (status == Status.OK)
            {
                Assert.That(result, Is.TypeOf<OkResult>());
            }
            else if (status == Status.NoContent)
            {
                Assert.That(result, Is.TypeOf<NoContentResult>());
            }
        }
    }
}
