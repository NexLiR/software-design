using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Character
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public string Build { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public List<string> Inventory { get; set; } = new List<string>();
        public List<string> Deeds { get; set; } = new List<string>();
        public bool IsHero { get; set; }
        public string SpecialPower { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Character Type: {(IsHero ? "Hero" : "Enemy")}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Height: {Height} cm");
            Console.WriteLine($"Build: {Build}");
            Console.WriteLine($"Hair Color: {HairColor}");
            Console.WriteLine($"Eye Color: {EyeColor}");

            Console.WriteLine("Inventory:");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"- {item}");
            }

            Console.WriteLine($"Special Power: {SpecialPower}");

            foreach (var deed in Deeds)
            {
                Console.WriteLine($"{deed}");
            }

            Console.WriteLine();
        }
    }
}
