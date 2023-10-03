
namespace Raiding.Models
{
    using Interfaces;
    class Rogue : BaseHero
    {
        public Rogue(string name) : base(name)
        {
            this.Power = (int)HerosPowers.Rogue;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
