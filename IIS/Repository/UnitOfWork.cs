using System;
using IIS.Core;
using IIS.Model;

namespace IIS.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IISContext context;

        public UnitOfWork(IISContext context)
        {
            this.context = context;

            Airplanes = new AirplaneRepository(this.context);
            Airports = new AirportRepository(this.context);
            Cities = new CityRepository(this.context);
            Countries = new CountryRepository(this.context);
            Destinations = new DestinationRepository(this.context);
            Flights = new FlightRepository(this.context);
            FlightAdditionals = new FlightAdditionalsRepository(this.context);
            Tickets = new TicketRepository(this.context);
            Users = new UserRepository(this.context);
            Purchesers = new PurcheserRepository(this.context);
            PurchesersAdditionals = new PurchesersAdditionalsRepository(this.context);
            
        }

        public IAirplaneRepository Airplanes { get; private set; }
        public IAirportRepository Airports { get; private set; }
        public ICityRepository Cities { get; private set; }
        public ICountryRepository Countries { get; private set; }
        public IDestinationRepositroy Destinations { get; private set; }
        public IFlightRepository Flights { get; private set; }
        public IFlightAdditionalsRepository FlightAdditionals { get; private set; }
        public ITicketRepository Tickets { get; private set; }
        public IUserRepository Users { get; private set; }
        public IPurcheserRepository Purchesers { get; private set; }
        public IPurchesersAdditionalsRepository PurchesersAdditionals { get; private set; }
        

        public IISContext Context
        {
            get { return context; }
        }
        public int Complete()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
