using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.Products.Smartphones
{
    interface ISmartphone
    {
        public string ModelName { get; }
        public int YearOfManufacture { get; }
        public string StorageSize { get; }
        void Display();
    }
}
