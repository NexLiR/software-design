using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.State.States
{
    public class DisabledState : ILightElementState
    {
        public void Enter(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} entered disabled state");
        }

        public void Exit(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} exited disabled state");
        }

        public void HandleClick(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} clicked in disabled state - ignoring");
        }

        public void HandleMouseOver(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} mouse over in disabled state - ignoring");
        }

        public void HandleMouseOut(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} mouse out in disabled state - ignoring");
        }

        public string GetStateClass() => "disabled";
        public string GetStateName() => "Disabled";
    }
}
