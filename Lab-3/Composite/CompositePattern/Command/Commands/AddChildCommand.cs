using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Command.Commands
{
    public class AddChildCommand : ICommand
    {
        private readonly LightElementNode _parent;
        private readonly LightNode _child;

        public AddChildCommand(LightElementNode parent, LightNode child)
        {
            _parent = parent;
            _child = child;
        }

        public string Description => $"Add {(_child is LightElementNode elementChild ? elementChild.TagName : "text")} node to {_parent.TagName}";

        public void Execute()
        {
            _parent.AddChild(_child);
        }

        public void Undo()
        {
            List<LightNode> newChildren = new List<LightNode>();
            foreach (var child in _parent._children)
            {
                if (child != _child)
                {
                    newChildren.Add(child);
                }
            }

            _parent._children.Clear();
            foreach (var child in newChildren)
            {
                _parent.AddChild(child);
            }
        }
    }
}
