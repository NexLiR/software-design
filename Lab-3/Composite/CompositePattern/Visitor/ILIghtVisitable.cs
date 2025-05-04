using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Visitor
{
    public interface ILightVisitable
    {
        void Accept(ILightVisitor visitor);
    }
}
