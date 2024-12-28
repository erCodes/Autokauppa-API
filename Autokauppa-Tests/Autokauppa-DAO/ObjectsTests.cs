using Autokauppa_DAO.Objects;
using Autokauppa_DAO.QueryObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Assert = NUnit.Framework.Assert;

namespace Autokauppa_Tests.Autokauppa_DAO
{
    [TestFixture]
    public class ObjectsTests
    {
        readonly QueryCar QueryCar = new("1", "Toyota", "Yaris",
            "2010", "1.6", "Gasoline", "Front", ["Safety Belt"], ["Cruise Control"]);

        readonly CarUpdateInfo UpdateInfo = new("Ford", "Focus",
            "2020", "2", "Diesel", "Back", ["Emergency Button"], ["Winter Tires"]);

        readonly QuerySellerInfo QuerySellerInfo = new("John Smith", "john.smith(at)autokauppa.com", "12345678");


        [Test]
        public void CreatesCar()
        {
            var car = new Car(QueryCar);

            Assert.That(car, Is.Not.Null);
            Assert.That(car.Id, Is.Not.WhiteSpace);
            Assert.That(car.Brand, Is.EqualTo(QueryCar.Brand));
            Assert.That(car.Model, Is.EqualTo(QueryCar.Model));
            Assert.That(car.ProductionYear, Is.EqualTo(QueryCar.ProductionYear));
            Assert.That(car.EngineSize, Is.EqualTo(QueryCar.EngineSize));
            Assert.That(car.FuelType, Is.EqualTo(QueryCar.FuelType));
            Assert.That(car.Transmission, Is.EqualTo(QueryCar.Transmission));
            Assert.That(car.SafetyFeatures, Is.EqualTo(QueryCar.SafetyFeatures));
            Assert.That(car.OtherFeatures, Is.EqualTo(QueryCar.OtherFeatures));
            Assert.That(car.UpdatedOn, Is.Not.Null);
        }

        [Test]
        public void UpdatesCar()
        {
            var current = new Car(QueryCar);
            var updated = new Car(current, UpdateInfo);

            Assert.That(updated, Is.Not.Null);
            Assert.That(updated.Id, Is.EqualTo(current.Id));
            Assert.That(updated.SellerId, Is.EqualTo(current.SellerId));
            Assert.That(updated.Brand, Is.EqualTo(updated.Brand));
            Assert.That(updated.Model, Is.EqualTo(updated.Model));
            Assert.That(updated.ProductionYear, Is.EqualTo(updated.ProductionYear));
            Assert.That(updated.EngineSize, Is.EqualTo(updated.EngineSize));
            Assert.That(updated.FuelType, Is.EqualTo(updated.FuelType));
            Assert.That(updated.Transmission, Is.EqualTo(updated.Transmission));
            Assert.That(updated.SafetyFeatures, Is.EqualTo(updated.SafetyFeatures));
            Assert.That(updated.OtherFeatures, Is.EqualTo(updated.OtherFeatures));
            Assert.That(updated.UpdatedOn, Is.Not.Null);
        }

        [Test]
        public void CreatesSafetyFeature()
        {
            string name = "Safety Belt";
            var feature = new SafetyFeature(name);

            Assert.That(feature, Is.Not.Null);
            Assert.That(feature.Id, Is.Not.WhiteSpace);
            Assert.That(feature.Name, Is.EqualTo(name));
        }

        [Test]
        public void CreatesOtherFeature()
        {
            string name = "Cruise Control";
            var feature = new OtherFeature(name);

            Assert.That(feature, Is.Not.Null);
            Assert.That(feature.Id, Is.Not.WhiteSpace);
            Assert.That(feature.Name, Is.EqualTo(name));
        }

        [Test]
        public void CreatesSellerInfo()
        {
            var seller = new SellerInfo(QuerySellerInfo);

            Assert.That(seller, Is.Not.Null);
            Assert.That(seller.Id, Is.Not.WhiteSpace);
            Assert.That(seller.Name, Is.EqualTo(QuerySellerInfo.Name));
            Assert.That(seller.Email, Is.EqualTo(QuerySellerInfo.Email));
            Assert.That(seller.PhoneNumber, Is.EqualTo(QuerySellerInfo.PhoneNumber));
            Assert.That(seller.SoldCars, Is.Empty);
        }

        [Test]
        public void UpdatesSellerInfo()
        {
            var current = new SellerInfo()
            {
                Id = "123",
                Name = "Patrick Smith",
                Email = "patrick.smith(at)autokauppa.com",
                PhoneNumber = "00000000",
                SoldCars =
                [
                    new(QueryCar)
                ]
            };

            var updated = new SellerInfo(current, QuerySellerInfo);

            Assert.That(updated, Is.Not.Null);
            Assert.That(updated.Id, Is.EqualTo(current.Id));
            Assert.That(updated.Name, Is.EqualTo(QuerySellerInfo.Name));
            Assert.That(updated.Email, Is.EqualTo(QuerySellerInfo.Email));
            Assert.That(updated.PhoneNumber, Is.EqualTo(QuerySellerInfo.PhoneNumber));
            Assert.That(updated.SoldCars, Is.Not.Empty);
        }
    }
}
