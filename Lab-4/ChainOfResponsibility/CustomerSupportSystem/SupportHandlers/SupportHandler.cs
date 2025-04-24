using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.CustomerSupportSystem.SupportHandlers
{
    public abstract class SupportHandler
    {
        protected SupportHandler _nextHandler;

        public SupportHandler SetNext(SupportHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual void HandleRequest(string issue)
        {
            if (CanHandle(issue))
            {
                ProcessRequest(issue);
            }
            else if (_nextHandler != null)
            {
                Console.WriteLine($"Transferring to {_nextHandler.GetType().Name}...\n");
                _nextHandler.HandleRequest(issue);
            }
            else
            {
                Console.WriteLine("Unfortunately, none of our specialists could resolve your issue.");
                Console.WriteLine("Rephrase it please.\n");
            }
        }
        protected abstract bool CanHandle(string issue);

        protected abstract void ProcessRequest(string issue);
    }
}
