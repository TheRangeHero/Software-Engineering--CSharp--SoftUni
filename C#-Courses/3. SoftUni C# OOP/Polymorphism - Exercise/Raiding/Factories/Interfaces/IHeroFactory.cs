namespace Raiding.Factories.Interfaces
{
using Raiding.Models;
    interface IHeroFactory
    {
        BaseHero CreateHero(string heroName, string type);
    }
}
