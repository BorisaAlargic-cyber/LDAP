using System;
using System.Collections.Generic;
using System.Linq;
using IIS.Core;
using IIS.Model;

namespace IIS.Repository
{
    public class AirportRepository : Repository<Airport> , IAirportRepository
    {
        public AirportRepository(IISContext context) : base(context) { }

        public override IEnumerable<Airport> GetAll()
        {
            return IISContext.Airports.Where(x => x.Deleted == false).ToList();
        }
    }
}
