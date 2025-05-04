using Composite.CompositePattern.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Visitor
{
    public interface ILightVisitor
    {
        void Visit(LightElementNode elementNode);
        void Visit(LightTextNode textNode);
        void Visit(LightImageNode imageNode);
    }
}
