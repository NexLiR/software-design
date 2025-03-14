using Abstract_Factory.Products.Laptops;
using Abstract_Factory.Products.Smartphones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.TechFactories
{
    class SamsungFactory : ITechFactory
    {
        public ILaptop CreateLaptop()
        {
            Console.WriteLine("Creating Samsung laptop");
            return new SamsungLaptop("UltraThink", 2019, "Snapdragon");
        }

        public ISmartphone CreateSmartphone()
        {
            Console.WriteLine("Creating Samsung smartphone");
            return new SamsungSmartphone("Galaxy 33", 2025, "128Gb");
        }
    }
}
