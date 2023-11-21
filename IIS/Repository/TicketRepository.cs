using System;
using System.Collections.Generic;
using System.Linq;
using IIS.Core;
using IIS.Model;
using Microsoft.EntityFrameworkCore;

namespace IIS.Repository
{
    public class TicketRepository : Repository<Ticket> , ITicketRepository
    {
        public TicketRepository(IISContext context) : base(context) { }

        public List<Ticket> searchFlightTicketByDestinationAndTime(int destinationFromId,int destinationToId ,DateTime date)
        {
            return IISContext.Tickets
                .Include(x => x.From)
                .Include(x => x.To)
                .Include(x => x.From.destination)
                .Include(x => x.To.destination)
                .Where(x => x.From.Id == destinationFromId && x.To.Id == destinationToId && x.DateOfDeparture.Date == date.Date.AddDays(1)).ToList();
        }

        public Ticket GetTicket(int id)
        {
            return IISContext.Tickets
                .Include(x => x.From)
                .Include(x => x.To)
                .Include(x => x.From.destination)
                .Include(x => x.To.destination)
                .Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
