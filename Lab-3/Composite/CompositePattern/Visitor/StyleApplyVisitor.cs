using Composite.CompositePattern.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Visitor
{
    public class StyleApplyVisitor : ILightVisitor
    {
        private string _cssClass;
        private string _styleToApply;

        public StyleApplyVisitor(string cssClass, string styleToApply)
        {
            _cssClass = cssClass;
            _styleToApply = styleToApply;
        }

        public void Visit(LightElementNode elementNode)
        {
            Console.WriteLine($"[Visitor] Checking element '{elementNode.TagName}' for CSS class '{_cssClass}'");
            if (elementNode.HasCssClasses() && elementNode.GetCssClassesString().Contains(_cssClass))
            {
                Console.WriteLine($"[Visitor] Applying style '{_styleToApply}' to {elementNode.TagName}");
            }
        }

        public void Visit(LightTextNode textNode)
        {
            Console.WriteLine($"[Visitor] Cannot apply styles to text node");
        }

        public void Visit(LightImageNode imageNode)
        {
            Console.WriteLine($"[Visitor] Checking image node for CSS class '{_cssClass}'");
            if (imageNode.HasCssClasses() && imageNode.GetCssClassesString().Contains(_cssClass))
            {
                Console.WriteLine($"[Visitor] Applying style '{_styleToApply}' to image");
            }
        }
    }
}
