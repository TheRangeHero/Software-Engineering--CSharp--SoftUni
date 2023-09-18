namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [SetUp]
        public void SaetUp()
        {

        }


        [Test]
        public void ConstructorShouldInitialize_WarriorName()
        {
            string expectedName = "Pesho";

            Warrior warrior = new Warrior(expectedName, 50, 50);

            string actualName = warrior.Name;
            Assert.AreEqual(expectedName, actualName);
        }
        [Test]
        public void ConstructorShouldInitialize_WarriorDamage()
        {
            int expectedDamage = 50;

            Warrior warrior = new Warrior("Pesho", expectedDamage, 50);

            int actualDamage = warrior.Damage;
            Assert.AreEqual(expectedDamage, actualDamage);
        }
        [Test]
        public void ConstructorShouldInitialize_WarriorHP()
        {
            int expectedHp = 100;

            Warrior warrior = new Warrior("Pesho", 50, expectedHp);

            int actualHP = warrior.HP;
            Assert.AreEqual(expectedHp, actualHP);
        }

        [TestCase("Pesho")]
        [TestCase("W")]
        [TestCase("Very very very very very very long")]
        public void NameSetterShouldSetValueWithValidName(string name)
        {
            Warrior warrior = new Warrior(name, 50, 50);

            string expectedName = name;
            string actualName = warrior.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("      ")]
        public void NameSetterShouldThrowExceptionWithEmptyOrWhiteSpaceName(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 50, 50);
            }, "Name should not be empty or whitespace!");
        }

        [TestCase(50)]
        [TestCase(100000)]
        [TestCase(1)]
        public void DamageSetterShouldSetValueWithValidDamage(int damage)
        {
            Warrior warrior = new Warrior("Pesho", damage, 100);

            int expectedDamage = damage;
            int actualDamage = warrior.Damage;

            Assert.AreEqual(expectedDamage, actualDamage);
        }

        [TestCase(-50)]
        [TestCase(-1)]
        [TestCase(0)]
        public void DamageSetterShouldThrowExcpetionWithZeroOrNegativeDamge(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", damage, 100);
            }, "Damage value should be positive!");
        }

        [TestCase(100)]
        [TestCase(50)]
        [TestCase(1)]
        [TestCase(0)]
        public void HPSetterShouldSetValueWithValidHP(int HP)
        {
            Warrior warrior = new Warrior("Pesho", 50, HP);

            int expcetedHP = HP;
            int actualHP = warrior.HP;

            Assert.AreEqual(expcetedHP, actualHP);
        }

        [TestCase(-50)]
        [TestCase(-1)]
        public void HPSetterShouldThrowExceptionWithNEgativeHP(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 50, hp);
            }, "HP should not be negative!");
        }

        [Test]
        public void Success_AttackingWarriorNo_Kill()
        {
            int w1Damage = 50;
            int w1Hp = 100;
            int w2Damage = 30;
            int w2Hp = 100;

            Warrior warrior1 = new Warrior("Pesho", w1Damage, w1Hp);
            Warrior warrior2 = new Warrior("Gosho", w2Damage, w2Hp);

            warrior1.Attack(warrior2);

            int w1ExpectedHp = w1Hp - w2Damage;
            int w2ExpectedHp = w2Hp - w1Damage;

            int w1ActualHP = warrior1.HP;
            int w2ActualHP = warrior2.HP;

            Assert.AreEqual(w1ExpectedHp, w1ActualHP);
            Assert.AreEqual(w2ExpectedHp, w2ActualHP);
        }

        [TestCase(35)]
        [TestCase(50)]
        public void Success_AttackingWith_Kill(int w2Hp)
        {
            int w1Damage = 50;
            int w1Hp = 100;
            int w2Damage = 30;

            Warrior warrior1 = new Warrior("Pesho", w1Damage, w1Hp);
            Warrior warrior2 = new Warrior("Gosho", w2Damage, w2Hp);

            warrior1.Attack(warrior2);

            int w1ExpectedHp = w1Hp - w2Damage;
            int w2ExpectedHp = 0;

            int w1ActualHP = warrior1.HP;
            int w2ActualHP = warrior2.HP;

            Assert.AreEqual(w1ExpectedHp, w1ActualHP);
            Assert.AreEqual(w2ExpectedHp, w2ActualHP);
        }

        [TestCase(0)]
        [TestCase(15)]
        [TestCase(30)]
        public void AttackingShouldThrowException_WhenAttackerIsBelowMin(int w1Hp)
        {
            int w1Damage = 50;
           
            int w2Damage = 30;
            int w2Hp = 100;

            Warrior warrior1 = new Warrior("Pesho", w1Damage, w1Hp);
            Warrior warrior2 = new Warrior("Gosho", w2Damage, w2Hp);


            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);

            }, "Your HP is too low in order to attack other warriors!");
        }
        
        [TestCase(0)]
        [TestCase(15)]
        [TestCase(30)]
        public void AttackingShouldThrowException_WhenDefenderIsBelowMin(int w2Hp)
        {
            int w1Damage = 50;
            int w1Hp = 100;
            int w2Damage = 30;            

            Warrior warrior1 = new Warrior("Pesho", w1Damage, w1Hp);
            Warrior warrior2 = new Warrior("Gosho", w2Damage, w2Hp);


            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);

            }, "Enemy HP must be greater than 30 in order to attack him!");
        }
        [TestCase(45, 65)]
        [TestCase(45, 46)]
        public void AttackingShopldThrowException_WhenAttackerHPIsBelowDefenderDamamge(int w1Hp, int w2Damage)
        {
            int w1Damage = 50;
            int w2Hp = 100;
            

            Warrior warrior1 = new Warrior("Pesho", w1Damage, w1Hp);
            Warrior warrior2 = new Warrior("Gosho", w2Damage, w2Hp);


            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);

            }, "You are trying to attack too strong enemy");
        }
    }
}