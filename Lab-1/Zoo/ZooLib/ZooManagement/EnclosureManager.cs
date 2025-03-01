using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Animals;
using ZooLib.Enclosures;

namespace ZooLib.ZooManagement
{
    public class EnclosureManager
    {
        private List<IEnclosure> _enclosures = new List<IEnclosure>();

        public void AddEnclosure(IEnclosure enclosure)
        {
            _enclosures.Add(enclosure);
            Console.WriteLine($"New enclosure '{enclosure.Name}' added to the zoo");
        }

        public IEnclosure GetEnclosure(string name)
        {
            return _enclosures.FirstOrDefault(e => e.Name == name);
        }

        public List<IEnclosure> GetEnclosuresByType(string type)
        {
            return _enclosures.Where(e => e.Type == type).ToList();
        }

        public List<IEnclosure> GetAllEnclosures()
        {
            return _enclosures;
        }

        public void RemoveEnclosure(IEnclosure enclosure)
        {
            if (_enclosures.Contains(enclosure) && enclosure.Animals.Count == 0)
            {
                _enclosures.Remove(enclosure);
                Console.WriteLine($"Enclosure '{enclosure.Name}' removed from the zoo");
            }
            else if (enclosure.Animals.Count > 0)
            {
                Console.WriteLine($"Cannot remove enclosure '{enclosure.Name}' as it still contains animals");
            }
        }

        public void AssignAnimalToEnclosure(IAnimal animal, IEnclosure enclosure)
        {
            if (_enclosures.Contains(enclosure))
            {
                if (animal.CurrentEnclosure != null)
                {
                    animal.CurrentEnclosure.RemoveAnimal(animal);
                }

                if (enclosure.AddAnimal(animal))
                {
                    Console.WriteLine($"{animal.Name} assigned to {enclosure.Name}");
                }
                else
                {
                    Console.WriteLine($"Failed to assign {animal.Name} to {enclosure.Name}");
                }
            }
            else
            {
                Console.WriteLine($"Enclosure '{enclosure.Name}' is not part of this zoo");
            }
        }
    }
}
