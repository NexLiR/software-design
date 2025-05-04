using Composite.CompositePattern.Command.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Command
{
    public class CommandHistory
    {
        private readonly Stack<ICommand> _history = new Stack<ICommand>();

        public void Push(ICommand command)
        {
            _history.Push(command);
        }

        public bool CanUndo()
        {
            return _history.Count > 0;
        }

        public void Undo()
        {
            if (!CanUndo())
                return;

            var command = _history.Pop();
            command.Undo();
        }

        public IEnumerable<string> GetCommandHistory()
        {
            return _history.Reverse().Select(cmd => cmd.Description);
        }
    }
}
