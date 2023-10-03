
namespace Raiding.Models
{
    using Interfaces;
    class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        {
            this.Power = (int)HerosPowers.Paladin;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
