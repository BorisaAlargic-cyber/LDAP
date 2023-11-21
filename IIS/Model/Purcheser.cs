using System;
namespace IIS.Model
{
    public class Purcheser : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public Ticket ticket { get; set; }
    }
}
