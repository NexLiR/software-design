using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.AirTrafficControl
{
    class CommandCentre : IAirportMediator
    {
        private List<Runway> _runways = new List<Runway>();
        private List<Aircraft> _aircrafts = new List<Aircraft>();
        private Dictionary<Aircraft, Runway> _assignments = new Dictionary<Aircraft, Runway>();

        public CommandCentre(Runway[] runways, Aircraft[] aircrafts)
        {
            this._runways.AddRange(runways);
            this._aircrafts.AddRange(aircrafts);

            foreach (var runway in runways)
            {
                runway.SetMediator(this);
            }

            foreach (var aircraft in aircrafts)
            {
                aircraft.SetMediator(this);
            }
        }

        public bool RequestLanding(Aircraft aircraft)
        {
            var runway = GetAvailableRunway();
            if (runway != null)
            {
                Console.WriteLine($"Command Centre: Runway {runway.Id} assigned to aircraft {aircraft.Name}");
                _assignments[aircraft] = runway;
                runway.SetBusy(true);
                return true;
            }
            else
            {
                Console.WriteLine("Command Centre: No available runways at the moment");
                return false;
            }
        }

        public void NotifyTakeoff(Aircraft aircraft)
        {
            if (_assignments.ContainsKey(aircraft))
            {
                var runway = _assignments[aircraft];
                Console.WriteLine($"Command Centre: Aircraft {aircraft.Name} is taking off from runway {runway.Id}");
                runway.SetBusy(false);
                _assignments.Remove(aircraft);
            }
        }

        public Runway GetAvailableRunway()
        {
            return _runways.Find(r => !r.IsBusy());
        }

        public void DisplaySystemStatus()
        {
            Console.WriteLine("\n=== AIRPORT SYSTEM STATUS ===");
            Console.WriteLine("Runways:");
            foreach (var runway in _runways)
            {
                string status = runway.IsBusy() ? "BUSY" : "AVAILABLE";
                Console.WriteLine($"- Runway {runway.Id}: {status}");
            }

            Console.WriteLine("\nAircraft assignments:");
            foreach (var assignment in _assignments)
            {
                Console.WriteLine($"- Aircraft {assignment.Key.Name} is using runway {assignment.Value.Id}");
            }
            Console.WriteLine("\n");
        }
    }
}
