using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.Employees.Roles
{
    public class EmployeeRole : IEmployeeRole
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        private List<string> _handlableAnimalTypes;

        public EmployeeRole(string name, string description, List<string> handlableAnimalTypes)
        {
            Name = name;
            Description = description;
            _handlableAnimalTypes = handlableAnimalTypes;
        }

        public bool CanHandleAnimalType(string animalType)
        {
            return _handlableAnimalTypes.Contains(animalType) || _handlableAnimalTypes.Contains("Any");
        }
    }
}
