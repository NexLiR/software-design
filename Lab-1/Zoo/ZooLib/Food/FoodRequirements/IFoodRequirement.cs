using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.Food.FoodRequirements
{
    public interface IFoodRequirement
    {
        double DailyQuantity { get; }
        List<string> PreferredFoodTypes { get; }
        bool CanEat(IFood food);
    }
}
