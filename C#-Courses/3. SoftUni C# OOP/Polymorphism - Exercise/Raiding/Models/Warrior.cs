
namespace Raiding.Models
{
    using Interfaces;
    class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
            this.Power = (int)HerosPowers.Warrior;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
