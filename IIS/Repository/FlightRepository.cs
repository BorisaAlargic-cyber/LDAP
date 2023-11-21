using System;
using System.Collections.Generic;
using System.Linq;
using IIS.Core;
using IIS.Model;

namespace IIS.Repository
{
    public class FlightRepository : Repository<Flight> , IFlightRepository
    {
        public FlightRepository(IISContext context) : base(context) { }

        public override IEnumerable<Flight> GetAll()
        {
            return IISContext.Flights.Where(x => x.Deleted == false).ToList();
        }
    }
}
