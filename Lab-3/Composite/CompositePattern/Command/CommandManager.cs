using Composite.CompositePattern.Command.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Command
{
    public class CommandManager
    {
        private readonly CommandHistory _history = new CommandHistory();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _history.Push(command);
        }

        public void Undo()
        {
            _history.Undo();
        }

        public bool CanUndo()
        {
            return _history.CanUndo();
        }

        public IEnumerable<string> GetCommandHistory()
        {
            return _history.GetCommandHistory();
        }
    }
}
