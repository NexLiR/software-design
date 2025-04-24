using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.CustomerSupportSystem.SupportHandlers
{
    public class ProductInformationHandler : SupportHandler
    {
        protected override bool CanHandle(string issue)
        {
            return issue.ToLower().Contains("info") ||
                   issue.ToLower().Contains("feature") ||
                   issue.ToLower().Contains("how to") ||
                   issue.ToLower().Contains("product") ||
                   issue.ToLower().Contains("services");
        }

        protected override void ProcessRequest(string issue)
        {
            Console.WriteLine("The issue was passed to our product specialists team.");
        }
    }
}
