using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.ImageLoadStrategy
{
    interface IImageLoadStrategy
    {
        bool CanHandle(string source);
        string LoadImage(string source);
        bool Validate(string source);
    }
}
