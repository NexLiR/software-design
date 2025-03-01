using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Animals;

namespace ZooLib.ZooManagement
{
    public class AnimalManager
    {
        private List<IAnimal> _animals = new List<IAnimal>();

        public void AddAnimal(IAnimal animal)
        {
            _animals.Add(animal);
            Console.WriteLine($"{animal.Name} ({animal.Species}) added to the zoo");
        }

        public IAnimal GetAnimal(string name)
        {
            return _animals.FirstOrDefault(a => a.Name == name);
        }

        public List<IAnimal> GetAnimalsBySpecies(string species)
        {
            return _animals.Where(a => a.Species == species).ToList();
        }

        public List<IAnimal> GetAllAnimals()
        {
            return _animals;
        }

        public void RemoveAnimal(IAnimal animal)
        {
            if (_animals.Contains(animal))
            {
                _animals.Remove(animal);
                Console.WriteLine($"{animal.Name} removed from the zoo");
            }
        }
    }
}
