﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Animals;
using ZooLib.HealthInfo;

namespace ZooLib.Employees
{

    public abstract class EmployeeBase : IEmployee
    {
        public string Name { get; protected set; }
        public string Id { get; protected set; }
        public IEmployeeRole Role { get; protected set; }
        public IHealthRecord HealthRecord { get; protected set; }

        public bool IsHealthy => HealthRecord.IsHealthy;

        private List<string> _assignedTasks = new List<string>();

        protected EmployeeBase(string name, string id, IEmployeeRole role)
        {
            Name = name;
            Id = id;
            Role = role;
            HealthRecord = new HealthRecord(id, "Employee");
        }

        public void CheckHealth()
        {
            HealthRecord.Checkup(DateTime.Now);
            Console.WriteLine($"Health check completed for {Name}. Status: {(IsHealthy ? "Healthy" : "Requires attention")}");
        }

        public void AssignTask(string task)
        {
            _assignedTasks.Add(task);
            Console.WriteLine($"{Name} assigned task: {task}");
        }

        public bool CanHandleAnimal(IAnimal animal)
        {
            return Role.CanHandleAnimalType(animal.Species);
        }
    }
}
