using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.State.States
{
    public interface ILightElementState
    {
        void Enter(LightElementWithState context);
        void Exit(LightElementWithState context);
        void HandleClick(LightElementWithState context);
        void HandleMouseOver(LightElementWithState context);
        void HandleMouseOut(LightElementWithState context);
        string GetStateClass();
        string GetStateName();
    }
}
