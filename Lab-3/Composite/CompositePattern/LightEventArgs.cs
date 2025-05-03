using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern
{
    public delegate void LightEventHandler(object sender, LightEventArgs e);
    public class LightEventArgs : EventArgs
    {
        public EventType EventType { get; private set; }
        public LightNode TargetElement { get; private set; }
        public DateTime Timestamp { get; private set; }

        public LightEventArgs(EventType eventType, LightNode targetElement)
        {
            EventType = eventType;
            TargetElement = targetElement;
            Timestamp = DateTime.Now;
        }
    }
}
 