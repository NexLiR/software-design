using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Enclosures;
using ZooLib.Food;
using ZooLib.Food.FoodRequirements;
using ZooLib.HealthInfo;

namespace ZooLib.Animals
{
    public interface IAnimal
    {
        string Name { get; }
        string Species { get; }
        int Age { get; }
        double Weight { get; }
        bool IsHealthy { get; }
        IEnclosure CurrentEnclosure { get; set; }
        IFoodRequirement FoodRequirement { get; }
        IHealthRecord HealthRecord { get; }
        void Feed(IFood food);
        void CheckHealth();
    }
}
