using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Virus : Prototype
    {
        public double Weight { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public List<Virus> Children { get; set; }

        public Virus(string name, string species, double weight, int age)
        {
            Name = name;
            Species = species;
            Weight = weight;
            Age = age;
            Children = new List<Virus>();
        }

        public void AddChild(Virus child)
        {
            Children.Add(child);
        }

        public Prototype Clone()
        {
            Virus clone = new Virus(Name, Species, Weight, Age);

            foreach (var child in Children)
            {
                Virus childClone = (Virus)child.Clone();
                clone.AddChild(childClone);
            }

            return clone;
        }

        public void DisplayInfo(int level = 0)
        {
            string indent = new string(' ', level * 4);
            Console.WriteLine($"{indent}Virus: {Name}");
            Console.WriteLine($"{indent}Species: {Species}");
            Console.WriteLine($"{indent}Weight: {Weight} mcg");
            Console.WriteLine($"{indent}Age: {Age} days");

            if (Children.Count > 0)
            {
                Console.WriteLine($"{indent}Children ({Children.Count}):");
                foreach (var child in Children)
                {
                    child.DisplayInfo(level + 1);
                }
            }
        }
    }
}
