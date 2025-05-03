using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Template
{
    public class LightElementNodeWithHooks : LightNodeWithHooks
    {
        private string _tagName;
        private DisplayType _displayType;
        private ClosingType _closingType;
        private List<string> _cssClasses;
        public List<LightNode> _children;
        private Dictionary<EventType, List<LightEventHandler>> _eventListeners;
        private Dictionary<string, string> _attributes;
        private DateTime _creationTime;
        private bool _isRendered = false;

        public LightElementNodeWithHooks(string tagName, DisplayType displayType, ClosingType closingType)
        {
            _tagName = tagName;
            _displayType = displayType;
            _closingType = closingType;
            _cssClasses = new List<string>();
            _children = new List<LightNode>();
            _eventListeners = new Dictionary<EventType, List<LightEventHandler>>();
            _attributes = new Dictionary<string, string>();
            _creationTime = DateTime.Now;
            OnCreated();
        }

        public string TagName => _tagName;
        public DisplayType DisplayType => _displayType;
        public ClosingType ClosingType => _closingType;
        public int ChildCount => _children.Count;
        public DateTime CreationTime => _creationTime;

        public void AddChild(LightNode child)
        {
            _children.Add(child);

            if (child is LightNodeWithHooks nodeWithHooks)
            {
                nodeWithHooks.NotifyInserted();
            }
        }

        public void AddCssClass(string cssClass)
        {
            if (!_cssClasses.Contains(cssClass))
            {
                _cssClasses.Add(cssClass);
                NotifyClassListApplied();
            }
        }

        public void AddEventListener(EventType eventType, LightEventHandler handler)
        {
            if (!_eventListeners.ContainsKey(eventType))
            {
                _eventListeners[eventType] = new List<LightEventHandler>();
            }
            _eventListeners[eventType].Add(handler);
        }

        public void RemoveEventListener(EventType eventType, LightEventHandler handler)
        {
            if (_eventListeners.ContainsKey(eventType))
            {
                _eventListeners[eventType].Remove(handler);
                if (_eventListeners[eventType].Count == 0)
                {
                    _eventListeners.Remove(eventType);
                }
            }
        }

        public void TriggerEvent(EventType eventType)
        {
            if (_eventListeners.ContainsKey(eventType))
            {
                LightEventArgs args = new LightEventArgs(eventType, this);

                List<LightEventHandler> handlers = new List<LightEventHandler>(_eventListeners[eventType]);

                foreach (var handler in handlers)
                {
                    handler.Invoke(this, args);
                }
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

        protected override string GenerateHTML()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<");
            sb.Append(_tagName);

            foreach (var attr in _attributes)
            {
                sb.Append($" {attr.Key}=\"{attr.Value}\"");
            }

            if (_cssClasses.Count > 0)
            {
                sb.Append(" class=\"");
                sb.Append(string.Join(" ", _cssClasses));
                sb.Append("\"");
            }

            foreach (var eventPair in _eventListeners)
            {
                string eventName = eventPair.Key.ToString().ToLower();
                sb.Append($" on{eventName}=\"javascript:void(0);\"");
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

        public string GetCssClassesString()
        {
            return string.Join(" ", _cssClasses);
        }

        public void SetAttribute(string name, string value)
        {
            _attributes[name] = value;
        }

        public string GetAttribute(string name)
        {
            return _attributes.ContainsKey(name) ? _attributes[name] : null;
        }

        public void PrintStructure(int level = 0)
        {
            string indent = new string(' ', level * 2);

            string eventInfo = string.Empty;
            if (_eventListeners.Count > 0)
            {
                eventInfo = " Events: " + string.Join(", ", _eventListeners.Keys);
            }

            Console.WriteLine($"{indent}+ {_tagName} ({_displayType}, {_closingType}, Classes: {string.Join(", ", _cssClasses)}{eventInfo})");

            foreach (var child in _children)
            {
                if (child is LightElementNodeWithHooks elementNode)
                {
                    elementNode.PrintStructure(level + 1);
                }
                else if (child is LightTextNode textNode)
                {
                    Console.WriteLine($"{indent}  \"{textNode.Text}\"");
                }
            }
        }
        protected override void OnBeforeRender()
        {
            Console.WriteLine($"[Lifecycle] {_tagName} (id={GetAttribute("id") ?? "none"}) - Before render");
        }

        protected override void OnAfterRender()
        {
            _isRendered = true;
            Console.WriteLine($"[Lifecycle] {_tagName} (id={GetAttribute("id") ?? "none"}) - After render");
        }

        protected override void OnCreated()
        {
            Console.WriteLine($"[Lifecycle] {_tagName} - Created at {_creationTime}");
        }

        protected override void OnInserted()
        {
            Console.WriteLine($"[Lifecycle] {_tagName} (id={GetAttribute("id") ?? "none"}) - Inserted into parent");
        }

        protected override void OnRemoved()
        {
            Console.WriteLine($"[Lifecycle] {_tagName} (id={GetAttribute("id") ?? "none"}) - Removed from parent");
        }

        protected override void OnClassListApplied()
        {
            Console.WriteLine($"[Lifecycle] {_tagName} (id={GetAttribute("id") ?? "none"}) - Class list updated: {GetCssClassesString()}");
        }

        protected override void OnStylesApplied()
        {
            Console.WriteLine($"[Lifecycle] {_tagName} (id={GetAttribute("id") ?? "none"}) - Styles applied");
        }
    }
}
