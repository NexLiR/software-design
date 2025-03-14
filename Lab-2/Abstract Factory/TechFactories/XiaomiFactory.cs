using Abstract_Factory.Products.Laptops;
using Abstract_Factory.Products.Smartphones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.TechFactories
{
    class XiaomiFactory
    {
        public ILaptop CreateLaptop()
        {
            Console.WriteLine("Creating Xiaomi laptop");
            return new XiaomiLaptop("Turbo", 2023, "Intel");
        }

        public ISmartphone CreateSmartphone()
        {
            Console.WriteLine("Creating Xiaomi smartphone");
            return new XiaomiSmartphone("Redmi Note 3", 2023, "256Gb");
        }
    }
}
