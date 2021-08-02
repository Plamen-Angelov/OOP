namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private string name = "Aqua";
        private int capacity = 15;

        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium(name, capacity);

            Fish fish1 = new Fish("fish1");
            Fish fish2 = new Fish("fish2");
            Fish fish3 = new Fish("fish3");
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
        }

        [Test]
        public void FishCtorWorksCorrectly()
        {
            Fish fish = new Fish("Pesho");

            Assert.That(fish.Name == "Pesho");
            Assert.That(fish.Available == true);
        }

        [TestCase("")]
        [TestCase(null)]
        public void PropNameThrowsExceptionWhenNameIsInvalid(string name)
        {
            int capacity = 15;

            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(name, capacity));
        }

        [Test]
        public void PropCapacityThrowsExceptionWhenValueIsInvalid()
        {
            string name = "Gosho";
            int capacity = -1;

            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium(name, capacity));
        }

        [Test]
        public void CtorCreateInstanceWhithCorrectInput()
        {
            Assert.That(aquarium.Name == name);
            Assert.That(aquarium.Capacity == capacity);
        }

        [Test]
        public void CountReturnTheCorrectNumberOFFishes()
        {
            Fish fish1 = new Fish("fish1");
            Fish fish2 = new Fish("fish2");
            Fish fish3 = new Fish("fish3");

            Assert.That(aquarium.Count, Is.EqualTo(3));
        }

        [Test]
        public void AddThrowsExceptionWhenCapacityIsFull()
        {
            aquarium = new Aquarium("Aqua", 2);
            Fish fish1 = new Fish("fish1");
            Fish fish2 = new Fish("fish2");
            Fish fish3 = new Fish("fish3");

            aquarium.Add(fish1);
            aquarium.Add(fish2);


            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish3));
        }
        
        [TestCase("fish1")]
        [TestCase("fish2")]
        public void RemoveFishRemovesFishWithTheGivenName(string name)
        {
            aquarium.RemoveFish(name);

            Assert.IsTrue(aquarium.Count == 2);
        }

        [Test]
        public void RemoveFishThrowsExceptionWhenThereIsNoFishWhitGivenName()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Pesho"));
        }

        [Test]
        public void SellFishReturnedSoldFishWhenExists()
        {
            Fish fish2 = new Fish("fish2");

            Fish result = aquarium.SellFish(fish2.Name);

            Assert.AreEqual(fish2.Name, result.Name);
        }

        [Test]
        public void SellFishThrowsExceptionWhenFishDoesntExists()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Riba"));
        }

        [Test]
        public void ReportReturnsTheCorectString()
        {
            Fish fish1 = new Fish("fish1");
            Fish fish2 = new Fish("fish2");
            Fish fish3 = new Fish("fish3");
            List<Fish> fishes = new List<Fish>() { fish1, fish2, fish3 };
            string fishNames = string.Join(", ", fishes.Select(f => f.Name));
            string result = $"Fish available at { aquarium.Name}: { fishNames}";

            Assert.AreEqual(result, aquarium.Report());
        }
    }
}
