using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method.Subscriptions
{
    public class DomesticSubscription : Subscription
    {
        public DomesticSubscription()
        {
            MonthlyFee = 199.99;
            MinimumPeriod = 1;
            Channels = new List<string> { "News", "Films", "Sport" };
            Features = new List<string> { "UHD", "2 devices connection" };
        }
    }
}
