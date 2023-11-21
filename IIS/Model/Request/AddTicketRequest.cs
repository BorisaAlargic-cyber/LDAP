using System;
namespace IIS.Model.Request
{
    public class AddTicketRequest
    {
        public int Id { get; set; }
        public int airportFrom { get; set; }
        public int airportTo { get; set; }
        public string TicketNumber { get; set; }
        public DateTime DateOfArrival { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public DateTime DayBought { get; set; }
        public bool Canceled { get; set; }
        public string Comment { get; set; }
        public string AirCompany { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
    }
}
