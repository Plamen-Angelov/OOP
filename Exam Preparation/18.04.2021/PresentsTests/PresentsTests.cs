namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;
        private Present present;

        [SetUp]
        public void Setup()
        {
            bag = new Bag();
            present = new Present("Present", 3.5);
            bag.Create(present);
        }

        [Test]
        public void CreateThrowsExceptionWhenArgumentIsNull()
        {
            Present present = null;

            Assert.Throws<ArgumentNullException>(() => bag.Create(present));
        }

        [Test]
        public void CreateThrowsExceptionWhenPresentExists()
        {
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void CreateAddPresentWhenDoesntExsists()
        {
            Present newPresent = new Present("Toy", 5);

            Assert.That(bag.Create(newPresent) == "Successfully added present Toy.");
        }

        [Test]
        public void RemoveReturnsTrueWhenPresentExists()
        {
            Assert.That(bag.Remove(present), Is.EqualTo(true));
        }

        [Test]
        public void RemoveReturnsFalseWhenPresentNotExist()
        {
            Present newPresent = new Present("Toy", 5);

            Assert.That(bag.Remove(newPresent), Is.EqualTo(false));
        }

        [Test]
        public void GetPresentReturnsTheCorrectPresent()
        {
            Present newPresent = new Present("Toy", 5);
            bag.Create(newPresent);

            Assert.AreEqual(newPresent, bag.GetPresent("Toy"));
            Assert.AreEqual(present, bag.GetPresent("Present"));
        }

        [Test]
        public void GetPresentWithLeastMagicReturnCorectPresent()
        {
            Present newPresent = new Present("Toy", 3);
            bag.Create(newPresent);

            Assert.That(bag.GetPresentWithLeastMagic, Is.EqualTo(newPresent));
        }

        [Test]
        public void GetPresentsReturnsCorrectCollection()
        {
            List<Present> presents = new List<Present>();
            presents.Add(present);
            Present newPresent = new Present("Toy", 5);
            presents.Add(newPresent);
            IReadOnlyCollection<Present> getPresents = bag.GetPresents();
            int count = 0;

            foreach (var item in getPresents)
            {
                Assert.AreEqual(presents[count], item);
                count++;
            }

            
        }
    }
}
