using System;
namespace IIS.Model.Request
{
    public class SearchFlightTicket : BaseModel
    {
        public DateTime dateOfDeparture { get; set; }
        public DateTime dateOfArrival { get; set; }
        public int destinationFromId { get; set; }
        public int destinationToId { get; set; }
     
    }
}
