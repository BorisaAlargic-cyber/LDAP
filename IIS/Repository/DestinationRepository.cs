using System;
using System.Collections.Generic;
using System.Linq;
using IIS.Core;
using IIS.Model;

namespace IIS.Repository
{
    public class DestinationRepository : Repository<Destination> , IDestinationRepositroy
    {
        public DestinationRepository(IISContext context) : base(context) { }

        public override IEnumerable<Destination> GetAll()
        {
            return IISContext.Destinations.Where(x => x.Deleted == false).ToList();
        }
    }
}
