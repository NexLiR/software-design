using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Enclosures;

namespace ZooLib.Employees.Roles
{
    public class Zookeeper : EmployeeBase
    {
        public List<IEnclosure> ResponsibleEnclosures { get; private set; } = new List<IEnclosure>();

        public Zookeeper(string name, string id, IEmployeeRole role) : base(name, id, role)
        {
        }

        public void AddResponsibleEnclosure(IEnclosure enclosure)
        {
            ResponsibleEnclosures.Add(enclosure);
            Console.WriteLine($"{Name} is now responsible for enclosure: {enclosure.Name}");
        }

        public void FeedAnimals()
        {
            foreach (var enclosure in ResponsibleEnclosures)
            {
                Console.WriteLine($"{Name} is feeding animals in {enclosure.Name}");
                foreach (var animal in enclosure.Animals)
                {
                    if (CanHandleAnimal(animal))
                    {
                        Console.WriteLine($"  - Feeding {animal.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"  - Cannot feed {animal.Name} due to role restrictions");
                    }
                }
            }
        }

        public void CleanEnclosures()
        {
            foreach (var enclosure in ResponsibleEnclosures)
            {
                if (!enclosure.IsClean)
                {
                    enclosure.Clean();
                    Console.WriteLine($"{Name} cleaned {enclosure.Name}");
                }
            }
        }
    }
}
