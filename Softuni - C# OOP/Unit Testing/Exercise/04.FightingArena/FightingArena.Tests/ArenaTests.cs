namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void TestingArenaConstructor()
        {
            Arena arena = new Arena();
            Assert.AreEqual(arena.Warriors.Count, 0);
            Assert.IsNotNull(arena.Warriors);
        }
        [Test]
        public void TestingArenaEnrollingMethodIfItWorks()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Test", 10, 100));
            arena.Enroll(new Warrior("Test1", 10, 100));
            arena.Enroll(new Warrior("Test2", 10, 100));
            Assert.AreEqual(arena.Warriors.Count, 3);
        }
        [Test]
        public void TestingArenaEnrollingMethodThrows()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Test", 10, 100));
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(new Warrior("Test", 100, 1000));
            });
        }
        [Test]
        public void TestingArenaFightMethodIfItWorks()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Test1", 40, 1000);
            Warrior warrior2 = new Warrior("Test2", 50, 2000);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            Assert.DoesNotThrow(() =>
            {
                arena.Fight(warrior1.Name, warrior2.Name);
            });
        }
        [Test]
        public void TestingArenaFightMethodThrows1()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Test", 40, 1000);
            Warrior warrior2 = new Warrior("Test2", 50, 2000);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Test", "Fighter");
            });
        }
        [Test]
        public void TestingArenaFightMethodThrows2()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Test", 40, 1000);
            Warrior warrior2 = new Warrior("Test2", 50, 2000);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Fighter", "Test2");
            });
        }
    }
}
