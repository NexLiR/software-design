using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.Food.FoodRequirements
{
    public class MammalFoodRequirement : IFoodRequirement
    {
        public double DailyQuantity { get; private set; }
        public List<string> PreferredFoodTypes { get; private set; }

        public MammalFoodRequirement(double animalWeight)
        {
            DailyQuantity = animalWeight * 0.05;
            PreferredFoodTypes = new List<string> { "Meat", "Vegetables", "Fruits" };
        }

        public bool CanEat(IFood food)
        {
            return !food.IsExpired && PreferredFoodTypes.Any(type => food.Name.Contains(type));
        }
    }
}
