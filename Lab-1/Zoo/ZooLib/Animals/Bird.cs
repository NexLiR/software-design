using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Food.FoodRequirements;

namespace ZooLib.Animals
{
    public class Bird : AnimalBase
    {
        public bool CanFly { get; private set; }

        public Bird(string name, string species, int age, double weight, bool canFly)
            : base(name, species, age, weight)
        {
            CanFly = canFly;
            FoodRequirement = new BirdFoodRequirement(weight);
        }
    }
}
