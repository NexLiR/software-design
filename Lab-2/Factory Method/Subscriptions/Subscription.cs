using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method.Subscriptions
{
    public abstract class Subscription
    {
        public double MonthlyFee { get; protected set; }
        public int MinimumPeriod { get; protected set; }
        public List<string> Channels { get; protected set; }
        public List<string> Features { get; protected set; }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Subscribe type: {GetType().Name}");
            Console.WriteLine($"Monthly fee: {MonthlyFee:C}");
            Console.WriteLine($"Minimum period: {MinimumPeriod} months");
            Console.WriteLine("Accessible channels:");
            foreach (var channel in Channels)
            {
                Console.WriteLine($"- {channel}");
            }
            Console.WriteLine("Additional features:");
            foreach (var feature in Features)
            {
                Console.WriteLine($"- {feature}");
            }
            Console.WriteLine();
        }
    }
}
