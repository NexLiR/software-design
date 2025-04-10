using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.DecoratorPattern.Heroes
{
    public class Paladin : Hero
    {
        public Paladin(string name)
        {
            Name = name;
            Health = 90;
            Attack = 15;
            Defense = 20;
            MagicPower = 10;
        }

        public override string GetDescription()
        {
            return $"Paladin {base.GetDescription()}";
        }
    }
}
