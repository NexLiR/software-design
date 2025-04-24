using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChainOfResponsibility.CustomerSupportSystem.SupportHandlers;

namespace ChainOfResponsibility.CustomerSupportSystem
{
    public class CustomerSupportSystem
    {
        private SupportHandler _chainStart;

        public CustomerSupportSystem()
        {
            _chainStart = new TechnicalSupportHandler();
            var billingHandler = new BillingSupportHandler();
            var accountHandler = new AccountManagementHandler();
            var productInfoHandler = new ProductInformationHandler();

            _chainStart.SetNext(billingHandler).SetNext(accountHandler).SetNext(productInfoHandler);
        }

        public void StartSupportMenu()
        {
            bool continueSupport = true;

            while (continueSupport)
            {
                Console.WriteLine("== == == Welcome to Customer Support System == == ==");
                Console.WriteLine("Please describe your issue or type 'exit' to quit:");
                string issue = Console.ReadLine();

                if (issue.ToLower() == "exit")
                {
                    continueSupport = false;
                    Console.WriteLine("Thank you for using our support system. Goodbye!");
                }
                else
                {
                    _chainStart.HandleRequest(issue);

                    Console.WriteLine("\nDo you have another issue? (yes/no)");
                    string answer = Console.ReadLine();
                    continueSupport = answer.ToLower() == "yes";

                    Console.WriteLine();
                }
            }
        }
    }
}
