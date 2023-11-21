using System;
using System.Collections.Generic;
using IIS.Model;

namespace IIS.Core
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        public List<Ticket> searchFlightTicketByDestinationAndTime(int destinationFromId, int destinationToId, DateTime date);
        public Ticket GetTicket(int id);
    }
}
