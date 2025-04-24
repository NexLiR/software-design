using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.AirTrafficControl
{
    interface IAirportMediator
    {
        bool RequestLanding(Aircraft aircraft);
        void NotifyTakeoff(Aircraft aircraft);
        Runway GetAvailableRunway();
    }
}
