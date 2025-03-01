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
    public abstract class AnimalBase : IAnimal
    {
        public string Name { get; protected set; }
        public string Species { get; protected set; }
        public int Age { get; protected set; }
        public double Weight { get; protected set; }
        public IEnclosure CurrentEnclosure { get; set; }
        public IFoodRequirement FoodRequirement { get; protected set; }
        public IHealthRecord HealthRecord { get; protected set; }

        public bool IsHealthy => HealthRecord.IsHealthy;

        protected AnimalBase(string name, string species, int age, double weight)
        {
            Name = name;
            Species = species;
            Age = age;
            Weight = weight;
            HealthRecord = new HealthRecord($"{Species}-{Name}", "Animal");
        }

        public virtual void Feed(IFood food)
        {
            if (FoodRequirement.CanEat(food))
            {
                    Console.WriteLine($"{Name} ate {food.Name}");
            }
            else
            {
                throw new InvalidOperationException($"{food.Name} is not suitable for {Species}");
            }
        }

        public void CheckHealth()
        {
            HealthRecord.Checkup(DateTime.Now);
            Console.WriteLine($"Health check completed for {Name}. Status: {(IsHealthy ? "Healthy" : "Requires attention")}");
        }
    }
}
