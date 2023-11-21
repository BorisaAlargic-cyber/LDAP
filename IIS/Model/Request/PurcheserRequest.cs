using System;
namespace IIS.Model.Request
{
    public class PurcheserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public int TicketId { get; set; }
    }
}
