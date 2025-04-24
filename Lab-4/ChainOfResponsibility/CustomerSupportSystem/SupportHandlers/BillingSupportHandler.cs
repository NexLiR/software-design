using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.CustomerSupportSystem.SupportHandlers
{
    public class BillingSupportHandler : SupportHandler
    {
        protected override bool CanHandle(string issue)
        {
            return issue.ToLower().Contains("bill") ||
                   issue.ToLower().Contains("payment") ||
                   issue.ToLower().Contains("charge") ||
                   issue.ToLower().Contains("subscription") ||
                   issue.ToLower().Contains("pricing");
        }

        protected override void ProcessRequest(string issue)
        {
            Console.WriteLine("The issue was passed to our billing managment team.");
        }
    }
}
