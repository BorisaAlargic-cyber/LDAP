using System;
using System.Collections.Generic;
using IIS.Model;
using IIS.Model.Request;
using IIS.Repository;

namespace IIS.Service
{
    public class TicketService
    {
        public TicketService()
        {
        }


        public Ticket CreateTicket(AddTicketRequest ticket)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {

                    Ticket dBTicket = new Ticket();
                    dBTicket.TicketNumber = ticket.TicketNumber;
                    dBTicket.Price = ticket.Price;
                    dBTicket.Comment = ticket.Comment;
                    dBTicket.DateOfDeparture = ticket.DateOfDeparture;
                    dBTicket.DateOfArrival = ticket.DateOfArrival;
                    dBTicket.AirCompany = ticket.AirCompany;
                    dBTicket.Canceled = false;
                    dBTicket.Active = true;

                    unitOfWork.Tickets.Add(dBTicket);
                    unitOfWork.Complete();

                    unitOfWork.Tickets.Update(dBTicket);


                    dBTicket.From = unitOfWork.Airports.Get(ticket.airportFrom);
                    dBTicket.To = unitOfWork.Airports.Get(ticket.airportTo);

                    unitOfWork.Complete();

                    return dBTicket;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public Ticket EditTicket(AddTicketRequest ticket)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Ticket dBTicket = unitOfWork.Tickets.Get(ticket.Id);

                    if (dBTicket == null)
                    {
                        return null;
                    }

                    dBTicket.TicketNumber = ticket.TicketNumber;
                    dBTicket.Price = ticket.Price;
                    dBTicket.DateOfDeparture = ticket.DateOfDeparture;
                    dBTicket.DateOfArrival = ticket.DateOfArrival;
                    dBTicket.Active = ticket.Active;

                    unitOfWork.Tickets.Update(dBTicket);
                    unitOfWork.Complete();

                    return dBTicket;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Ticket GetTicket(int ticketId)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Ticket dbTicket = unitOfWork.Tickets.Get(ticketId);

                    if(dbTicket == null)
                    {
                        return null;
                    }

                    return dbTicket;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    IEnumerable<Ticket> dbTickets = unitOfWork.Tickets.GetAll();

                    if(dbTickets == null)
                    {
                        return null;
                    }

                    return dbTickets;
                }
            }catch(Exception ee)
            {
                return null;
            }
        }

        public IEnumerable<Ticket> SearchTicket(SearchFlightTicket searchFlightTicket)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    IEnumerable<Ticket> dbTicketsDeparture = unitOfWork.Tickets.searchFlightTicketByDestinationAndTime(searchFlightTicket.destinationFromId,searchFlightTicket.destinationToId,searchFlightTicket.dateOfDeparture);
                    IEnumerable<Ticket> dbTicketArrival = unitOfWork.Tickets.searchFlightTicketByDestinationAndTime(searchFlightTicket.destinationToId, searchFlightTicket.destinationFromId, searchFlightTicket.dateOfArrival);

                    if(dbTicketsDeparture == null)
                    {
                        return null;
                    }
                    if(dbTicketArrival == null)
                    {
                        return null;
                    }

                    List<Ticket> tickets = new List<Ticket>();

                    foreach(Ticket tk in dbTicketsDeparture)
                    {
                        tickets.Add(tk);
                    }

                    foreach(Ticket tk in dbTicketArrival)
                    {
                        tickets.Add(tk);
                    }

                    return tickets;
                }
            }catch(Exception ee)
            {
                return null;
            }
        }

        public Purcheser CreatePurcheser(PurcheserRequest purcheser)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Purcheser dbPurcheser = new Purcheser();

                    dbPurcheser.FirstName = purcheser.FirstName;
                    dbPurcheser.LastName = purcheser.LastName;
                    dbPurcheser.PassportNumber = purcheser.PassportNumber;

                    unitOfWork.Purchesers.Add(dbPurcheser);
                    unitOfWork.Complete();

                    dbPurcheser.ticket = unitOfWork.Tickets.Get(purcheser.TicketId); 
                    unitOfWork.Purchesers.Update(dbPurcheser);
                    unitOfWork.Complete();


                    return dbPurcheser;


                }
            }catch(Exception ee)
            {
                return null;
            }
        }

        public void DeleteTicket(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Ticket ticket = unitOfWork.Tickets.Get(id);

                    unitOfWork.Tickets.Update(ticket);
                    ticket.Deleted = true;

                    unitOfWork.Complete();
                }
            }
            catch (Exception ee)
            {

            }
        }
    }
}
