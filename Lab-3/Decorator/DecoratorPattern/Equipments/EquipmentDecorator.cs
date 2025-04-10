using Decorator.DecoratorPattern.Heroes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Decorator.DecoratorPattern.Equipments
{
    public abstract class EquipmentDecorator : Hero
    {
        protected Hero _hero;

        public EquipmentDecorator(Hero hero)
        {
            _hero = hero;
            Name = hero.Name;
            Health = hero.Health;
            Attack = hero.Attack;
            Defense = hero.Defense;
            MagicPower = hero.MagicPower;
        }

        public override string GetDescription()
        {
            return _hero.GetDescription();
        }
    }
}
