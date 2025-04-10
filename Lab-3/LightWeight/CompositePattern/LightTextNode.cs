using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight.CompositePattern
{
    public class LightTextNode : LightNode
    {
        private string _text;

        public LightTextNode(string text)
        {
            _text = text;
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public override string GetOuterHTML()
        {
            return _text;
        }
    }
}
