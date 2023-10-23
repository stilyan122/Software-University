namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void TestingConstructorOfDatabase()
        {
            int[] array =
            {1,2,3,4,5,6,7,8,9
            ,10,11,12,13,14,15,16};
            Database database = new Database(array);
            int count = database.Count;
            Assert.AreEqual(array.Length, count);
        }
        [Test]
        public void TestingInicializationOfDatabaseWithLowerThat16Elements()
        {
            int[] array =
            {1,2,3,4,5,6,7,8,9
            ,10,11,12,13,14,15,16,17};
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(array);
            }
            );
        }
        [Test]
        public void TestingIfAddingToDatabaseWorks()
        {
            int[] array =
           {1,2,3,4,5,6,7,8,9
            ,10,11,12,13,14,15,16};
            Database database = new Database(array);
            database.Remove();
            database.Add(16);
            Assert.AreEqual(database.Count,16);                               
        }
        [Test]
        public void TestingIfAddingToDatabaseWithBiggerCountThrows()
        {
            int[] array =
           {1,2,3,4,5,6,7,8,9
            ,10,11,12,13,14,15,16};
            Database database = new Database(array);
            Assert.Throws<InvalidOperationException>
                (() =>
                {
                    database.Add(18);
                });
        }
        [Test]
        public void TestingIfRemovingAnElementFromEmptyDatabaseThrows()
        {
            int[] array = new int[0];
            Database database = new Database(array);
            Assert.Throws<InvalidOperationException>(()=>
            {
                database.Remove();
            });
        }
        [Test]
        public void TestingIfFetchMethodReturnsArray()
        {
            int[] array =
            {1,2,3,4,5,6,7,8,9
            ,10,11,12,13,14,15,16};
            int[] arrayCheck =
            {1,2,3,4,5,6,7,8,9
            ,10,11,12,13,14,15,16};
            Database database = new Database(array);
            Assert.AreEqual(database.Fetch(), arrayCheck); 
        }
    }
}
