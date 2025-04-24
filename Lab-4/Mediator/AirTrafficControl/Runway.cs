using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.AirTrafficControl
{
    class Runway
    {
        private IAirportMediator _mediator;
        private bool _isBusy = false;
        public int Id { get; private set; }
        private int _runwayCount = 0;

        public Runway()
        {
            Id += ++_runwayCount;
        }

        public void SetMediator(IAirportMediator mediator)
        {
            _mediator = mediator;
        }

        public bool IsBusy()
        {
            return _isBusy;
        }

        public void SetBusy(bool busy)
        {
            _isBusy = busy;
        }
    }
}
