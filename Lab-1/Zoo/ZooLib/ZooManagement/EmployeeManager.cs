using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Employees.Roles;
using ZooLib.Employees;
using ZooLib.Enclosures;

namespace ZooLib.ZooManagement
{
    public class EmployeeManager
    {
        private List<IEmployee> _employees = new List<IEmployee>();

        public void AddEmployee(IEmployee employee)
        {
            _employees.Add(employee);
            Console.WriteLine($"{employee.Name} ({employee.Role.Name}) hired by the zoo");
        }

        public IEmployee GetEmployee(string id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public List<IEmployee> GetEmployeesByRole(string roleName)
        {
            return _employees.Where(e => e.Role.Name == roleName).ToList();
        }

        public List<IEmployee> GetAllEmployees()
        {
            return _employees;
        }

        public void RemoveEmployee(IEmployee employee)
        {
            if (_employees.Contains(employee))
            {
                _employees.Remove(employee);
                Console.WriteLine($"{employee.Name} no longer works at the zoo");
            }
        }

        public void AssignZookeeperToEnclosure(Zookeeper zookeeper, IEnclosure enclosure)
        {
            if (_employees.Contains(zookeeper))
            {
                zookeeper.AddResponsibleEnclosure(enclosure);
            }
            else
            {
                Console.WriteLine($"{zookeeper.Name} is not an employee of this zoo");
            }
        }
    }
}
