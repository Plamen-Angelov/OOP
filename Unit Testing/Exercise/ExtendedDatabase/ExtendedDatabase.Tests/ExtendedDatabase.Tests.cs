using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void Ctor_AddPersons()
        {
            ExtendedDatabase.Person[] persons = new ExtendedDatabase.Person[5];

            for (int i = 0; i < persons.Length; i++)
            {
                ExtendedDatabase.Person person = new ExtendedDatabase.Person(i, $"Name{i}");
                persons[i] = person;
            }

            database = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.That(database.Count == 5);
        }

        [Test]
        public void Ctor_ThrowExceptionWhenCapacityExceeded()
        {
            ExtendedDatabase.Person[] persons = new ExtendedDatabase.Person[17];
            for (int i = 0; i < persons.Length; i++)
            {
                ExtendedDatabase.Person person = new ExtendedDatabase.Person(i, $"Name{i}");
                persons[i] = person;
            }

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(persons));
        }

        [Test]
        public void Add_ThrowsInvalidOperationExceptionWhenCapacityExceeded()
        {
            int n = 16;

            for (int i = 0; i < n; i++)
            {
                ExtendedDatabase.Person person = new ExtendedDatabase.Person(i, $"Name{i}");
                database.Add(person);
            }

            ExtendedDatabase.Person person17 = new ExtendedDatabase.Person(17, "Pesho");

            Assert.Throws<InvalidOperationException>(() => database.Add(person17));
        }

        [Test]
        public void Add_ThroesInvalidOperationExceptionWhenUserNameExcists()
        {
            ExtendedDatabase.Person person = new ExtendedDatabase.Person(456, "Pesho");
            database.Add(person);

            ExtendedDatabase.Person person2 = new ExtendedDatabase.Person(477, "Pesho");

            Assert.Throws<InvalidOperationException>(() => database.Add(person2));
        }

        [Test]
        public void Add_ThroesInvalidOperationExceptionWhenIDExcists()
        {
            ExtendedDatabase.Person person = new ExtendedDatabase.Person(456, "Pesho");
            database.Add(person);

            ExtendedDatabase.Person person2 = new ExtendedDatabase.Person(456, "Gosho");

            Assert.Throws<InvalidOperationException>(() => database.Add(person2));
        }

        [Test]
        public void Add_AddingPersonAndCountIncrease()
        {
            int firstCount = database.Count;
            ExtendedDatabase.Person person = new ExtendedDatabase.Person(456, "Pesho");
            database.Add(person);
            int secondCount = database.Count;

            Assert.That((firstCount + 1) == secondCount);
        }

        [Test]
        public void Remove_ThrowsInvalidOperationExceptionWhenDBIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_DecreaseCountWhenRemovePerson()
        {
            ExtendedDatabase.Person[] persons = new ExtendedDatabase.Person[5];

            for (int i = 0; i < persons.Length; i++)
            {
                ExtendedDatabase.Person person = new ExtendedDatabase.Person(i, $"Name{i}");
                database.Add(person);
            }

            database.Remove();

            Assert.That(database.Count == 4);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsername_ThrowsArgumentNullExceptionWhenUserNameIsInvalid(string name)
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(name));
        }

        [Test]
        public void FindByUsername_ThrowsExceptionWhenWhenUserNameDoesntExist()
        {
            database.Add(new ExtendedDatabase.Person(12, "Pesho"));
            database.Add(new ExtendedDatabase.Person(165, "Gosho"));

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Misho"));
        }

        [Test]
        public void FindByUsername_ReturnsPersonWhenUsernameIsValid()
        {
            ExtendedDatabase.Person person1 = new ExtendedDatabase.Person(12, "Pesho");
            ExtendedDatabase.Person person2 = new ExtendedDatabase.Person(165, "Gosho");
            database.Add(person1);
            database.Add(person2);

            ExtendedDatabase.Person person = database.FindByUsername("Gosho");

            Assert.That(person2, Is.EqualTo(person));
        }

        [Test]
        public void FindByID_ThrowsExceptionWhenIDIsInvadid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-56));
        }

        [Test]
        public void FindByID_ThrowsExceptionWhenIDDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(100));
        }

        [Test]
        public void FindByID_ReturnPerson()
        {
            ExtendedDatabase.Person person1 = new ExtendedDatabase.Person(12, "Pesho");
            ExtendedDatabase.Person person2 = new ExtendedDatabase.Person(165, "Gosho");
            database.Add(person1);
            database.Add(person2);

            ExtendedDatabase.Person person = database.FindById(165);

            Assert.That(person2, Is.EqualTo(person));
        }
    }
}