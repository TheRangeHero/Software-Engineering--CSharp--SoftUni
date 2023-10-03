using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void Planet_Constructor_ShoulSetName_Correctly()
            {
                var planet = new Planet("Mars", 120);
                var expectedName = "Mars";

                Assert.AreEqual(expectedName, planet.Name);
            }
            [Test]
            public void Planet_Constructor_ShoulSetBudget_Correctly()
            {
                var planet = new Planet("Mars", 120);
                var expectedBudget = 120;

                Assert.AreEqual(expectedBudget, planet.Budget);
            }
            [Test]
            public void Planet_Constructor_CreatesCollectionOfWeapons()
            {
                var planet = new Planet("Venus", 120);

                Assert.That(planet.Weapons.Count, Is.EqualTo(0));
            }
            [Test]
            public void Planet_Constructor_CreatesNewWeapon_Correctly()
            {
                var weapon = new Weapon("Nuclear", 120, 9);

                Assert.That(weapon.DestructionLevel, Is.EqualTo(9));
                Assert.That(weapon.Price, Is.EqualTo(120));
                Assert.That(weapon.Name, Is.EqualTo("Nuclear"));
            }
            [TestCase(null)]
            [TestCase("")]
            public void Planet_Constructor_ShouldThrowException_WithInvalidPlanetName(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var planet = new Planet(name, 12);
                });
            }
            [Test]
            public void Planet_Constructor_ShouldThrowException_WithInvalidBudget()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var planet = new Planet("Mars", -1);
                });
            }
            [Test]
            public void Planet_MilitaryPowerRatio_ShouldReturn_DestructionLevelSUM()
            {
                var planet = new Planet("Mars", 80);
                var firstWeapon = new Weapon("Nuclear", 30, 3);
                var secondWeapon = new Weapon("SpaceMissiles", 22, 4);

                planet.AddWeapon(firstWeapon);
                planet.AddWeapon(secondWeapon);

                var excpetedDestructionLevel = firstWeapon.DestructionLevel + secondWeapon.DestructionLevel;

                Assert.AreEqual(excpetedDestructionLevel, planet.MilitaryPowerRatio);

            }
            [TestCase(0)]
            [TestCase(20)]
            public void Planet_Profit_ShouldIncreaseBudget_WithGivenAmount(int budget)
            {
                var planet = new Planet("Mars", 20);
                planet.Profit(budget);

                Assert.That(planet.Budget, Is.EqualTo(20 + budget));
            }
            [TestCase(0)]
            [TestCase(20)]
            public void Planet_SpendFunds_ShouldDecreaseBudget_WithGivenAmount(int budget)
            {
                var planet = new Planet("Mars", 20);
                planet.SpendFunds(budget);

                Assert.That(planet.Budget, Is.EqualTo(20 - budget));
            }
            [Test]
            public void Planet_SpendFunds_ShouldThrowException_WhenAmountGoesBelowZero()
            {
                var planet = new Planet("Mars", 20);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(22);
                });
            }
            [Test]
            public void Planet_AddWeapon_ShouldAddNewWeapon_Correctly()
            {
                var planet = new Planet("Mars", 20);
                var weapon = new Weapon("Nuclear", 100, 3);

                planet.AddWeapon(weapon);

                Assert.That(planet.Weapons.Count, Is.EqualTo(1));
            }
            [Test]
            public void Planet_AddWeapon_ShouldThrowException_WhenWeaponAlreadyExists()
            {
                var planet = new Planet("Mars", 20);
                var weapon = new Weapon("Nuclear", 100, 3);

                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                });
            }
            [Test]
            public void Planet_RemoveWeapon_ShouldRemoveAddedWeapon_Correctly()
            {
                var planet = new Planet("Mars", 20);
                var weapon = new Weapon("Nuclear", 100, 3);

                planet.AddWeapon(weapon);

                Assert.That(planet.Weapons.Count, Is.EqualTo(1));

                planet.RemoveWeapon(weapon.Name);
                Assert.That(planet.Weapons.Count, Is.EqualTo(0));

             
            }
            [Test]
            public void Planet_UpgradeWeapon_ShouldIncreaseDestructionLevel_Correctly()
            {
                var planet = new Planet("Mars", 20);
                var weapon = new Weapon("Nuclear", 100, 3);


                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("Nuclear");

                Assert.That(weapon.DestructionLevel, Is.EqualTo(4));
            }
            [Test]
            public void Planet_UpgradeWeapon_ShouldThrowException_WhenWeaponIsNotExisting()
            {
                var planet = new Planet("Mars", 20);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("WhereIsTheWeapon");
                });
            }
            [Test]
            public void Planet_DestructOpponent_ShouldDestroyOpponenIfOurPowerIsHigher_Correctly()
            {
                var planetOne = new Planet("Mars", 7000);
                var planetTwo = new Planet("Earth", 6000);

                var weaponOne = new Weapon("Nuclear", 100, 3);
                var weaponTwo = new Weapon("Nuclearr", 110, 4);
                var weaponThree = new Weapon("Nuclearrr", 120, 5);


                planetOne.AddWeapon(weaponOne);
                planetOne.AddWeapon(weaponThree);

                planetTwo.AddWeapon(weaponTwo);

                var expectedStringResult = "Earth is destructed!";

                Assert.That(planetOne.DestructOpponent(planetTwo), Is.EqualTo(expectedStringResult));
            }
            [Test]
            public void Planet_DestructOpponent_ShouldThrowException_WithLowerDestructionPower()
            {
                var planetOne = new Planet("Mars", 7000);
                var planetTwo = new Planet("Earth", 6000);

                var weaponOne = new Weapon("Nuclear", 100, 3);
                var weaponTwo = new Weapon("Nuclearr", 110, 4);
              


                planetOne.AddWeapon(weaponOne);
              

                planetTwo.AddWeapon(weaponTwo);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planetOne.DestructOpponent(planetTwo);
                });
            }
            [Test]
            public void Planet_DestructOpponent_ShouldThrowException_WithEqualDestructionPower()
            {
                var planetOne = new Planet("Mars", 7000);
                var planetTwo = new Planet("Earth", 6000);

                var weaponOne = new Weapon("Nuclear", 100, 4);
                var weaponTwo = new Weapon("Nuclearr", 110, 4);



                planetOne.AddWeapon(weaponOne);


                planetTwo.AddWeapon(weaponTwo);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planetOne.DestructOpponent(planetTwo);
                });
            }

            [Test]
            public void Weapon_Constructor_ShouldSetName_Correctly()
            {
                var weapon = new Weapon("Weapon", 10, 10);

                Assert.That(weapon.Name, Is.EqualTo("Weapon"));
            }

            [Test]
            public void Weapon_Constructor_ShouldSetDescructionLevel_Correctly()
            {
                var weapon = new Weapon("Weapon", 10, 10);

                Assert.That(weapon.DestructionLevel, Is.EqualTo(10));
            }

            [Test]
            public void Weapon_Constructor_ShouldSetPrice_Correctly()
            {
                var weapon = new Weapon("Weapon", 10, 10);

                Assert.That(weapon.Price, Is.EqualTo(10));
            }

            [Test]
            public void Weapon_Constructor_ShouldThrowException_WhenPriceIsBelowZero()
            {

                Assert.Throws<ArgumentException>(() =>
                {
                var weapon = new Weapon("Weapon", -10, 10);

                });
            }

            [Test]
            public void Weapon_IncreaseDestructionLevel_ShouldWork_Correctly()
            {
                var weapon = new Weapon("Weapon", 10, 10);

                weapon.IncreaseDestructionLevel();

                Assert.That(weapon.DestructionLevel, Is.EqualTo(11));
            }

            //[Test]
            //public void AA()
            //{

            //}
        }
    }
}
