using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.Food
{
    public interface IFood
    {
        string Name { get; }
        double Quantity { get; }
        DateTime ExpiryDate { get; }
        bool IsExpired { get; }
        List<string> SuitableForSpecies { get; }
        bool IsSuitableFor(string species);
    }
}
