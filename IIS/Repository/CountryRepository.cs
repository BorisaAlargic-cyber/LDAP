using System;
using System.Collections.Generic;
using System.Linq;
using IIS.Core;
using IIS.Model;

namespace IIS.Repository
{
    public class CountryRepository : Repository<Country> , ICountryRepository
    {
        public CountryRepository(IISContext context) : base(context) { }

        public override IEnumerable<Country> GetAll()
        {
            return IISContext.Countries.Where(x => x.Deleted == false).ToList();
        }
    }
}
