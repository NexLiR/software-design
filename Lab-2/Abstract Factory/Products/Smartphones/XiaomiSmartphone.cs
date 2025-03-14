using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.Products.Smartphones
{
    class XiaomiSmartphone : ISmartphone
    {
        public string ModelName { get; protected set; }

        public int YearOfManufacture { get; protected set; }

        public string StorageSize { get; protected set; }

        public XiaomiSmartphone(string modelName, int yearOfManufacture, string storageSize)
        {
            ModelName = modelName;
            YearOfManufacture = yearOfManufacture;
            StorageSize = storageSize;
        }

        public void Display()
        {
            Console.WriteLine($"Xiaomi Smartphone {ModelName} {StorageSize} {YearOfManufacture}");
        }
    }
}
