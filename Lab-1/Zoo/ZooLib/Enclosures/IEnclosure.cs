using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Animals;

namespace ZooLib.Enclosures
{
    public interface IEnclosure
    {
        string Name { get; }
        string Type { get; }
        int Capacity { get; }
        List<IAnimal> Animals { get; }
        bool IsClean { get; set; }
        bool CanHostAnimal(IAnimal animal);
        bool AddAnimal(IAnimal animal);
        bool RemoveAnimal(IAnimal animal);
        void Clean();
    }
}
