using FlyWeight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight.CompositePattern
{
    public class ElementType
    {
        private string _tagName;
        private DisplayType _displayType;
        private ClosingType _closingType;

        public ElementType(string tagName, DisplayType displayType, ClosingType closingType)
        {
            _tagName = tagName;
            _displayType = displayType;
            _closingType = closingType;
        }

        public string TagName => _tagName;
        public DisplayType DisplayType => _displayType;
        public ClosingType ClosingType => _closingType;

        private static Dictionary<string, ElementType> _elementTypes = new Dictionary<string, ElementType>();

        public static ElementType GetElementType(string tagName, DisplayType displayType, ClosingType closingType)
        {
            string key = $"{tagName}|{displayType}|{closingType}";

            if (!_elementTypes.TryGetValue(key, out ElementType type))
            {
                type = new ElementType(tagName, displayType, closingType);
                _elementTypes[key] = type;
            }

            return type;
        }
    }
}
