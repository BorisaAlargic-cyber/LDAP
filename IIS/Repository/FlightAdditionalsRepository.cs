using System;
using System.Collections.Generic;
using System.Linq;
using IIS.Core;
using IIS.Model;

namespace IIS.Repository
{
    public class FlightAdditionalsRepository : Repository<FlightAdditionals> , IFlightAdditionalsRepository
    {
        public FlightAdditionalsRepository(IISContext context) : base(context) { }

        public override IEnumerable<FlightAdditionals> GetAll()
        {
            return IISContext.FlightAdditionals.Where(x => x.Deleted == false).ToList();
        }
    }
}
