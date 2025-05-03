using Composite.CompositePattern.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Iterator
{
    public class LightElementNodeWithIterator : LightElementNode, ILightCollection
    {
        public LightElementNodeWithIterator(string tagName, DisplayType displayType, ClosingType closingType)
            : base(tagName, displayType, closingType)
        {

        }

        public ILightIterator CreateDepthFirstIterator()
        {
            return new LightDepthFirstIterator(this);
        }

        public ILightIterator CreateBreadthFirstIterator()
        {
            return new LightBreadthFirstIterator(this);
        }
    }
}
