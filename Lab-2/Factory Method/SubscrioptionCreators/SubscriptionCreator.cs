using Factory_Method.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method.SubscrioptionCreators
{
    public abstract class SubscriptionCreator
    {
        public abstract Subscription CreateSubscription(string subscriptionType);

        public Subscription OrderSubscription(string subscriptionType)
        {
            Subscription subscription = CreateSubscription(subscriptionType);

            ProcessPayment(subscription);
            RegisterSubscription(subscription);
            NotifyCustomer(subscription);

            return subscription;
        }

        protected virtual void ProcessPayment(Subscription subscription)
        {
            Console.WriteLine($"Payment processing for the amount of {subscription.MonthlyFee:C}");
        }

        protected virtual void RegisterSubscription(Subscription subscription)
        {
            Console.WriteLine($"Registration {subscription.GetType().Name} in the system");
        }

        protected virtual void NotifyCustomer(Subscription subscription)
        {
            Console.WriteLine($"Sending a subscription confirmation to the client");
        }
    }
}