using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_Factory.Products.Laptops;
using Abstract_Factory.Products.Smartphones;

namespace Abstract_Factory.TechFactories
{
    interface ITechFactory
    {
        ILaptop CreateLaptop();
        ISmartphone CreateSmartphone();
    }
}
