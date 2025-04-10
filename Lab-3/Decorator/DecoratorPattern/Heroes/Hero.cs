using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.DecoratorPattern.Heroes
{
    public abstract class Hero
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Attack { get; protected set; }
        public int Defense { get; protected set; }
        public int MagicPower { get; protected set; }

        public virtual string GetDescription()
        {
            return $"{Name}";
        }

        public virtual void DisplayStats()
        {
            Console.WriteLine($"Hero: {GetDescription()}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Attack: {Attack}");
            Console.WriteLine($"Defense: {Defense}");
            Console.WriteLine($"Magic Power: {MagicPower}");
            Console.WriteLine();
        }
    }
}
