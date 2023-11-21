using System;
namespace IIS.Model
{
    public class FlightAdditionals : BaseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string MilesToGet { get; set; }
        public string MilesToDiscount { get; set; }
        public string MilesDiscountPercent { get; set; }

    }
}
