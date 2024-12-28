using Autokauppa_API.Controllers;
using Autokauppa_DAL.SellerRepository;
using Autokauppa_DAO.Objects;
using Autokauppa_DAO.QueryObjects;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static Autokauppa_DAO.Objects.Result;
using Assert = NUnit.Framework.Assert;

namespace Autokauppa_Tests.Autokauppa_API.Controllers
{
    [TestFixture]
    public class SellerControllerTests
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

        private SellerController Create()
            => new(Get.Object, Post.Object, Put.Object, Delete.Object);

        [TestCase(Status.OK)]
        [TestCase(Status.NoContent)]
        public void ByQuery(Status status)
        {
            var sellerInfo = new QuerySellerInfo("");
            Get.Setup(x => x.ByQuery(sellerInfo)).Returns(new Result(status));

            var controller = Create();
            var result = controller.ByQuery(sellerInfo);
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
        public void AllSellers(Status status)
        {
            Get.Setup(x => x.AllSellers(true)).Returns(new Result(status));

            var controller = Create();
            var result = controller.AllSellers(true);
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
        public void NewSeller(Status status)
        {
            var sellerInfo = new QuerySellerInfo("");
            Post.Setup(x => x.NewSeller(sellerInfo)).Returns(new Result(status));

            var controller = Create();
            var result = controller.NewSeller(sellerInfo);
            Repository.VerifyAll();
            Assert.That(result, Is.Not.Null);

            if (status == Status.OK)
            {
                Assert.That(result, Is.TypeOf<OkResult>());
            }
            else if (status == Status.BadRequest)
            {
                Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
            }
        }

        [TestCase(Status.OK)]
        [TestCase(Status.NoContent)]
        public void UpdateSeller(Status status)
        {
            string sellerId = Guid.NewGuid().ToString();
            var sellerInfo = new QuerySellerInfo("");
            Put.Setup(x => x.UpdateSeller(sellerId, sellerInfo))
                .Returns(new Result(status));

            var controller = Create();
            var result = controller.UpdateSeller(sellerId, sellerInfo);
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
        public void DeleteSellerById(Status status)
        {
            string sellerId = Guid.NewGuid().ToString();
            Delete.Setup(x => x.SellerById(sellerId)).Returns(new Result(status));

            var controller = Create();
            var result = controller.SellerById(sellerId);
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
