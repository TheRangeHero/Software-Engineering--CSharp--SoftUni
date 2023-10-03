
namespace Raiding.Models
{
    using Interfaces;
    class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {
            this.Power = (int)HerosPowers.Druid;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
