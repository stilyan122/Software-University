namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void TestingWarriorConstructorIfItWorksAsIntended()
        {
            string name = "TestWarrior";
            int hp = 100;
            int damage = 50;
            Warrior warrior = new Warrior(name, damage, hp);
            Assert.That(warrior.Name == name && warrior.Damage == damage && warrior.HP == hp);
        }
        [Test]
        public void TestingWarriorNameThrows()
        {
            string name1 = null;
            string name2 = " ";
            string name3 = String.Empty;
            int hp = 100;
            int damage = 50;
            Assert.Throws<ArgumentException>
                (() =>
                {
                    Warrior warrior = new Warrior(name1, damage, hp);
                });
            Assert.Throws<ArgumentException>
                (() =>
                {
                    Warrior warrior = new Warrior(name2, damage, hp);
                });
            Assert.Throws<ArgumentException>
                (() =>
                {
                    Warrior warrior = new Warrior(name3, damage, hp);
                });
        }
        [Test]
        public void TestingWarriorDamageThrows()
        {
            string name = "TestName";
            int hp = 100;
            int damage1 = 0;
            int damage2 = -100;
            Assert.Throws<ArgumentException>
                (() =>
                {
                    Warrior warrior = new Warrior(name, damage1, hp);
                });
            Assert.Throws<ArgumentException>
                (() =>
                {
                    Warrior warrior = new Warrior(name, damage2, hp);
                });
        }
        [Test]
        public void TestingWarriorHPThrows()
        {
            string name = "TestName";
            int hp = -100;
            int damage = 100;
            Assert.Throws<ArgumentException>
                (() =>
                {
                    Warrior warrior = new Warrior(name, damage, hp);
                });
        }
        [Test]
        public void TestingAttackMethodIfItWorks()
        {
            Warrior attack = new Warrior("Test", 60, 100);
            Warrior defense = new Warrior("Test2", 50, 50);
            attack.Attack(defense);
            Assert.AreEqual(attack.HP, 50);
            Assert.AreEqual(defense.HP, 0);
        }
        [Test]
        public void TestingAttackMethodIfItWorksWith0()
        {
            Warrior attack = new Warrior("Test", 60, 100);
            Warrior defense = new Warrior("Test2", 50, 1000);
            attack.Attack(defense);
            Assert.AreEqual(defense.HP, 940);
        }
        [Test]
        public void TestingAttackMethodThrowsWithInvalidAttackingHP()
        {
            string name = "TestName";
            int hp = 30;
            int damage = 50;
            string name2 = "TestName2";
            int hp2 = 200;
            int damage2 = 100;
            Warrior attackingWarrior1 = new Warrior(name, damage, hp);
            Warrior defenseWarrior1 = new Warrior(name2, damage2, hp2);
            Assert.Throws<InvalidOperationException>
                (() =>
                {
                    attackingWarrior1.Attack(defenseWarrior1);
                });
            string name3 = "TestName3";
            int hp3 = 29;
            int damage3 = 150000;
            Warrior attackingWarrior2 = new Warrior(name3, damage3, hp3);
            Assert.Throws<InvalidOperationException>
                (() =>
                {
                    attackingWarrior2.Attack(defenseWarrior1);
                });
        }
        [Test]
        public void TestingAttackMethodThrowsWithInvalidDefenseHP()
        {
            string name = "TestName";
            int hp = 30;
            int damage = 50;
            string name2 = "TestName2";
            int hp2 = 200;
            int damage2 = 100;
            Warrior attackingWarrior = new Warrior(name, damage, hp2);
            Warrior defenseWarrior1 = new Warrior(name2, damage2, hp);
            Assert.Throws<InvalidOperationException>
                (() =>
                {
                    attackingWarrior.Attack(defenseWarrior1);
                });
            string name3 = "TestName";
            int hp3 = 29;
            int damage3 = 150;
            Warrior defenseWarrior2 = new Warrior(name3, damage3, hp3);
            Assert.Throws<InvalidOperationException>
                (() =>
                {
                    attackingWarrior.Attack(defenseWarrior2);
                });
        }
        [Test]
        public void TestingAttackMethodWithTooStrongEnemy()
        {
            string name = "TestName";
            int hp = 40;
            int damage = 50;
            string name2 = "TestName2";
            int hp2 = 200;
            int damage2 = 100;
            Warrior attackingWarrior = new Warrior(name, damage, hp);
            Warrior defenseWarrior = new Warrior(name2, damage2, hp2);
            Assert.Throws<InvalidOperationException>
                (() =>
                {
                    attackingWarrior.Attack(defenseWarrior);
                });
        }
    }
}