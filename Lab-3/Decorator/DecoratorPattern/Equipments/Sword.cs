using Decorator.DecoratorPattern.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.DecoratorPattern.Equipments
{
    public class Sword : EquipmentDecorator
    {
        public Sword(Hero hero) : base(hero)
        {
            Attack += 10;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()} wielding a Sword";
        }
    }
}
