using Composite.CompositePattern.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Visitor
{
    public class LightTextNodeVisitable : LightTextNode, ILightVisitable
    {
        public LightTextNodeVisitable(string text)
            : base(text)
        {
        }

        public void Accept(ILightVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
