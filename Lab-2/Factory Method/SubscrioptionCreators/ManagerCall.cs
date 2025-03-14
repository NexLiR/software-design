using Factory_Method.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method.SubscrioptionCreators
{
    public class ManagerCall : SubscriptionCreator
    {
        public override Subscription CreateSubscription(string subscriptionType)
        {
            Console.WriteLine("Create a subscription by calling the manager...");

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
            Console.WriteLine("Payment by bank card through the manager");
            base.ProcessPayment(subscription);
        }

        protected override void RegisterSubscription(Subscription subscription)
        {
            Console.WriteLine("Registration of a subscription by a manager with additional information about the client");
            base.RegisterSubscription(subscription);
        }

        protected override void NotifyCustomer(Subscription subscription)
        {
            Console.WriteLine("Subscription confirmation sent by email and SMS");
            base.NotifyCustomer(subscription);
        }
    }
}
