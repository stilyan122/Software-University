namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void TestingPersonClassConstructor()
        {
            string userName = "TestUsername";
            long id = 1234567890;
            Person person = new Person(id, userName);
            Assert.That(person.UserName == userName && person.Id == id);
        }
        [Test]
        public void TestingDatabaseClassConstructor()
        {
            Person[] people = new Person[16];
            for (int i = 0; i < 16; i++)
            {
                string userName = "TestN" + i;
                long id = i;
                people[i] = new Person(id, userName);
            }
            Database database = new Database(people);
            Assert.AreEqual(database.Count, people.Length);
        }
        [Test]
        public void TestingDatabaseClassConstructorWithMorePeople()
        {
            Person[] people = new Person[17];
            for (int i = 0; i < 17; i++)
            {
                string userName = "TestN" + i;
                long id = i;
                people[i] = new Person(id, userName);
            }
            Assert.Throws<ArgumentException>
                (() => 
                { 
                Database database = new Database(people); 
                });
        }
        [Test]
        public void TestingAddMethodWithMorePeople()
        {
            Person[] people = new Person[16];
            for (int i = 0; i < 16; i++)
            {
                string userName = "TestN" + i;
                long id = i;
                people[i] = new Person(id, userName);
            }
            Database database = new Database(people);
            Person person = new Person(1234567890, "TestUsername");
            Assert.Throws<InvalidOperationException>
                (
                () => database.Add(person)
                );
        }
        [Test]
        public void TestingAddMethodWithTheSameUsername()
        {
            Person[] people = new Person[15];
            for (int i = 0; i < 15; i++)
            {
                string userName = "TestN" + i;
                long id = i;
                people[i] = new Person(id, userName);
            }
            Database database = new Database(people);
            string userNameTest = "TestN1";
            long idTest = 10000;
            Person person = new Person(idTest, userNameTest);
            Assert.Throws<InvalidOperationException>
                (
                () => database.Add(person)
                );
        }
        [Test]
        public void TestingAddMethodWithTheSameId()
        {
            Person[] people = new Person[15];
            for (int i = 0; i < 15; i++)
            {
                string userName = "TestN" + i;
                long id = i;
                people[i] = new Person(id, userName);
            }
            Database database = new Database(people);
            string userNameTest = "TestUsername";
            long idTest = 1;
            Person person = new Person(idTest, userNameTest);
            Assert.Throws<InvalidOperationException>
                (
                () => database.Add(person)
                );
        }
        [Test]
        public void TestingRemoveMethodIfItWorksCorrectly()
        {
            Person[] people = new Person[16];
            for (int i = 0; i < 16; i++)
            {
                string userName = "TestN" + i;
                long id = i;
                people[i] = new Person(id, userName);
            }
            Database database = new Database(people);
            database.Remove();
            Assert.AreEqual(database.Count, 15);
        }
        [Test]
        public void TestingRemoveMethodIfItThrows()
        {
            Person[] people = new Person[0];
            Database database = new Database(people);
            Assert.Throws<InvalidOperationException>
                (
                () => database.Remove()
                );
        }
        [Test]
        public void TestingFindByUsernameMethodIfItWorks()
        {
            Person[] people = new Person[1];
            Person person = new Person(1234567890, "TestUsername");
            people[0] = person;
            Database database = new Database(people);
            Person personToFind = database.FindByUsername("TestUsername");
            Assert.AreEqual(personToFind, person);
        }
        [Test]
        public void TestingFindByUsernameMethodIfItThrows()
        {
            Person[] people = new Person[1];
            Person person = new Person(1234567890, "TestUsername");
            people[0] = person;
            Database database = new Database(people);
            Assert.Throws<ArgumentNullException>
                (
                () => database.FindByUsername(string.Empty)
                );
            Assert.Throws<ArgumentNullException>
               (
               () => database.FindByUsername(null)
               );
            Assert.Throws<InvalidOperationException>
               (
               () => database.FindByUsername("TestUserNameInvalid!")
               );
        }
        [Test]
        public void TestingFindByIdMethodIfItWorks()
        {
            Person[] people = new Person[1];
            Person person = new Person(1234567890, "TestUsername");
            people[0] = person;
            Database database = new Database(people);
            Person personToFind = database.FindById(1234567890);
            Assert.AreEqual(personToFind, person);
        }
        [Test]
        public void TestingFindIdMethodIfItThrows()
        {
            Person[] people = new Person[1];
            Person person = new Person(1234567890, "TestUsername");
            people[0] = person;
            Database database = new Database(people);
            Assert.Throws<ArgumentOutOfRangeException>
               (
               () => database.FindById(-1)
               );
            Assert.Throws<InvalidOperationException>
               (
               () => database.FindById(123456789011112123)
               );
        }
    }
}