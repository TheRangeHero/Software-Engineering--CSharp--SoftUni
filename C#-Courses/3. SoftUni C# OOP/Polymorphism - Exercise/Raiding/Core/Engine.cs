namespace Raiding.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;


    using Core.Interfaces;
    using Exceptions;
    using Factories.Interfaces;
    using IO.Interfaces;
    using Models;

    class Engine : IEngine
    {
        private readonly IHeroFactory heroFactory;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICollection<BaseHero> heroes;
        private int bossPower;
        private int heroesTotalPower;

        private Engine()
        {
            this.heroes = new Collection<BaseHero>();
        }
        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory) :
            this()
        {
            this.reader = reader;
            this.writer = writer;

            this.heroFactory = heroFactory;
        }

        public void Run()
        {
            this.InputHandle();

            this.HeroesTotalPower(heroes);

            this.Print(heroes, heroesTotalPower, bossPower);
        }

        private void InputHandle()
        {
            int numberOfHeroes = int.Parse(this.reader.ReadLine());

            while (heroes.Count != numberOfHeroes)
            {
                string name = this.reader.ReadLine();
                string type = this.reader.ReadLine();

                try
                {
                    BaseHero hero = this.heroFactory.CreateHero(name, type);
                    heroes.Add(hero);
                }
                catch (InvalidHeroException ex)
                {

                    this.writer.WirteLine(ex.Message);
                    continue;
                }
            }

            bossPower = int.Parse(this.reader.ReadLine());
        }
        private int HeroesTotalPower(ICollection<BaseHero> heroes)
        {

            if (heroes.Any())
            {
                heroesTotalPower = heroes.Sum(p => p.Power);
            }
            return heroesTotalPower;
        }
        private void Print(ICollection<BaseHero> heroes, int heroesTotalPower, int bossPower)
        {
            if (heroes.Any())
            {
                foreach (var hero in heroes)
                {
                    this.writer.WirteLine(hero.CastAbility());
                }
            }

            if (heroesTotalPower >= bossPower)
            {
                this.writer.WirteLine("Victory!");
            }
            else
            {
                this.writer.WirteLine("Defeat...");
            }
        }
    }
}
