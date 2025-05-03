using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Template
{
    public class LightTextNodeWithHooks : LightNodeWithHooks
    {
        private string _text;
        private DateTime _creationTime;

        public LightTextNodeWithHooks(string text)
        {
            _text = text;
            _creationTime = DateTime.Now;
            OnCreated();
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
            }
        }

        protected override string GenerateHTML()
        {
            return _text;
        }

        protected override void OnCreated()
        {
            Console.WriteLine($"[Lifecycle] TextNode - Created at {_creationTime} with text: {(_text.Length > 20 ? _text.Substring(0, 20) + "..." : _text)}");
        }

        protected override void OnInserted()
        {
            Console.WriteLine($"[Lifecycle] TextNode - Inserted into parent with text: {(_text.Length > 20 ? _text.Substring(0, 20) + "..." : _text)}");
        }

        protected override void OnBeforeRender()
        {
            Console.WriteLine($"[Lifecycle] TextNode - Before render with text: {(_text.Length > 20 ? _text.Substring(0, 20) + "..." : _text)}");
        }

        protected override void OnAfterRender()
        {
            Console.WriteLine($"[Lifecycle] TextNode - After render");
        }

        protected override void OnRemoved()
        {
            Console.WriteLine($"[Lifecycle] TextNode - Removed from parent");
        }
    }
}
