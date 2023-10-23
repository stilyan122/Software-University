using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void TestingIfDummyLosesHealthWhenAttacked()
        {
            Dummy dummy = new Dummy(10,20);
            dummy.TakeAttack(1);
            Assert.AreEqual(9, dummy.Health);
        }
        [Test]
        public void TestingIfDummyThrowsExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, 10);
            Assert.Throws<InvalidOperationException>(()=> 
            {
                dummy.TakeAttack(1);
            });
        }
        [Test]
        public void TestingIfDeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 10);
            int XP = dummy.GiveExperience();
            Assert.AreEqual(XP, 10);
        }
        [Test]
        public void TestingIfAliveDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(1, 10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                int XP = dummy.GiveExperience();
            });
        }
    }
}