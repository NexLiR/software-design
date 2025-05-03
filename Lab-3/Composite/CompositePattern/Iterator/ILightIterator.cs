using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Iterator
{
    public interface ILightIterator
    {
        bool HasNext();
        LightNode Next();
        void Reset();
    }
}
