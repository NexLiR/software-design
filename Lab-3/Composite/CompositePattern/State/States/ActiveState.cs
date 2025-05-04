using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.State.States
{
    public class ActiveState : ILightElementState
    {
        public void Enter(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} entered active state");
        }

        public void Exit(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} exited active state");
        }

        public void HandleClick(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} clicked in active state, transitioning to default");
            context.SetState(context.GetDefaultState());
        }

        public void HandleMouseOver(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} mouse over in active state - ignoring");
        }

        public void HandleMouseOut(LightElementWithState context)
        {
            Console.WriteLine($"[State] {context.TagName} mouse out in active state - ignoring");
        }

        public string GetStateClass() => "active";
        public string GetStateName() => "Active";
    }
}
