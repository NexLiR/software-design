using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.Products.Laptops
{
    class SamsungLaptop : ILaptop
    {
        public string ModelName { get; protected set; }

        public int YearOfManufacture { get; protected set; }

        public string CPUBrand { get; protected set; }

        public SamsungLaptop(string modelName, int yearOfManufacture, string cPUBrand)
        {
            ModelName = modelName;
            YearOfManufacture = yearOfManufacture;
            CPUBrand = cPUBrand;
        }

        public void Display()
        {
            Console.WriteLine($"Samsung Laptop {ModelName} {CPUBrand} {YearOfManufacture}");
        }
    }
}
