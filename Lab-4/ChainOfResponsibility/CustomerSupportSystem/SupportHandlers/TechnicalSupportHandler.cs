using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.CustomerSupportSystem.SupportHandlers
{
    public class TechnicalSupportHandler : SupportHandler
    {
        protected override bool CanHandle(string issue)
        {
            return issue.ToLower().Contains("technical") ||
                   issue.ToLower().Contains("software") ||
                   issue.ToLower().Contains("hardware") ||
                   issue.ToLower().Contains("device") ||
                   issue.ToLower().Contains("not working");
        }

        protected override void ProcessRequest(string issue)
        {
            Console.WriteLine("The issue was passed to our technical specialists team.");
        }
    }
}
