using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.Employees
{
    public interface IEmployeeRole
    {
        string Name { get; }
        string Description { get; }
        bool CanHandleAnimalType(string animalType);
    }
}
