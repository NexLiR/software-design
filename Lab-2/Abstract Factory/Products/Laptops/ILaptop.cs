using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.Products.Laptops
{
    interface ILaptop
    {
        public string ModelName { get; }
        public int YearOfManufacture { get; }
        public string CPUBrand { get; }
        void Display();
    }
}
