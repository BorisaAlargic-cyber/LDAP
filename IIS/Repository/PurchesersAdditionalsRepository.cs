using System;
using System.Collections.Generic;
using System.Linq;
using IIS.Core;
using IIS.Model;

namespace IIS.Repository
{
    public class PurchesersAdditionalsRepository : Repository<PurchesersAdditionals> ,IPurchesersAdditionalsRepository
    {
        public PurchesersAdditionalsRepository(IISContext context) : base(context) { }

        public override IEnumerable<PurchesersAdditionals> GetAll()
        {
            return IISContext.PurchesersAdditionals.Where(x => x.Deleted == false).ToList();
        }

    }
}
