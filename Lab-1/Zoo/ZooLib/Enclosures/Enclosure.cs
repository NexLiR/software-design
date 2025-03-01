using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Animals;

namespace ZooLib.Enclosures
{
    public class Enclosure : IEnclosure
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Capacity { get; private set; }
        public List<IAnimal> Animals { get; private set; } = new List<IAnimal>();
        public bool IsClean { get; set; } = true;
        private List<string> _compatibleSpecies;

        public Enclosure(string name, string type, int capacity, List<string> compatibleSpecies)
        {
            Name = name;
            Type = type;
            Capacity = capacity;
            _compatibleSpecies = compatibleSpecies;
        }

        public bool CanHostAnimal(IAnimal animal)
        {
            return _compatibleSpecies.Contains(animal.Species) && Animals.Count < Capacity;
        }

        public bool AddAnimal(IAnimal animal)
        {
            if (CanHostAnimal(animal))
            {
                Animals.Add(animal);
                animal.CurrentEnclosure = this;
                Console.WriteLine($"{animal.Name} added to {Name}");
                return true;
            }
            else
            {
                Console.WriteLine($"Cannot add {animal.Name} to {Name} - incompatible or at capacity");
                return false;
            }
        }

        public bool RemoveAnimal(IAnimal animal)
        {
            if (Animals.Contains(animal))
            {
                Animals.Remove(animal);
                animal.CurrentEnclosure = null;
                Console.WriteLine($"{animal.Name} removed from {Name}");
                return true;
            }
            else
            {
                Console.WriteLine($"{animal.Name} is not in {Name}");
                return false;
            }
        }

        public void Clean()
        {
            IsClean = true;
            Console.WriteLine($"{Name} has been cleaned");
        }
    }
}
