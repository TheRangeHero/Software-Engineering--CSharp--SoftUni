using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var knights = new List<Knight>();
            var barbarians = new List<Barbarian>();

            foreach (var player in players)
            {
                if (player.IsAlive)
                {
                    if (player is Knight knight)
                    {
                        knights.Add(knight);
                    }
                    else if (player is Barbarian barbarian)
                    {
                        barbarians.Add(barbarian);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid hero type.");
                    }
                }
            }

            var continueBattle = true;

            while (continueBattle)
            {
                var allKnightsAreDead = true;
                var allBarbariansAreDead = true;

                var aliveKnights = 0;
                var aliveBarbarians = 0;
                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        allKnightsAreDead = false;
                        aliveKnights++;

                        foreach (var barbarian in barbarians.Where(b=>b.IsAlive))
                        {
                            var weaponDamage = knight.Weapon.DoDamage();
                            barbarian.TakeDamage(weaponDamage);
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        allBarbariansAreDead = false;
                        aliveBarbarians++;

                        foreach (var knight in knights.Where(k=>k.IsAlive))
                        {
                            var weaponDamage = barbarian.Weapon.DoDamage();
                            knight.TakeDamage(weaponDamage);
                        }
                    }
                }

                if (allKnightsAreDead)
                {
                    var deathBarbarians = barbarians.Count - aliveBarbarians;

                    return $"The barbarians took {deathBarbarians} casualties but won the battle.";
                }

                if (allBarbariansAreDead)
                {
                    var deathKnights = knights.Count - aliveKnights;

                    return $"The knights took {deathKnights} casualties but won the battle.";
                }
            }

            throw new InvalidOperationException("The fight logic has a bug.");
        }
    }
}
