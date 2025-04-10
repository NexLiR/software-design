using Decorator.DecoratorPattern.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.DecoratorPattern.Equipments
{
    public class PlateArmor : EquipmentDecorator
    {
        public PlateArmor(Hero hero) : base(hero)
        {
            Defense += 15;
            Health += 10;
            Attack -= 2;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()} with Plate Armor";
        }
    }
}
