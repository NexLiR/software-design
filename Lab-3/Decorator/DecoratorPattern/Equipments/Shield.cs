using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.DecoratorPattern.Heroes;

namespace Decorator.DecoratorPattern.Equipments
{
    public class Shield : EquipmentDecorator
    {
        public Shield(Hero hero) : base(hero)
        {
            Defense += 10;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()} carrying a Shield";
        }
    }
}
