using System;
using System.Collections.Generic;
using System.Linq;
using IIS.Core;
using IIS.Model;

namespace IIS.Repository 
{
    public class PurcheserRepository : Repository<Purcheser> , IPurcheserRepository
    {
        public PurcheserRepository(IISContext context) : base(context) { }

        public override IEnumerable<Purcheser> GetAll()
        {
            return IISContext.Purchesers.Where(x => x.Deleted == false).ToList();
        }
    }
}
