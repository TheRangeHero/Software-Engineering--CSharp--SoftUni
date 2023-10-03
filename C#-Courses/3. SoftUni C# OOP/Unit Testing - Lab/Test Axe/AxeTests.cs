using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Dummy dummy;
        private Axe axe;
        private int attackPoints;
        private int durabilityPoints;
        [SetUp]
        public void SetUp()
        {
            attackPoints = 10;
            durabilityPoints = 15;
            axe = new Axe(attackPoints, durabilityPoints);
            dummy = new Dummy(100, 100);
        }

        [Test]
        public void Test_AxeConstructorShouldSetDataProperly()
        {
            Assert.AreEqual(attackPoints, axe.AttackPoints);
            Assert.AreEqual(durabilityPoints, axe.DurabilityPoints);
        }
        [Test]
        public void Test_AxeShouldLoseDurabilityPoints_AfterEachAttack()
        {
            for (int i = 0; i < 5; i++)
            {
                axe.Attack(dummy);
            }
            Assert.AreEqual(durabilityPoints - 5, axe.DurabilityPoints);
        }
        [Test]
        public void Test_AxeShouldThrowException_WhenDurabitlityPointsAre0()
        {
            axe = new Axe(10, 0);

            Assert.Throws<InvalidOperationException>((() =>
            {
                axe.Attack(dummy);
            }));
        }
        [Test]
        public void Test_AxeShouldThrowException_WhenDurabitlityPointsareNegative()
        {
            axe = new Axe(10, -5);

            Assert.Throws<InvalidOperationException>((() =>
            {
                axe.Attack(dummy);
            }));
        }
    }
}