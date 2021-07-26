using NUnit.Framework;
using System;

namespace Tests
{
    using CarManager;
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("Make", "Model", 5, 70);
        }

        [Test]
        [TestCase("", "model", 5, 55)]
        [TestCase(null, "model", 5, 55)]
        [TestCase("Make", "", 5, 55)]
        [TestCase("Make", null, 5, 55)]
        [TestCase("Make", "Model", -5, 55)]
        [TestCase("Make", "Model", 0, 55)]
        [TestCase("Make", "Model", 5, -55)]
        [TestCase("Make", "Model", 5, 0)]
        public void Ctor_ThrowArgumentException(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Ctor_CreatCarWithValidParameters()
        {
            string make = "WV";
            string model = "Passat";
            double fuelConsumption = 6.5;
            double fuelCapacity = 70;

            car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.Make == make);
            Assert.That(car.Model == model);
            Assert.That(car.FuelConsumption == fuelConsumption);
            Assert.That(car.FuelCapacity == fuelCapacity);
            Assert.That(car.FuelAmount == 0);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void Refuel_ThrowExeptionWhenRefuelQuantityIsInvalid(double refuelQuantity)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(refuelQuantity));
        }

        [Test]
        public void Refuel_RefuelWithPozitiveQuantityLessThanCapacity()
        {
            double refuelQuantity = 30;
            car.Refuel(refuelQuantity);

            Assert.That(car.FuelAmount == refuelQuantity);
        }

        [Test]
        [TestCase(70)]
        [TestCase(80)]
        public void Refuel_RefuelWhenRefuelQuantityIsPozitive(double refuelQuantity)
        {
            car.Refuel(refuelQuantity);

            Assert.That(car.FuelAmount == car.FuelCapacity);

        }

        [Test]
        public void Drive_ThrowExceptionWhenFuelAmountInNotEnough()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(30));
        }

        [Test]
        [TestCase(225)]
        [TestCase(1000)]
        public void Drive_ValidDistance(double distance)
        {
            double refuelQuantity = 50;
            car.Refuel(refuelQuantity);

            double fuelNeeded = distance / 100 * car.FuelConsumption;
            double fuelInTank = car.FuelAmount - fuelNeeded;
            car.Drive(distance);

            Assert.That(car.FuelAmount == fuelInTank);
        }
    }
}