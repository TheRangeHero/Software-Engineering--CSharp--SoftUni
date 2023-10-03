using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy deadDummy;
        private Dummy dummy;
        private int health;
        private int experience;

        [SetUp]
        public void SetUp()
        {
            health = 10;
            experience = 15;
            dummy = new Dummy(health, experience);
            deadDummy = new Dummy(health, experience);
            deadDummy.TakeAttack(health + 10);
        }

        [Test]
        public void Test_DummyConstructorShouldSetDataCorrectly()
        {
            Assert.AreEqual(health, dummy.Health);
        }
        [Test]
        public void Test_TestDummyLoosesHealt_WhenAttacked()
        {
            dummy.TakeAttack(5);
            Assert.AreEqual(health - 5, dummy.Health);
        } 
        [Test]
        public void Test_TestDummyShouldThrowException_WhenAttkeckedAndHealthIsZero()
        {
            dummy.TakeAttack(health);
            Assert.Throws<InvalidOperationException>((() =>
            {
                dummy.TakeAttack(1);
            }));
        }
        
        [Test]
        public void Test_TestDummyShouldThrowException_WhenAttkeckedAndHealthIsBelowZero()
        {
            dummy.TakeAttack(health+10);
            Assert.Throws<InvalidOperationException>((() =>
            {
                deadDummy.TakeAttack(1);
            }));
        }

        [Test]
        public void Test_TestDummyShouldGiveExperience_WhenIsDead()
        {
            var dummyExperience = deadDummy.GiveExperience();

            Assert.AreEqual(experience, dummyExperience);
            dummy.TakeAttack(health+10);
          
        }

        [Test]
        public void Test_TestDummyGiveExperience_ShouldThrowException_WhenDUmmyIsAlive ()
        {
            

            Assert.Throws<InvalidOperationException>((() =>
            {
                dummy.GiveExperience();
            }));   
        }

    }
}