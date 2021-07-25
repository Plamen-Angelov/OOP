using NUnit.Framework;


namespace Tests
{
    using System;

    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        [Test]
        public void CtorCreateDatabasewithFiveElements()
        {
            database = new Database(1, 2, 3, 4, 5);

            Assert.That(database.Count == 5);
        }

        [Test]
        public void CtorThrowExceptionWhenCountIsExceeded()
        {
            Assert.Throws<InvalidOperationException>(() => database = 
            new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }

        [Test]
        public void IncrementCountWhenAddIsValid()
        {
            database = new Database(1, 2, 3, 4, 5);
            database.Add(6);

            Assert.That(database.Count == 6);
        }

        [Test]
        public void ThrowExceptionWhenCapacityExceededByAdd()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            
            Assert.That(() => database.Add(17),
                Throws.InvalidOperationException.With.Message
                .EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void DecrementCountWhenRemoveIsValid()
        {
            database = new Database(1, 2, 3, 4, 5);
            database.Remove();

            Assert.That(database.Count == 4);
        }

        [Test]
        public void ThrowExceptionWhenRemoveFromEmptyDB()
        {
            database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchReturnsCopyOfDB()
        {
            database = new Database(1, 2, 3, 4, 5);
            int[] copy = database.Fetch();

            Assert.That(copy, Is.Not.EqualTo(database));
        }

        [Test]
        public void CountReturnsZerroWhenDBIsEmpty()
        {
            database = new Database();

            Assert.That(database.Count == 0);
        }
    }
}