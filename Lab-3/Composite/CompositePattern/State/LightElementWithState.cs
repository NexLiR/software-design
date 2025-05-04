using Composite.CompositePattern.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composite.CompositePattern.State.States;

namespace Composite.CompositePattern.State
{
    public class LightElementWithState : LightElementNode
    {
        private ILightElementState _currentState;
        private ILightElementState _defaultState;
        private ILightElementState _hoverState;
        private ILightElementState _activeState;
        private ILightElementState _disabledState;

        public LightElementWithState(string tagName, DisplayType displayType, ClosingType closingType)
            : base(tagName, displayType, closingType)
        {
            _defaultState = new DefaultState();
            _hoverState = new HoverState();
            _activeState = new ActiveState();
            _disabledState = new DisabledState();

            SetState(_defaultState);
        }

        public void SetState(ILightElementState newState)
        {
            Console.WriteLine($"[State] {TagName} state changing from {(_currentState?.GetStateName() ?? "null")} to {newState.GetStateName()}");

            if (_currentState != null)
            {
                Console.WriteLine($"[State] Removing class '{_currentState.GetStateClass()}' from {TagName}");
                _currentState.Exit(this);
            }

            _currentState = newState;
            AddCssClass(_currentState.GetStateClass());
            _currentState.Enter(this);
        }

        public void HandleClick()
        {
            _currentState.HandleClick(this);
        }

        public void HandleMouseOver()
        {
            _currentState.HandleMouseOver(this);
        }

        public void HandleMouseOut()
        {
            _currentState.HandleMouseOut(this);
        }

        public ILightElementState GetDefaultState() => _defaultState;
        public ILightElementState GetHoverState() => _hoverState;
        public ILightElementState GetActiveState() => _activeState;
        public ILightElementState GetDisabledState() => _disabledState;

        public bool IsDisabled() => _currentState == _disabledState;
        public bool IsActive() => _currentState == _activeState;
    }
}
