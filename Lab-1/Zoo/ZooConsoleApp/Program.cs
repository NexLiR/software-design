using ZooLib.HealthInfo;
using ZooLib.Employees;
using ZooLib.Enclosures;
using ZooLib.Animals;
using ZooLib.Food;
using ZooLib.Food.FoodRequirements;
using ZooLib.ZooManagement;
using ZooLib.Employees.Roles;
using ZooLib.HealthInfo.Vaccines;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Zoo Management System ===\n");

        var zoo = new Zoo("Zoo");

        var zookeeperRole = new EmployeeRole("Zookeeper", "Takes care of animals and enclosures",
            new List<string> { "Lion", "Tiger", "Giraffe", "Elephant", "Penguin", "Parrot" });

        var veterinarianRole = new EmployeeRole("Veterinarian", "Provides medical care for animals",
            new List<string> { "Any" });

        var employee1 = new Zookeeper("Oleksiy Semenchuk", "EMP1", zookeeperRole);
        var employee2 = new Veterinarian("Denys Linevych", "EMP2", veterinarianRole);

        zoo.EmployeeManager.AddEmployee(employee1);
        zoo.EmployeeManager.AddEmployee(employee2);

        var savanna = new TerrestrialEnclosure("Savanna", 5,
            new List<string> { "Lion", "Giraffe", "Elephant" }, 
            1000, "Grassland");

        var aviary = new AviaryEnclosure("Tropical Aviary", 15,
            new List<string> { "Parrot", "Toucan", "Flamingo" }, 8, true);

        zoo.EnclosureManager.AddEnclosure(savanna);
        zoo.EnclosureManager.AddEnclosure(aviary);

        var lion1 = new Mammal("Simba", "Lion", 5, 190, false);
        var giraffe1 = new Mammal("Melman", "Giraffe", 7, 1100, false);
        var parrot1 = new Bird("Rio", "Parrot", 3, 1.2, true);
        var penguin1 = new Bird("Mumble", "Penguin", 2, 25, false);

        zoo.AnimalManager.AddAnimal(lion1);
        zoo.AnimalManager.AddAnimal(giraffe1);
        zoo.AnimalManager.AddAnimal(parrot1);
        zoo.AnimalManager.AddAnimal(penguin1);

        zoo.EnclosureManager.AssignAnimalToEnclosure(lion1, savanna);
        zoo.EnclosureManager.AssignAnimalToEnclosure(giraffe1, savanna);
        zoo.EnclosureManager.AssignAnimalToEnclosure(penguin1, aviary);

        zoo.EmployeeManager.AssignZookeeperToEnclosure(employee1, savanna);
        zoo.EmployeeManager.AssignZookeeperToEnclosure(employee1, aviary);
        
        var meat = new FoodItem("Meat", 100, DateTime.Now.AddDays(5),
            new List<string> { "Lion", "Tiger" });

        var leaves = new FoodItem("Leaves", 200, DateTime.Now.AddDays(3),
            new List<string> { "Giraffe", "Elephant" });

        var seeds = new FoodItem("Seeds", 80, DateTime.Now.AddDays(30),
            new List<string> { "Parrot", "Toucan" });

        zoo.FoodManager.AddFood(meat);
        zoo.FoodManager.AddFood(leaves);
        zoo.FoodManager.AddFood(seeds);

        var rabiesVaccine = new AnimalVaccine("Rabies Vaccine", "Prevents rabies",
            DateTime.Now.AddDays(-30), 12, new List<string> { "Lion", "Tiger", "Giraffe" });

        var fluVaccine = new HumanVaccine("Flu Vaccine", "Prevents seasonal flu",
            DateTime.Now.AddDays(-60), 12);

        var healthRecord = (HealthRecord)lion1.HealthRecord;
        healthRecord.AddVaccine(rabiesVaccine);

        healthRecord = (HealthRecord)giraffe1.HealthRecord;
        healthRecord.AddVaccine(rabiesVaccine);

        healthRecord = (HealthRecord)employee1.HealthRecord;
        healthRecord.AddVaccine(fluVaccine);

        healthRecord = (HealthRecord)employee2.HealthRecord;
        healthRecord.AddVaccine(fluVaccine);

        Console.WriteLine("\n=== First day of operations ===");

        zoo.PerformDailyRoutine();

        healthRecord = (HealthRecord)giraffe1.HealthRecord;
        healthRecord.AddMedicalCondition("Neck pain");

        zoo.PrintZooStatus();

        Console.WriteLine("\n=== Second day of operations ===");

        employee2.TreatAnimal(giraffe1, "Neck pain");

        zoo.FoodManager.RemoveExpiredFood();

        zoo.PerformDailyRoutine();

        zoo.PrintZooStatus();
    }
}