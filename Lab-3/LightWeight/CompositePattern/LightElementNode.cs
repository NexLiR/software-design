using FlyWeight.CompositePattern;
using FlyWeight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight.CompositePattern
{
    public class LightElementNode : LightNode
    {
        private ElementType _elementType;

        private List<string> _cssClasses;
        private List<LightNode> _children;

        public static LightElementNode Create(string tagName, DisplayType displayType, ClosingType closingType)
        {
            ElementType elementType = ElementType.GetElementType(tagName, displayType, closingType);
            return new LightElementNode(elementType);
        }

        private LightElementNode(ElementType elementType)
        {
            _elementType = elementType;
            _cssClasses = new List<string>();
            _children = new List<LightNode>();
        }

        public string TagName => _elementType.TagName;
        public DisplayType DisplayType => _elementType.DisplayType;
        public ClosingType ClosingType => _elementType.ClosingType;
        public int ChildCount => _children.Count;

        public void AddChild(LightNode child)
        {
            _children.Add(child);
        }

        public void AddCssClass(string cssClass)
        {
            if (!_cssClasses.Contains(cssClass))
            {
                _cssClasses.Add(cssClass);
            }
        }

        public string GetInnerHTML()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var child in _children)
            {
                sb.Append(child.GetOuterHTML());
            }
            return sb.ToString();
        }

        public override string GetOuterHTML()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<");
            sb.Append(_elementType.TagName);

            if (_cssClasses.Count > 0)
            {
                sb.Append(" class=\"");
                sb.Append(string.Join(" ", _cssClasses));
                sb.Append("\"");
            }

            if (_elementType.ClosingType == ClosingType.SelfClosing)
            {
                sb.Append(" />");
                return sb.ToString();
            }
            else
            {
                sb.Append(">");

                sb.Append(GetInnerHTML());

                sb.Append("</");
                sb.Append(_elementType.TagName);
                sb.Append(">");

                return sb.ToString();
            }
        }
    }
}