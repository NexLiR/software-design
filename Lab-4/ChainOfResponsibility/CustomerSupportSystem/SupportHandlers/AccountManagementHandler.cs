using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.CustomerSupportSystem.SupportHandlers
{
    public class AccountManagementHandler : SupportHandler
    {
        protected override bool CanHandle(string issue)
        {
            return issue.ToLower().Contains("account") ||
                   issue.ToLower().Contains("login") ||
                   issue.ToLower().Contains("password") ||
                   issue.ToLower().Contains("profile") ||
                   issue.ToLower().Contains("settings");
        }

        protected override void ProcessRequest(string issue)
        {
            Console.WriteLine("The issue was passed to our account managment team.");
        }
    }
}
