using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.State.States
{
    public class HoverState : ILightElementState
    {
        public void Enter(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} entered hover state");
        }

        public void Exit(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} exited hover state");
        }

        public void HandleClick(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} clicked in hover state, transitioning to active");
            context.SetState(context.GetActiveState());
        }

        public void HandleMouseOver(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} mouse over in hover state - ignoring");
        }

        public void HandleMouseOut(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} mouse out in hover state, transitioning to default");
            context.SetState(context.GetDefaultState());
        }

        public string GetStateClass() => "hover";
        public string GetStateName() => "Hover";
    }
}
