using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Food.FoodRequirements;

namespace ZooLib.Animals
{
    public class Mammal : AnimalBase
    {
        public bool IsNocturnal { get; private set; }

        public Mammal(string name, string species, int age, double weight, bool isNocturnal)
            : base(name, species, age, weight)
        {
            IsNocturnal = isNocturnal;
            FoodRequirement = new MammalFoodRequirement(weight);
        }
    }
}
