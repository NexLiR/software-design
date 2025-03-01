using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Animals;

namespace ZooLib.Employees
{
    public interface IEmployee
    {
        string Name { get; }
        string Id { get; }
        IEmployeeRole Role { get; }
        bool IsHealthy { get; }
        bool CanHandleAnimal(IAnimal animal);
    }
}
