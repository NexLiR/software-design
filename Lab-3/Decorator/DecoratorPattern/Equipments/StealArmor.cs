using Decorator.DecoratorPattern.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.DecoratorPattern.Equipments
{
    public class StealArmor : EquipmentDecorator
    {
        public StealArmor(Hero hero) : base(hero)
        {
            Defense += 10;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()} with Steal Armor";
        }
    }
}
