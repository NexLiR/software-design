using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern
{
    public class LightElementNode : LightNode
    {
        private string _tagName;
        private DisplayType _displayType;
        private ClosingType _closingType;
        private List<string> _cssClasses;
        private List<LightNode> _children;

        public LightElementNode(string tagName, DisplayType displayType, ClosingType closingType)
        {
            _tagName = tagName;
            _displayType = displayType;
            _closingType = closingType;
            _cssClasses = new List<string>();
            _children = new List<LightNode>();
        }

        public string TagName => _tagName;
        public DisplayType DisplayType => _displayType;
        public ClosingType ClosingType => _closingType;
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
            sb.Append(_tagName);

            if (_cssClasses.Count > 0)
            {
                sb.Append(" class=\"");
                sb.Append(string.Join(" ", _cssClasses));
                sb.Append("\"");
            }

            if (_closingType == ClosingType.SelfClosing)
            {
                sb.Append(" />");
                return sb.ToString();
            }
            else
            {
                sb.Append(">");

                sb.Append(GetInnerHTML());

                sb.Append("</");
                sb.Append(_tagName);
                sb.Append(">");

                return sb.ToString();
            }
        }
        public void PrintStructure(int level = 0)
        {
            string indent = new string(' ', level * 2);

            Console.WriteLine($"{indent}+ {_tagName} ({_displayType}, {_closingType}, Classes: {string.Join(", ", _cssClasses)})");

            foreach (var child in _children)
            {
                if (child is LightElementNode elementNode)
                {
                    elementNode.PrintStructure(level + 1);
                }
                else if (child is LightTextNode textNode)
                {
                    Console.WriteLine($"{indent}  \"{textNode.Text}\"");
                }
            }
        }
    }
}