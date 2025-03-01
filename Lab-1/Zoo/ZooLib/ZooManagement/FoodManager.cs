using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Food;

namespace ZooLib.ZooManagement
{
    public class FoodManager
    {
        private Dictionary<string, List<IFood>> _foodInventory = new Dictionary<string, List<IFood>>();

        public void AddFood(IFood food)
        {
            if (!_foodInventory.ContainsKey(food.Name))
            {
                _foodInventory[food.Name] = new List<IFood>();
            }
            _foodInventory[food.Name].Add(food);
            Console.WriteLine($"Added {food.Quantity} units of {food.Name} to inventory");
        }

        public void RemoveExpiredFood()
        {
            int totalRemoved = 0;

            foreach (var foodType in _foodInventory.Keys.ToList())
            {
                var expiredItems = _foodInventory[foodType].Where(f => f.IsExpired).ToList();
                foreach (var item in expiredItems)
                {
                    _foodInventory[foodType].Remove(item);
                    totalRemoved++;
                }
            }

            Console.WriteLine($"Removed {totalRemoved} expired food items from inventory");
        }

        public void PrintInventory()
        {
            foreach (var foodEntry in _foodInventory)
            {
                var totalQuantity = foodEntry.Value.Sum(f => f.Quantity);
                var expiredCount = foodEntry.Value.Count(f => f.IsExpired);
                Console.WriteLine($"{foodEntry.Key}: {totalQuantity} units ({expiredCount} expired items)");
            }
        }
    }
}
