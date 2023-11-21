using System;
using System.Collections.Generic;
using System.Linq;
using IIS.Core;
using IIS.Model;

namespace IIS.Repository
{
    public class AirplaneRepository : Repository<Airplane> , IAirplaneRepository
    {
        public AirplaneRepository(IISContext context) : base(context) { }

        public override IEnumerable<Airplane> GetAll()
        {
            return IISContext.Airplanes.Where(x => x.Deleted == false).ToList();
        }
    }
}
