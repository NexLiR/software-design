using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Animals;
using ZooLib.HealthInfo.Vaccines;
using ZooLib.HealthInfo;

namespace ZooLib.Employees.Roles
{
    public class Veterinarian : EmployeeBase
    {
        public Veterinarian(string name, string id, IEmployeeRole role) : base(name, id, role)
        {

        }

        public void ExamineAnimal(IAnimal animal)
        {
            if (CanHandleAnimal(animal))
            {
                animal.CheckHealth();
                Console.WriteLine($"{Name} examined {animal.Name}, health status: {(animal.IsHealthy ? "Healthy" : "Requires attention")}");
            }
            else
            {
                Console.WriteLine($"{Name} cannot examine {animal.Name} due to role restrictions");
            }
        }

        public void TreatAnimal(IAnimal animal, string condition)
        {
            if (CanHandleAnimal(animal))
            {
                Console.WriteLine($"{Name} is treating {animal.Name} for {condition}");
            }
            else
            {
                Console.WriteLine($"{Name} cannot treat {animal.Name} due to role restrictions");
            }
        }
    }
}
