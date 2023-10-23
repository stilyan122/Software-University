namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void TestingCarConstructor()
        {
            string make = "TestMake";
            string model = "TestModel";
            double fuelConsumption = 10;
            double fuelCapacity = 100;
            Car car = new Car(make,model,fuelConsumption,fuelCapacity);
            Assert.That(car.Make == make
                && car.Model == model
                && car.FuelConsumption == fuelConsumption
                && car.FuelCapacity == fuelCapacity
                && car.FuelAmount == 0);
        }
        [Test]
        public void TestingCarConstructorWithInvalidMake()
        {
            string make1 = null;
            string make2 = string.Empty;
            string model = "TestModel";
            double fuelConsumption = 10;
            double fuelCapacity = 100;
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make1, model, fuelConsumption, fuelCapacity);
            }
            );
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make2, model, fuelConsumption, fuelCapacity);
            }
            );
        }
        [Test]
        public void TestingCarConstructorWithInvalidModel()
        {
            string make = "TestMake";
            string model1 = null;
            string model2 = string.Empty;
            double fuelConsumption = 10;
            double fuelCapacity = 100;
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model1, fuelConsumption, fuelCapacity);
            }
            );
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model2, fuelConsumption, fuelCapacity);
            }
            );
        }
        [Test]
        public void TestingCarConstructorWithInvalidFuelConsumption()
        {
            string make = "TestMake";
            string model = "TestModel";
            double fuelConsumption1 = 0;
            double fuelConsumption2 = -200;
            double fuelCapacity = 100;
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption1, fuelCapacity);
            }
            );
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption2, fuelCapacity);
            }
            );
        }
        [Test]
        public void TestingCarConstructorWithInvalidFuelCapacity()
        {
            string make = "TestMake";
            string model = "TestModel";
            double fuelConsumption = 10;
            double fuelCapacity1 = 0;
            double fuelCapacity2 = -200;
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity1);
            }
            );
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity2);
            }
            );
        }
        [Test]
        public void TestingCarRefuelMethodIfItWorks()
        {
            string make = "TestMake";
            string model = "TestModel";
            double fuelConsumption = 10;
            double fuelCapacity = 100;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(10);
            Assert.AreEqual(10, car.FuelAmount);
            car.Refuel(1000000);
            Assert.AreEqual(100, car.FuelAmount);
        }
        [Test]
        public void TestingCarRefuelMethodThrows()
        {
            string make = "TestMake";
            string model = "TestModel";
            double fuelConsumption = 10;
            double fuelCapacity = 100;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            }
            );
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(-100);
            }
            );
        }
        [Test]
        public void TestingCarDriveMethodIfItWorks()
        {
            string make = "TestMake";
            string model = "TestModel";
            double fuelConsumption = 10;
            double fuelCapacity = 100;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(100);
            car.Drive(100);
            Assert.AreEqual(90,car.FuelAmount);
        }
        [Test]
        public void TestingCarDriveMethodThrows()
        {
            string make = "TestMake";
            string model = "TestModel";
            double fuelConsumption = 10;
            double fuelCapacity = 100;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(100);
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(1000000);
            }
            );
        }
    }
}