
namespace Raiding.Factories
{
    using System;


    using Exceptions;
    using Factories.Interfaces;
    using Models;
    using Models.Interfaces;

    class HeroFactory : IHeroFactory
    {
        public BaseHero CreateHero(string heroName, string type)
        {
            BaseHero hero = null;

            if (type == HeroType.Druid.ToString())
            {
                hero = new Druid(heroName);
            }
            else if (type == HeroType.Paladin.ToString())
            {
                hero = new Paladin(heroName);
            }
            else if (type == HeroType.Rogue.ToString())
            {
                hero = new Rogue(heroName);
            }
            else if (type == HeroType.Warrior.ToString())
            {
                hero = new Warrior(heroName);
            }
            else
            {
                throw new InvalidHeroException(ExceptionMessages.INVALID_HERO_iNPUT_EXCEPTION);
            }

            return hero;
        }
    }
}
