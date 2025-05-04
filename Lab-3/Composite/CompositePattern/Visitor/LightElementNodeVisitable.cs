using Composite.CompositePattern.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Visitor
{
    public class LightElementNodeVisitable : LightElementNode, ILightVisitable
    {
        public LightElementNodeVisitable(string tagName, DisplayType displayType, ClosingType closingType)
            : base(tagName, displayType, closingType)
        {
        }

        public void Accept(ILightVisitor visitor)
        {
            visitor.Visit(this);

            foreach (var child in _children)
            {
                if (child is ILightVisitable visitable)
                {
                    visitable.Accept(visitor);
                }
            }
        }
    }
}
