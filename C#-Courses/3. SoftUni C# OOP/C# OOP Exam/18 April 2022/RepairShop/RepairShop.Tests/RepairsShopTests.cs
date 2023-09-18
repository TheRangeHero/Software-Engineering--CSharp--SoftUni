using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {

            [Test]
            public void GarageName_ShouldThrowException_WithEmptyAndNullValues()
            {

                Assert.Throws<ArgumentNullException>(() =>
                {

                    var garage = new Garage(null, 10);
                });

                Assert.Throws<ArgumentNullException>(() =>
                {

                    var garage = new Garage(string.Empty, 10);
                });
            }

            [Test]
            public void GarageNamePropertyShouldWorkCorrectly()
            {
                const string garageName = "Test";
                var garage = new Garage("Test", 10);

                Assert.That(garage.Name, Is.EqualTo(garageName));
            }

            [Test]
            public void GarageMechanics_ShouldThrowException_WithNoMEchanics()
            {
                Assert.Throws<ArgumentException>(() =>
                {

                    var garage = new Garage("Test", 0);
                });

                Assert.Throws<ArgumentException>(() =>
                {

                    var garage = new Garage("Test", -5);
                });
            }

            [Test]
            public void GarageMechanics_ShouldWorkCorrectly()
            {
                const int garageMechanics = 10;

                var garage = new Garage("test", 10);

                Assert.That(garage.MechanicsAvailable, Is.EqualTo(garageMechanics));
            }

            [Test]
            public void GarageAddCar_ShouldThrowException_WithNoAvailableMEchanics()
            {
                var garage = new Garage("Test", 1);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car("Opel", 15);

                garage.AddCar(firstCar);
                Assert.Throws<InvalidOperationException>(() =>
                {

                    garage.AddCar(secondCar);
                });
            }

            [Test]
            public void AddCar_ShouldIncrementCorrectCarCount()
            {
                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car("Opel", 15);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);

                Assert.That(garage.CarsInGarage, Is.EqualTo(2));
            }

            [Test]
            public void Garage_FixCar_ShouldThrowException_IfCarModelIsMIssing()
            {
                const string carModel = "Opel";

                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car(carModel, 15);


                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("Opel");

                }, $"The car {carModel} doesn't exists.");
            }

            [Test]
            public void Garage_FixCar_ShouldReturnFixedCarIfExists()
            {
                const string carModel = "Opel";

                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car(carModel, 15);

                garage.AddCar(secondCar);
                var fixedCar = garage.FixCar(carModel);

                Assert.That(fixedCar.IsFixed, Is.True);
                Assert.That(fixedCar.CarModel, Is.EqualTo(carModel));
                Assert.That(fixedCar.NumberOfIssues, Is.EqualTo(0));
            }

            [Test]
            public void Garage_RemoveFixedCar_ShouldThrowException_IfNoCarIsAvailable()
            {
                const string carModel = "Opel";

                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car(carModel, 15);


                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();

                }, $"No fixed cars available.");
            }

            [Test]
            public void Garage_RemoveFixedCar_ShouldRemoveFixedCars()
            {
                const string carModel = "Opel";

                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car(carModel, 15);
                var thirdCar = new Car("BMW", 50);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.AddCar(thirdCar);
                garage.FixCar(carModel);
                var fixedCars = garage.RemoveFixedCar();

                Assert.That(fixedCars, Is.EqualTo(1));
                Assert.That(garage.CarsInGarage, Is.EqualTo(2));
            }

            [Test]
            public void Garage_ReportShouldWorkCorrectly()
            {
                const string carModel = "Opel";

                var garage = new Garage("Test", 3);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car(carModel, 15);
                var thirdCar = new Car("BMW", 50);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.AddCar(thirdCar);
                garage.FixCar(carModel);

                var report = garage.Report();

                Assert.That(report, Is.EqualTo($"There are 2 which are not fixed: Mercedes, BMW."));
            }
        }
    }
}