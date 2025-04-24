using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.AirTrafficControl
{
    class Aircraft
    {
        private IAirportMediator _mediator;
        public string Name { get; private set; }
        public bool IsTakingOff { get; set; }

        public Aircraft(string name, int size)
        {
            this.Name = name;
        }

        public void SetMediator(IAirportMediator mediator)
        {
            _mediator = mediator;
        }

        public void Land()
        {
            Console.WriteLine($"Aircraft {this.Name} is requesting landing permission.");

            bool landingSuccessful = _mediator.RequestLanding(this);

            if (landingSuccessful)
            {
                Console.WriteLine($"Aircraft {this.Name} has landed successfully.");
            }
            else
            {
                Console.WriteLine($"Aircraft {this.Name} could not land: all runways are busy.");
            }
        }

        public void TakeOff()
        {
            Console.WriteLine($"Aircraft {this.Name} is preparing for takeoff.");
            IsTakingOff = true;
            _mediator.NotifyTakeoff(this);
            IsTakingOff = false;
            Console.WriteLine($"Aircraft {this.Name} has taken off successfully.");
        }
    }
}
