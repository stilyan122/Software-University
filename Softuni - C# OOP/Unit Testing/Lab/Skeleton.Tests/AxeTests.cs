using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void TestingIfWeaponLosesDurrability()
        {
            Axe axe = new Axe(1, 10);
            axe.Attack(new Dummy(20, 1));
            Assert.AreEqual(9, axe.DurabilityPoints);
        }
        [Test]
        public void TestingAttackingWithBrockenWeapon()
        {
            Axe axe = new Axe(10,0);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(new Dummy(10, 2));
            });
        }
    }
}