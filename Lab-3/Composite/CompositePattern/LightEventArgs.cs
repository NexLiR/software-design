using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern
{
    public class LightEventArgs : EventArgs
    {
        public EventType EventType { get; private set; }
        public LightElementNode TargetElement { get; private set; }
        public DateTime Timestamp { get; private set; }

        public LightEventArgs(EventType eventType, LightElementNode targetElement)
        {
            EventType = eventType;
            TargetElement = targetElement;
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Event: {EventType} on {TargetElement.TagName} at {Timestamp:HH:mm:ss.fff}";
        }
    }
}
