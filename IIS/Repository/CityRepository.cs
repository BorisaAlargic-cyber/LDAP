using System;
using System.Collections.Generic;
using System.Linq;
using IIS.Core;
using IIS.Model;

namespace IIS.Repository
{
    public class CityRepository : Repository<City> , ICityRepository
    {
        public CityRepository(IISContext context) : base(context) { }

        public override IEnumerable<City> GetAll()
        {
            return IISContext.Cities.Where(x => x.Deleted == false).ToList();
        }
    }
}
