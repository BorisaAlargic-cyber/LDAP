using System;
namespace IIS.Model
{
    public class Flight : BaseModel
    {
        public string FlightNumber { get; set; }
        public string MilesDiscountPercent { get; set; }
        public string MilesToDiscount { get; set; }
        public string MilesToGet { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public DateTime DateOfArrival { get; set; }
    }
}
