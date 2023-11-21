using System;
namespace IIS.Model
{
    public class PurchesersAdditionals : BaseModel
    {
       public Purcheser Purcheser { get; set; }
       public FlightAdditionals FlightAdditionals { get; set; }
    }
}
