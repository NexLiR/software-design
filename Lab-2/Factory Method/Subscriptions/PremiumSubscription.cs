using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method.Subscriptions
{
    public class PremiumSubscription : Subscription
    {
        public PremiumSubscription()
        {
            MonthlyFee = 349.99;
            MinimumPeriod = 6;
            Channels = new List<string> { "Premium films", "Premium series", "Sport live", "News" };
            Features = new List<string> { "4K", "No ads", "Exclusive content" };
        }
    }
}
