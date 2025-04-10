using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.DecoratorPattern.Heroes
{
    public class Warrior : Hero
    {
        public Warrior(string name)
        {
            Name = name;
            Health = 100;
            Attack = 20;
            Defense = 15;
            MagicPower = 0;
        }

        public override string GetDescription()
        {
            return $"Warrior {base.GetDescription()}";
        }
    }
}
