using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Command.Commands
{
    public class AddEventListenerCommand : ICommand
    {
        private readonly LightElementNode _element;
        private readonly EventType _eventType;
        private readonly LightEventHandler _handler;
        private bool _wasAdded = false;

        public AddEventListenerCommand(LightElementNode element, EventType eventType, LightEventHandler handler)
        {
            _element = element;
            _eventType = eventType;
            _handler = handler;
        }

        public string Description => $"Add {_eventType} event listener to {_element.TagName}";

        public void Execute()
        {
            _element.AddEventListener(_eventType, _handler);
            _wasAdded = true;
        }

        public void Undo()
        {
            if (_wasAdded)
            {
                _element.RemoveEventListener(_eventType, _handler);
                _wasAdded = false;
            }
        }
    }
}
