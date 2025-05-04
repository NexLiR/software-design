using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.State.States
{
    public class DefaultState : ILightElementState
    {
        public void Enter(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} entered default state");
        }

        public void Exit(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} exited default state");
        }

        public void HandleClick(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} clicked in default state, transitioning to active");
            context.SetState(context.GetActiveState());
        }

        public void HandleMouseOver(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} mouse over in default state, transitioning to hover");
            context.SetState(context.GetHoverState());
        }

        public void HandleMouseOut(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} mouse out in default state - ignoring");
        }

        public string GetStateClass() => "default";
        public string GetStateName() => "Default";
    }
}
