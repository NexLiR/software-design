using Factory_Method.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method.SubscrioptionCreators
{
    public class WebSite : SubscriptionCreator
    {
        public override Subscription CreateSubscription(string subscriptionType)
        {
            Console.WriteLine("Creating subscription via website...");

            return subscriptionType.ToLower() switch
            {
                "domestic" => new DomesticSubscription(),
                "educational" => new EducationalSubscription(),
                "premium" => new PremiumSubscription(),
                _ => throw new ArgumentException("Unknown subscription type")
            };
        }

        protected override void ProcessPayment(Subscription subscription)
        {
            Console.WriteLine("Payment through the website payment system");
            base.ProcessPayment(subscription);
        }
    }
}
