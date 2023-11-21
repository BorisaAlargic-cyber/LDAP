using System;
namespace IIS.Model
{
    public class Ticket : BaseModel
    {
        public string TicketNumber { get; set; }
        public DateTime DateOfArrival { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public DateTime DayBought { get; set; }
        public bool Canceled { get; set; }
        public string Comment { get; set; }
        public string AirCompany { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
        public Airport From { get; set; }
        public Airport To { get; set; }
    }
}
