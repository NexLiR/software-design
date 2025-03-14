using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method.Subscriptions
{
    public class EducationalSubscription : Subscription
    {
        public EducationalSubscription()
        {
            MonthlyFee = 149.99;
            MinimumPeriod = 3;
            Channels = new List<string> { "Documentals", "Sience", "Hystory", "Education" };
            Features = new List<string> { "HD", "Offline view", "No ads" };
        }
    }
}
