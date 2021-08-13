using NUnit.Framework;
using TheRace;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver driver;
        private UnitCar car;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
            car = new UnitCar("VW", 100, 2);
            driver = new UnitDriver("Pesho", car);
        }

        [Test]
        public void CounterWorksCorrect()
        {
            Assert.That(raceEntry.Counter == 0);

            raceEntry.AddDriver(driver);
            Assert.That(raceEntry.Counter == 1);
        }

        [Test]
        public void AddDriverThrowsExceptionWhenDriverIsNull()
        {
            UnitDriver testDriver = null;

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(testDriver));
        }

        [Test]
        public void AddDriverThrowsExceptionWhenDriverExists()
        {
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriverWorksCorrectly()
        {
            raceEntry.AddDriver(driver);
            UnitDriver testDriver = new UnitDriver("Gosgo", car);
            raceEntry.AddDriver(testDriver);

            Assert.That(raceEntry.Counter == 2);
        }

        [Test]
        public void CalculateAverageHorsePowerThrowsException()
        {
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerWorksCorrectly()
        {
            UnitCar testCar = new UnitCar("VW", 200, 2);
            UnitDriver testDriver = new UnitDriver("Gosho", testCar);

            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(testDriver);

            Assert.AreEqual(150, raceEntry.CalculateAverageHorsePower());
        }
    }
}