using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.Food
{
    public class FoodItem : IFood
    {
        public string Name { get; private set; }
        public double Quantity { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        public List<string> SuitableForSpecies { get; private set; }

        public bool IsExpired => DateTime.Now > ExpiryDate;

        public FoodItem(string name, double quantity, DateTime expiryDate, List<string> suitableForSpecies)
        {
            Name = name;
            Quantity = quantity;
            ExpiryDate = expiryDate;
            SuitableForSpecies = suitableForSpecies;
        }

        public bool IsSuitableFor(string species)
        {
            return SuitableForSpecies.Contains(species);
        }
    }
}
