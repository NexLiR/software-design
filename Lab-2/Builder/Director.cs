using Builder.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Director
    {
        public Character CreateHero()
        {
            return new HeroBuilder()
                .SetName("Hero")
                .SetHeight(185)
                .SetBuild("Athletic")
                .SetHairColor("Golden")
                .SetEyeColor("Blue")
                .AddInventoryItem("Excalibur Sword")
                .AddInventoryItem("Healing Potion")
                .AddInventoryItem("Shield of Light")
                .SetSpecialPower("Divine Protection")
                .PerformDeed("Saved village from dragon")
                .PerformDeed("Rescued princess from tower")
                .Build();
        }

        public Character CreateEnemy()
        {
            return new EnemyBuilder()
                .SetName("Villian")
                .SetHeight(240)
                .SetBuild("Massive")
                .SetHairColor("Black")
                .SetEyeColor("Red")
                .AddInventoryItem("Soul Reaper Scythe")
                .AddInventoryItem("Poison Vial")
                .AddInventoryItem("Cursed Amulet")
                .SetSpecialPower("Soul Absorption")
                .PerformDeed("Destroyed kingdom")
                .PerformDeed("Summoned army of undead")
                .Build();
        }
    }
}
