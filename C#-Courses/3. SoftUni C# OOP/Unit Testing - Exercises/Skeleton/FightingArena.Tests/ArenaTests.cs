namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
        }

        [Test]
        public void ConstructorShouldInitializeWarriorsCollection()
        {
            Arena ctorArena = new Arena();

            Assert.IsNotNull(ctorArena.Warriors);
        }

        [Test]
        public void EnrollingNonExistingWarriorShouldSuccess()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);

            this.arena.Enroll(warrior);

            bool isWarriorEnrolled = this.arena.Warriors.Contains(warrior);

            Assert.IsTrue(isWarriorEnrolled);
        }

        [Test]
        public void EnrollingSameWarriorShouldThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);

            this.arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void EnrollingWarriorWithTheSameNameShouldThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);
            Warrior warrior2 = new Warrior("Pesho", 60, 54);

            this.arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior2);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void CountShouldReturnEnrolledWarriorsCount()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);
            Warrior warrior2 = new Warrior("Gosho", 60, 54);

            this.arena.Enroll(warrior);
            this.arena.Enroll(warrior2);

            int expectedCount = 2;
            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void CountShouldReturnZeroWhenNoWarriorsAreEnrolled()
        {
            int expectedCount = 0;
            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void FightShouldThrowException_WithNonExistingAttacker()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);
            Warrior warrior2 = new Warrior("Gosho", 60, 54);

            this.arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(warrior.Name, warrior2.Name);
            }, $"There is no fighter with name {warrior.Name} enrolled for the fights!");
        }

        [Test]
        public void FightShouldThrowException_WithNonExistingDefender()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);
            Warrior warrior2 = new Warrior("Gosho", 60, 54);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(warrior.Name, warrior2.Name);
            }, $"There is no fighter with name {warrior2.Name} enrolled for the fights!");
        }
        [Test]
        public void FightShouldSucceedWhenWarriorsExist()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);
            Warrior warrior2 = new Warrior("Gosho", 35, 100);

            int w1ExpectedHp = warrior.HP - warrior2.Damage;
            int w2ExpectedHp = warrior2.HP - warrior.Damage;

            this.arena.Enroll(warrior);
            this.arena.Enroll(warrior2);

            this.arena.Fight(warrior.Name, warrior2.Name);


            int w1ActualHP = this.arena.Warriors.First(w => w.Name == warrior.Name).HP;
            int w2ActualHP = this.arena.Warriors.First(w => w.Name == warrior2.Name).HP;

            Assert.AreEqual(w1ExpectedHp, w1ActualHP);
            Assert.AreEqual(w2ExpectedHp, w2ActualHP);
        }
    }
}
