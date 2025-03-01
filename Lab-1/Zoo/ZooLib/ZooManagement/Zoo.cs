using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Employees.Roles;

namespace ZooLib.ZooManagement
{
    public class Zoo
    {
        public string Name { get; private set; }

        public AnimalManager AnimalManager { get; private set; }
        public EmployeeManager EmployeeManager { get; private set; }
        public EnclosureManager EnclosureManager { get; private set; }
        public FoodManager FoodManager { get; private set; }

        public Zoo(string name)
        {
            Name = name;
            AnimalManager = new AnimalManager();
            EmployeeManager = new EmployeeManager();
            EnclosureManager = new EnclosureManager();
            FoodManager = new FoodManager();
        }

        public void PerformDailyRoutine()
        {
            Console.WriteLine($"==== Daily Routine at {Name} Zoo ====");

            foreach (var veterinarian in EmployeeManager.GetEmployeesByRole("Veterinarian").OfType<Veterinarian>())
            {
                foreach (var animal in AnimalManager.GetAllAnimals())
                {
                    veterinarian.ExamineAnimal(animal);
                }
            }

            foreach (var zookeeper in EmployeeManager.GetEmployeesByRole("Zookeeper").OfType<Zookeeper>())
            {
                zookeeper.FeedAnimals();
            }

            foreach (var zookeeper in EmployeeManager.GetEmployeesByRole("Zookeeper").OfType<Zookeeper>())
            {
                zookeeper.CleanEnclosures();
            }

            Console.WriteLine("==== Daily Routine Completed ====");
        }

        public void PrintZooStatus()
        {
            Console.WriteLine($"\n==== Status of {Name} Zoo ====");
            Console.WriteLine($"Animals: {AnimalManager.GetAllAnimals().Count}");
            Console.WriteLine($"Employees: {EmployeeManager.GetAllEmployees().Count}");
            Console.WriteLine($"Enclosures: {EnclosureManager.GetAllEnclosures().Count}");

            Console.WriteLine("\n--- Animals by Enclosure ---");
            foreach (var enclosure in EnclosureManager.GetAllEnclosures())
            {
                Console.WriteLine($"{enclosure.Name} ({enclosure.Type}) - {enclosure.Animals.Count}/{enclosure.Capacity} animals");
                foreach (var animal in enclosure.Animals)
                {
                    Console.WriteLine($"  - {animal.Name} ({animal.Species}), Health: {(animal.IsHealthy ? "Good" : "Needs attention")}");
                }
            }

            Console.WriteLine("\n--- Food Inventory ---");
            FoodManager.PrintInventory();
        }
    }
}
